using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DEBUGger : MonoBehaviour
{
    /*---------------------------------------------------------------------------------------------
    *  Copyright (c) Ingenious Studios® All rights reserved.
    *  Attached to Canvas_DEBUG.
    *  Manages Debugging display, Set "Editor only" for final
    *--------------------------------------------------------------------------------------------*/

    [Header("Instance of Classes")]
    public static DEBUGger inst = null;

    [Header("References")]
    [SerializeField] GameObject DEBUG_Panel = null;
    [SerializeField] Text Text_DEBUG_Down = null;


    [Header("Variables")]
    bool debug_Visible = true;
    [SerializeField] int debug_List_Count = 20;

    int debug_No = 0;

    public List<string> down_List = new List<string>();

    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Button_Toggle_Debug_Display_Pressed();
        DEBUG_Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Set_Debug_Down(string msg, Color col)
    {
        Text_DEBUG_Down.text = Process_List(ref down_List, msg, col, debug_List_Count);
    }

    public void Button_Toggle_Debug_Display_Pressed()
    {
        debug_Visible = !debug_Visible;

        DEBUG_Panel.SetActive(debug_Visible);   
    }

    public void Button_Delete_All_PlayerPrefs_Pressed()
    {
        //DEBUG
        PlayerPrefs.DeleteAll();
    }

    public void Button_Clear_ALL_Pressed()
    {
        //DEBUG
        Text_DEBUG_Down.text = "";
        down_List = new List<string>();
    }

    string Process_List(ref List<string> lst, string msg, Color col, int listCnt)
    {
        msg = Color_String(msg, col);
        msg = System.DateTime.Now.ToString() + "\n" + msg;
        
        lst.Add(debug_No.ToString() + ". " + msg);
        while (lst.Count > listCnt)
            lst.RemoveAt(0);

        string str = "";
        for (int i = 0; i < lst.Count; i++)
        {
            if (i == 0)
                str += lst[i];
            else
                str += "\n" + lst[i];
        }

        debug_No++;

        return str;
    }

    public string Color_String(string text, Color color)
    {
        return "<color=#" + ColorUtility.ToHtmlStringRGBA(color) + ">" + text + "</color>";
    }
}
