using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    /*---------------------------------------------------------------------------------------------
    *  Copyright (c) Media4. All rights reserved.
    *  Attached to Settings.
    *  Manage Game Settings.
    *--------------------------------------------------------------------------------------------*/

    public static Settings Inst = null;

    [Header("References")]

    [Header("Variables")]
    int level;
    public int Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
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
            Reset();
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {

    }
}
