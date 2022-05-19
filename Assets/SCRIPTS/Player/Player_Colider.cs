using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Colider : MonoBehaviour
{
    /*---------------------------------------------------------------------------------------------
    *  Attached to Player
    *  Manage Player Collisions
    *--------------------------------------------------------------------------------------------*/

    [SerializeField] GameObject SurfBoard;

    //EVENTS
    //GameStart
    public delegate void PlayerDamageCollide();
    public static event PlayerDamageCollide playerDamageCollide;

    // Start is called before the first frame update
    void Start()
    {
        Reset_PlayerColider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        GameManager.resetAll += Reset_PlayerColider;
    }

    private void OnDisable()
    {
        GameManager.resetAll -= Reset_PlayerColider;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Damage")
        {
            GetComponent<Player_Data>().Health -= 10;
            playerDamageCollide();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Damage")
        {
            GetComponent<Player_Data>().Health -= 10;
            Debug.LogWarning("Triger, other = " + other.name + "  > tsg = " + other.tag);
        }

        if (other.tag == "Water")
        {
            SurfBoard.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
        {
            SurfBoard.SetActive(false);
        }
    }

    void Reset_PlayerColider()
    {
        SurfBoard.SetActive(false);
    }
}
