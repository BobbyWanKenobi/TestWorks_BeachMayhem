using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public static class AnalyticsScript ///: MonoBehaviour
{
    /*---------------------------------------------------------------------------------------------
    *  Copyright (c) Media4. All rights reserved.
    *  Attached to NONE.
    *  Manage ANALITICS
    *--------------------------------------------------------------------------------------------*/

    public enum Analytics_Event_Type
    {
        Level_Start,
        Level_Dead,
        Level_Finished,
        LevelQuit,
        Controll_Type,
        Swipe,
        Draw,
        Keyboard,
        Tilt,
        Touch_and_Draw,
        FirstLogin,
        Task_1_done,
        Task_2_done,
        Task_3_done,
        All_Tasks_Done,
        Bonus_Task_done,
        Survey,
    }

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public static void Send_Unity_Analytics(Analytics_Event_Type eventType, string explanation = "")
    {
        //switch (eventType)
        //{
        //    case Analytics_Event_Type.Level_Start:
        //        AnalyticsEvent.LevelStart(Level_Manager.level_Manager_Inst.Level);
        //        AnalyticsEvent.Custom(RollerBall.ball_Inst.controll_Type.ToString());

        //        Debug.Log("Analytics Event: Level_Start > Level = " + Level_Manager.level_Manager_Inst.Level + "  > Controll_Method = " + RollerBall.ball_Inst.controll_Type.ToString());
        //        break;

        //    case Analytics_Event_Type.Level_Dead:

        //        if (GameManager.gameMan_Inst.Floor_Current != null)
        //        {
        //            FloorScript flScr = GameManager.gameMan_Inst.Floor_Current.GetComponent<FloorScript>();
        //            int fatalLine = (flScr.Floor_Index * MazeManager.mazeManager_Inst.MazeElement.GetComponent<MazeSpawner>().vRows) + flScr.Row + 1;

        //            AnalyticsEvent.Custom("Killed", new Dictionary<string, object>
        //            {
        //                { "Level", Level_Manager.level_Manager_Inst.Level },
        //                { "Fatal_Line", fatalLine }
        //            }
        //            );

        //            AnalyticsEvent.LevelFail(Level_Manager.level_Manager_Inst.Level);

        //            Debug.Log("Analytics Event: Killed > Level = " + Level_Manager.level_Manager_Inst.Level + "  > Fatal_Line = " + fatalLine);
        //        }
        //        else
        //            Debug.Log("Analytics Event: Killed > ERROR, Floor_Current == null");
        //        break;

        //    case Analytics_Event_Type.Level_Finished:
        //        AnalyticsEvent.Custom("Level_Finished", new Dictionary<string, object>
        //        {
        //            { "Level", Level_Manager.level_Manager_Inst.Level },
        //            { "Coins", GameManager.gameMan_Inst.Coins_Colected }
        //        }
        //        );

        //        AnalyticsEvent.LevelComplete(Level_Manager.level_Manager_Inst.Level);

        //        Debug.Log("Analytics Event: Level_Finished > Level = " + Level_Manager.level_Manager_Inst.Level + "  > time_elapsed = " + GameManager.gameMan_Inst.Game_Time);
        //        break;

        //    case Analytics_Event_Type.LevelQuit:
        //        AnalyticsEvent.LevelQuit(Level_Manager.level_Manager_Inst.Level);
        //        break;

        //    case Analytics_Event_Type.FirstLogin:
        //        AnalyticsEvent.Custom("First_Login", new Dictionary<string, object>
        //        {
        //            { "Player", explanation }
        //        }
        //        );
        //        break;

        //    case Analytics_Event_Type.Task_1_done:
        //        AnalyticsEvent.Custom("Task_1_Done", new Dictionary<string, object>
        //        {
        //            { "Player", explanation }
        //        }
        //        );
        //        break;

        //    case Analytics_Event_Type.Task_2_done:
        //        AnalyticsEvent.Custom("Task_2_Done", new Dictionary<string, object>
        //        {
        //            { "Player", explanation }
        //        }
        //        );
        //        break;

        //    case Analytics_Event_Type.Task_3_done:
        //        AnalyticsEvent.Custom("Task_3_Done", new Dictionary<string, object>
        //        {
        //            { "Player", explanation }
        //        }
        //        );
        //        break;

        //    case Analytics_Event_Type.All_Tasks_Done:
        //        AnalyticsEvent.Custom("All_Tasks_Done", new Dictionary<string, object>
        //        {
        //            { "Player", explanation }
        //        }
        //        );
        //        break;

        //    case Analytics_Event_Type.Bonus_Task_done:
        //        AnalyticsEvent.Custom("Bonus_Task_Done", new Dictionary<string, object>
        //        {
        //            { "Player", explanation },
        //            { "Control", RollerBall.ball_Inst.controll_Type.ToString() }
        //        }
        //        );
        //        break;

        //    case Analytics_Event_Type.Survey:
        //        AnalyticsEvent.Custom("Survey_" + RollerBall.ball_Inst.controll_Type.ToString());
        //        break;
        //}
    }
}
