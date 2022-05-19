using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class Button_FX : MonoBehaviour
{
    /*---------------------------------------------------------------------------------------------
    *  Copyright (c) Media4. All rights reserved.
    *  Attached to UI Button.
    *  Manage Button pressed FX
    *--------------------------------------------------------------------------------------------*/

    [Header("References")]
    [SerializeField] AudioClip Sound_FX = null;
    [SerializeField] MMF_Player mMF_Player = null;

    [Header("Variables")]
    [SerializeField] bool Fade = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button_Pressed()
    {
        if(Sound_FX != null)
            Audio_Controller.Inst.Play_Sound(Sound_FX);

        mMF_Player.PlayFeedbacks();

        if (Fade)
            UI_Manager.Inst.Fade_Screen();

        //DEBUG
        Player_Data.Inst.Health += Random.Range(-10, 10);
        HudManager.Inst.Update_Coins(GameObject.Find("SphereTest").transform.position , Random.Range(1, 10));
    }
}
