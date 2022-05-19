using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MoreMountains.Tools;

public class HudManager : MonoBehaviour
{
    /*---------------------------------------------------------------------------------------------
    *  Attached to HudController GameObject.
    *  Manage HUD
    *--------------------------------------------------------------------------------------------*/

    public static HudManager Inst = null;
    CoinsManager coinsManager = null;

    [Header("References")]
    [SerializeField] GameObject Canvas_HUD = null;
    [SerializeField] GameObject Health_Bar = null;
    [SerializeField] MMProgressBar mMProgressBar_Health = null;
    [SerializeField] GameObject Text_Point_Spawn = null;
    [SerializeField] TextMeshProUGUI Text_Speed = null;
    [SerializeField] TextMeshProUGUI Text_Orders = null;

    //[Header("Variables")]

    //DEBUG
    [SerializeField] Text Debug_FPS;


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
            ResetHud();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        coinsManager = gameObject.GetComponent<CoinsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Debug_FPS != null)
            Debug_FPS.text = (1f / Time.deltaTime).ToString("#");
    }

    private void OnEnable()
    {
        TrackMover.trackSpeed += Set_Speed_Display;
        Collectable.pickCollectable += Pick_Collectable;
    }

    private void OnDisable()
    {
        TrackMover.trackSpeed -= Set_Speed_Display;
        Collectable.pickCollectable -= Pick_Collectable;
    }

    public void ResetHud()
    {
        
    }

    public void Show_Hide_HUD(bool show_HUD)
    {
        Canvas_HUD.SetActive(show_HUD);
    }

    public void Update_Health_Bar(float currentValue, float minValue, float maxValue, bool bigger = false)
    {
        if (Canvas_HUD.activeInHierarchy)
            mMProgressBar_Health.UpdateBar01(currentValue / maxValue);

        //Flying Hearts
        if (bigger)
            coinsManager.AddHearts(Player_Data.Inst.gameObject.transform.position + new Vector3(0, 1, 0), 1);
    }

    public void Update_Coins(Vector3 position, int coins)
    {
        if (Canvas_HUD.activeInHierarchy)
        {
            Player_Data.Inst.Coins += coins;
            Vector3 pos = World_to_Canvas_Pos(position, Canvas_HUD.GetComponent<Canvas>());

            //FLYING COINS
            coinsManager.AddCoins(pos, coins);

            //Coin nuber & particle FX
            GameObject obj = Instantiate(Text_Point_Spawn, pos, Quaternion.identity);
            obj.GetComponent<TextMeshPro>().text = "+" + coins.ToString();
            Destroy(obj, 1.0f);
        }
    }

    Vector3 World_to_Canvas_Pos(Vector3 pos, Canvas canvas)
    {
        Vector2 pos2 = RectTransformUtility.WorldToScreenPoint(Camera.main, pos);
        RectTransformUtility.ScreenPointToWorldPointInRectangle(canvas.GetComponent<RectTransform>(), pos2, Camera.main, out pos);
        
        return pos;
    }

    public void Button_Pause_Pressed()
    {
        GameManager.Inst.Game_Paused();
    }

    void Set_Speed_Display(float speed)
    {
        Text_Speed.text = (speed * 3.0f).ToString("#");
    }

    public void Set_Text_Orders(int orders)
    {
        Text_Orders.text = orders.ToString();
    }

    void Pick_Collectable(Collectable_Type colType)
    {
        switch (colType)
        {
            case Collectable_Type.Coin:
                Update_Coins(Player_Data.Inst.gameObject.transform.position + new Vector3(0,1,0), 1);
                break;
            case Collectable_Type.Life:

                break;
        }

    }
}
