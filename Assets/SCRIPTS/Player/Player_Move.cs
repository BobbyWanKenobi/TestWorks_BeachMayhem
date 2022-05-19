using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player_Move : MonoBehaviour
{
    /*---------------------------------------------------------------------------------------------
    *  Attached to Player
    *  Manage Player motion
    *--------------------------------------------------------------------------------------------*/

    [Header("References")]


    [Header("Variables")]
    int playerPos = 0;
    [SerializeField] float Motion_X_Step = 2.0f;
    [SerializeField] float Motion_Speed = 6.0f;
    float player_Y_shift = 1.0f;

    //JUMP
    Vector3 jumpStartPos;
    [SerializeField] float JumpTime = 1.6f;
    bool jumpInProgress = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Player_Motion();
    }

    private void OnEnable()
    {
        GameManager.resetAll += Reset_Player;
    }

    private void OnDisable()
    {
        GameManager.resetAll -= Reset_Player;
    }

    public void Player_Motion()
    {
        if (jumpInProgress == false)
            transform.position = Vector3.Lerp(transform.position, new Vector3(playerPos * Motion_X_Step, player_Y_shift, 0), Motion_Speed * Time.deltaTime);
    }

    public void Button_Left_Right(int mov)
    {
        playerPos = playerPos + mov;
        playerPos = Mathf.Clamp(playerPos, -1, 1);
    }

    public void Jump()
    {
        if (jumpInProgress) return;

        jumpInProgress = true;

        GetComponent<Player_Anim>().Jump();

        transform.DOJump(transform.position, 3.0f,1, JumpTime)
                .OnComplete(() => {
                    //executes whenever Pawn reach target position
                    jumpInProgress = false;
                });
    }

    public void Croutch()
    {

    }

    public void Reset_Player()
    {
        jumpInProgress = false;
        playerPos = 0;
    }
}
