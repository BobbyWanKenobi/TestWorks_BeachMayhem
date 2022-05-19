using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMover : MonoBehaviour
{
    /*---------------------------------------------------------------------------------------------
    *  Attached to Track_Parent
    *  Manage Track Motion
    *--------------------------------------------------------------------------------------------*/

    [Header("References")]
    [SerializeField] GameObject[] TrackElement_Pool;

    [Header("Variables")]
    [SerializeField] float ElementLenght = 50.0f;
    [SerializeField] float ViewDistance = 100.0f;

    //Motion
    float trackSpeed_CURRENT;
    float trackSpeed_TARGET;
    [SerializeField] float Track_Acceleration = 1.0f;
    [SerializeField] float TrackSpeed_MIN = 10.0f;
    [SerializeField] float TrackSpeed_MAX = 20.0f;

    bool track_Stated = false;
    bool game_Paused = false;
    int currentElementPos = 0;
    int currentApsolutePos = 0;

    //EVENTS
    //TrackSpeed
    public delegate void TrackSpeed(float speed);
    public static event TrackSpeed trackSpeed;

    // Start is called before the first frame update
    void Start()
    {
        if (TrackElement_Pool.Length < 2)
            Debug.LogError("You must have at least 3 elements !!!");

        ResetTrackMover();
    }

    // Update is called once per frame
    void Update()
    {
        if (track_Stated && game_Paused == false)
        {
            Track_Speed();
            Move_Track();
            Reposition_Track_Element();
        }
    }

    private void OnEnable()
    {
        GameManager.resetAll += ResetTrackMover;
        GameManager.gameStart += Start_Game;
        GameManager.gamePaused += Pause_Game;
        Player_Colider.playerDamageCollide += Slow_Down;
    }

    private void OnDisable()
    {
        GameManager.resetAll -= ResetTrackMover;
        GameManager.gameStart -= Start_Game;
        GameManager.gamePaused -= Pause_Game;
        Player_Colider.playerDamageCollide -= Slow_Down;
    }

    void Track_Speed()
    {
        trackSpeed_CURRENT = Mathf.Lerp(trackSpeed_CURRENT, trackSpeed_TARGET, Track_Acceleration * Time.deltaTime);
        trackSpeed(trackSpeed_CURRENT);
    }

    void Move_Track()
    {
        transform.position = transform.position - new Vector3(0, 0, trackSpeed_CURRENT * Time.deltaTime);
    }

    void Slow_Down()
    {
        trackSpeed_TARGET = trackSpeed_TARGET / 2.0f;
        trackSpeed_CURRENT = trackSpeed_CURRENT / 2.0f;
    }

    void Reposition_Track_Element()
    {
        if (transform.position.z < -((currentApsolutePos + 1) * ElementLenght))
        {
            //Move Element
            TrackElement_Pool[currentElementPos].transform.localPosition += new Vector3(0, 0, (ElementLenght * TrackElement_Pool.Length));

            //Activate Element
            TrackElement_Pool[currentElementPos].GetComponent<TrackElementManager>().Activate();

            //Manage elements
            currentElementPos++;
            if (currentElementPos >= TrackElement_Pool.Length)
                currentElementPos = 0;

            currentApsolutePos++;

            //Acceleration
            trackSpeed_TARGET += Track_Acceleration;
            if (trackSpeed_TARGET > TrackSpeed_MAX)
                trackSpeed_TARGET = TrackSpeed_MAX;
        }
    }

    public void ResetTrackMover()
    {
        track_Stated = false;
        currentElementPos = 0;
        currentApsolutePos = 0;
        trackSpeed_CURRENT = 0;
        trackSpeed_TARGET = TrackSpeed_MIN;
        transform.position = Vector3.zero;
        trackSpeed(trackSpeed_CURRENT);

        for (int i = 0; i < TrackElement_Pool.Length; i++)
        {
            TrackElement_Pool[i].transform.position = new Vector3(0, 0, ElementLenght * i);
        }
    }

    void Start_Game()
    {
        track_Stated = true;
    }

    void Pause_Game(bool paused)
    {
        game_Paused = paused;
    }
}
