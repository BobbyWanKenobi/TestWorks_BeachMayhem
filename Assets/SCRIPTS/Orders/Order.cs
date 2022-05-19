using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum Order_Type
{
    None,
    Drink,
    Pizza,
    Burger,
}

public class Order : MonoBehaviour
{
    /*---------------------------------------------------------------------------------------------
    *  Attached to GameManager.
    *  Manage Game
    *--------------------------------------------------------------------------------------------*/

    [Header("References")]
    public static GameManager Inst = null;
    [SerializeField] GameObject[] Order_Display;

    [Header("Variables")]
    public Order_Type order_Type = Order_Type.None;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in Order_Display)
        {
            item.transform.localScale = Vector3.one * 0.01f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "OrderTrigger")
            Create_New_Order();
    }

    void Create_New_Order()
    {
        if (order_Type != Order_Type.None)
            return;

        order_Type = (Order_Type)(Random.Range(1, 4));
        Game_Data.Inst.AddOrder(this.gameObject);
        Order_Display[(int)order_Type - 1].transform.localScale = Vector3.one * 0.01f;
        Order_Display[(int)order_Type - 1].transform.DOScale(Vector3.one * 0.45f, 0.1f);

        StartCoroutine(Remove_Order_Delayed(6));
    }

    IEnumerator Remove_Order_Delayed(float delay)
    {
        yield return new WaitForSeconds(delay);

        Game_Data.Inst.RemoveOrder(this.gameObject);
        Remove_Order();
    }

    public void Remove_Order()
    {
        order_Type = Order_Type.None;

        foreach (var item in Order_Display)
        {
            if (item.transform.localScale.x > 0.1f)
                item.transform.DOScale(Vector3.one * 0.01f, 0.2f);
        }
    }
}
