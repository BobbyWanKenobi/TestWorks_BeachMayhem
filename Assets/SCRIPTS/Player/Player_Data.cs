using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Data : MonoBehaviour
{
    /*---------------------------------------------------------------------------------------------
    *  Copyright (c) Media4. All rights reserved.
    *  Attached to Player_Data.
    *  Manage Player variables
    *--------------------------------------------------------------------------------------------*/

    [Header("References")]
    public static Player_Data Inst = null;
    HudManager hudController = null;

    [Header("Player DATA")]
    public string Player_Name = "";

    float healt_Init = 100.0f;
    float health;
    public float Health
    {
        get { return health; }
        set {
            bool bigger = false;
            if (value > health)
                bigger = true;

            value = Mathf.Clamp(value, 0, healt_Init);
            health = value;
            if (init_Done)
                hudController.Update_Health_Bar(health, 0, healt_Init, bigger);

            if (health < 0.1f)
                GameManager.Inst.GameOver("GAME OVER");
        }
    }

    float mana_Full = 100.0f;
    float mana;
    public float Mana
    {
        get { return mana; }
        set {
            mana = value;
        }
    }

    int points;
    public int Points
    {
        get { return points; }
        set {
            points = value;
        }
    }

    int coins;
    public int Coins
    {
        get { return coins;}
        set { coins = value; }
    }

    [Header("Variables")]
    bool init_Done = false;

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
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        hudController = HudManager.Inst;
        ResetPlayerData();
        init_Done = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        Collectable.pickCollectable += Pick_Health;
        GameManager.resetAll += ResetPlayerData;
    }

    private void OnDisable()
    {
        Collectable.pickCollectable -= Pick_Health;
        GameManager.resetAll -= ResetPlayerData;
    }

    void Pick_Health(Collectable_Type colType)
    {
        if (colType == Collectable_Type.Life) 
            Health++;
    }

    public void ResetPlayerData()
    {
        Health = healt_Init / 2;
        Points = 0;
        Coins = 0;
    }
}
