using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    /*---------------------------------------------------------------------------------------------
    *  Attached to Canvas_Menus.
    *  Manage Game Menus.
    *--------------------------------------------------------------------------------------------*/

    public static UI_Manager Inst = null;

    [Header("References")]
    [SerializeField] GameObject Fade = null;
    [SerializeField] GameObject Panel_Start;
    [SerializeField] TextMeshProUGUI Text_GameOver;


    //[Header("Variables")]


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
            ResetUI();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        ResetUI();
        Text_GameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Escape_Pressed();
            return;
        }
    }

    public void ResetUI()
    {
        Show_Panel_Start(true);
    }

    public void Button_Start_Pressed()
    {
        Show_Panel_Start(false);
        GameManager.Inst.Game_Start();
    }

    public void Show_Panel_Start(bool show)
    {
        Panel_Start.SetActive(show);
    }

    public void Show_Text_GameOver(bool show, string str)
    {
        Text_GameOver.gameObject.SetActive(show);
        Text_GameOver.text = str;
    }

    public void Button_Quit_Pressed()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    void Escape_Pressed()
    {
        if (Panel_Start.activeInHierarchy == false)
        {
            Show_Panel_Start(true);
            GameManager.Inst.Game_Paused();
        } 
        else
        {
            Show_Panel_Start(false);
            GameManager.Inst.Game_Paused();
        }
    }

    public void Fade_Screen(float delay = 0)
    {
        StartCoroutine(Fade_Screen_Deactivate(0.8f));
    }

    IEnumerator Fade_Screen_Deactivate(float delay = 0)
    {
        Fade.SetActive(true);
        yield return new WaitForSeconds(delay);
        Fade.SetActive(false);
    }
}
