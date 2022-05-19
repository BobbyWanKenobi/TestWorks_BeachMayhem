using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    /*---------------------------------------------------------------------------------------------
    *  Attached to Player
    *  Manage Swipe input
    *--------------------------------------------------------------------------------------------*/

    [Header("References")]
    Player_Move playerMov;

    [Header("Screen.width / Swipe_Sensitivity")]
    public int Swipe_Sensitivity = 6;

    [Header("Variables")]
    bool Button_is_Down = false;
    private int SWIPE_MIN_DISTANCE;
    private Vector2 touchStartPoint;
    private Vector2 touchMovePoint;

    // Start is called before the first frame update
    void Start()
    {
        playerMov = GetComponent<Player_Move>();
        ResetSwipe();
    }

    // Update is called once per frame
    void Update()
    {
        Process_Swipe();
    }

    private void OnEnable()
    {
        GameManager.resetAll += ResetSwipe;
    }

    private void OnDisable()
    {
        GameManager.resetAll -= ResetSwipe;
    }

    void Process_Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Button_is_Down = true;
            touchStartPoint = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Button_is_Down = false;
        }

        if (Button_is_Down)
        {
            touchMovePoint = Input.mousePosition;
            if (Vector2.Distance(touchStartPoint, touchMovePoint) > SWIPE_MIN_DISTANCE)
            {
                detectSwipeDirection();
                touchStartPoint = touchMovePoint; // <= NEW !
            }
        }
    }

    private void detectSwipeDirection()
    {
        float xDiff = touchMovePoint.x - touchStartPoint.x;
        float yDiff = touchMovePoint.y - touchStartPoint.y;
        string nextDirection;
        bool yGreater = Mathf.Abs(yDiff) >= Mathf.Abs(xDiff);

        //Process direction
        if (yGreater)
        {
            // direction is up or down
            nextDirection = yDiff < 0 ? "DOWN" : "UP";
        }
        else
        {
            // direction is left or right
            nextDirection = xDiff < 0 ? "LEFT" : "RIGHT";
        }

        Send_Swipe_Command(nextDirection);
    }

    void Send_Swipe_Command(string nextDirection)
    {
        //Debug.Log(nextDirection);
        switch (nextDirection)
        {
            case "LEFT":
                playerMov.Button_Left_Right(-1);
                break;

            case "RIGHT":
                playerMov.Button_Left_Right(1);
                break;

            case "UP":
                playerMov.Jump();
                GetComponent<Player_Anim>().Jump();
                break;

            case "DOWN":
                //playerMov.Jump();
                break;
        }
    }

    public void ResetSwipe()
    {
        Button_is_Down = false;
        SWIPE_MIN_DISTANCE = Screen.width / Swipe_Sensitivity;
    }
}
