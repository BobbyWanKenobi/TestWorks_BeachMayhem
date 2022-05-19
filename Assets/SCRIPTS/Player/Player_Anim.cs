using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Anim : MonoBehaviour
{
    /*---------------------------------------------------------------------------------------------
    *  Attached to Player
    *  Manage Character animations
    *--------------------------------------------------------------------------------------------*/

    [Header("References")]
    [SerializeField] Animator animator;

    [Header("Variables")]
    [SerializeField] float ElementLenght = 50.0f;
    [SerializeField] float ViewDistance = 100.0f;


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
        GameManager.resetAll += ResetAnim;
        GameManager.gameStart += Start_Game;
        GameManager.gamePaused += Pause_Game;
    }

    private void OnDisable()
    {
        GameManager.resetAll -= ResetAnim;
        GameManager.gameStart -= Start_Game;
        GameManager.gamePaused -= Pause_Game;
    }

    public void Set_Anim_Stage()
    {

    }

    void Start_Game()
    {
        Clear_Anim_Controller_bools();
        animator.SetBool("MedRun", true);
    }

    void Pause_Game(bool paused)
    {
        Clear_Anim_Controller_bools();
        if (paused)
            animator.SetBool("Idle", true);
        else
            animator.SetBool("MedRun", true);
    }

    public void Jump()
    {
        animator.SetBool("Jump", true);
    }

    void ResetAnim()
    {
        Clear_Anim_Controller_bools();
        animator.SetBool("Idle", true);
    }

    void Clear_Anim_Controller_bools()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("MedRun", false);
        animator.SetBool("Jump", false);
    }
}
