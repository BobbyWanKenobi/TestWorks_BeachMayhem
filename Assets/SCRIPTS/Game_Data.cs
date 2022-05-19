using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Data : MonoBehaviour
{
    /*---------------------------------------------------------------------------------------------
    *  Attached to Game_Data.
    *  Manage Player variables
    *--------------------------------------------------------------------------------------------*/

    [Header("References")]
    public static Game_Data Inst = null;

    [Header("Game DATA")]
    public List<GameObject> Order_List = null;
    public int OrdersToDeliver = 10;
    [SerializeField] 

    float timer;
    public float Timer
    {
        get
        {
            return timer;
        }
        set
        {
            timer = value;
        }
    }


    private void Awake()
    {
        if (Inst != null)
        {
            DestroyImmediate(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            Inst = this;
            Reset_GameData();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Order_List = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        Collectable.pickCollectable += Pick_Collectable;
        GameManager.resetAll += Reset_GameData;
    }

    private void OnDisable()
    {
        Collectable.pickCollectable -= Pick_Collectable;
        GameManager.resetAll -= Reset_GameData;
    }

    void Pick_Collectable(Collectable_Type colType)
    {

    }

    public void AddOrder(GameObject order)
    {
        bool orderPossible = true;

        for (int i = 0; i < Order_List.Count; i++)
        {
            if (Order_List[i] == order)
                orderPossible = false;
        }

        if (orderPossible)
            Order_List.Add(order);
    }

    public void RemoveOrder(GameObject order)
    {
        for (int i = 0; i < Order_List.Count; i++)
        {
            if (Order_List[i] == order)
                Order_List.RemoveAt(i);
        }
    }

    public void Button_Delivery_Pressed(int type)
    {
        Order_Type orderType = (Order_Type)type;

        bool deliverySuccess = false;

        for (int i = Order_List.Count - 1; i >= 0; i--)
        {
            if (Order_List[i].GetComponent<Order>().order_Type == orderType)
            {
                deliverySuccess = true;
                CoinsManager.Inst.AnimateDelivery(Order_List[i].transform, (int)orderType);
                Order_List[i].GetComponent<Order>().Remove_Order();
                Order_List.RemoveAt(i);
                OrdersToDeliver--;

                HudManager.Inst.Set_Text_Orders(OrdersToDeliver);

                if (OrdersToDeliver <= 0)
                    GameManager.Inst.GameOver("BRAVO");

                return;
            }
        }

        if (deliverySuccess == false)
        {
            OrdersToDeliver++;
            HudManager.Inst.Set_Text_Orders(OrdersToDeliver);
        }
    }

    public void Reset_GameData()
    {
        Timer = 0;
        Order_List = new List<GameObject>();
        OrdersToDeliver = 10;
        HudManager.Inst.Set_Text_Orders(OrdersToDeliver);
    }
}
