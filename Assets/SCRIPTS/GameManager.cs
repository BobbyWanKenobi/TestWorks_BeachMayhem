using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*---------------------------------------------------------------------------------------------
    *  Attached to GameManager.
    *  Manage Game
    *--------------------------------------------------------------------------------------------*/

    [Header("References")]
    public static GameManager Inst = null;

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

    bool game_Paused = false;

    //EVENTS
    //GameStart
    public delegate void GameStart();
    public static event GameStart gameStart;
    //GamePaused
    public delegate void GamePaused(bool paused);
    public static event GamePaused gamePaused;
    //LevelLoad
    public delegate void LevelLoad(int lvl);
    public static event LevelLoad levelLoad;
    //ResetAll
    public delegate void ResetAll();
    public static event ResetAll resetAll;


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

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    public void Game_Start()
    {
        level = 0;

        gamePaused(false);

        gameStart();
    }

    public void Game_Paused()
    {
        game_Paused = !game_Paused;
        gamePaused(game_Paused);
    }

    public void GameOver(string str)
    {
        resetAll();
        gamePaused(true);
        UI_Manager.Inst.Show_Panel_Start(true);
        UI_Manager.Inst.Show_Text_GameOver(true, str);
        StartCoroutine(DelayHide(3));
    }

    IEnumerator DelayHide(float delay)
    {
        yield return new WaitForSeconds(delay);
        UI_Manager.Inst.Show_Text_GameOver(false, "");
    }

    public void Reset()
    {
        
    }
}
