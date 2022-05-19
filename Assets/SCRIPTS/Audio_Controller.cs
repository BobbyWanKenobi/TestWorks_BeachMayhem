using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Controller : MonoBehaviour
{
    /*---------------------------------------------------------------------------------------------
    *  Attached to Game_Manager object.
    *  Manage Music & Sound Effects
    *--------------------------------------------------------------------------------------------*/

    public enum Sound_Effect_Type
    {
        Error,
        Correct,
        Side_Pass,
        EnemyPopUp,
        EnemyKilled,
        Impakt,
        PowerUp,
        Teleport,
        Pinball,
        Coin_Collect,
        Click,
    };

    [Header("This Instance")]
    public static Audio_Controller Inst = null;

    [Header("References")]
    [SerializeField] AudioSource MusicSource = null;
    [SerializeField] AudioClip[] MusicClip = null;  //0 = Menu
    [SerializeField] AudioClip[] SoundEffects = null;  //0 = Menu

    [SerializeField] AudioClip CollectLife;
    [SerializeField] AudioClip CollectCoin;

    [SerializeField] AudioClip Bump;

    public bool Sound_Effects_Enabled = true;
    public bool Music_Enabled = true;

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
        }
    }

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void OnEnable()
    {
        Collectable.pickCollectable += Pick_Collectable;
        Player_Colider.playerDamageCollide += Bump_Sound;
    }

    private void OnDisable()
    {
        Collectable.pickCollectable -= Pick_Collectable;
        Player_Colider.playerDamageCollide -= Bump_Sound;
    }

    void Pick_Collectable(Collectable_Type colType)
    {

        switch (colType)
        {
            case Collectable_Type.Coin:
                MusicSource.PlayOneShot(CollectCoin, 0.6f);
                break;
            case Collectable_Type.Life:
                MusicSource.PlayOneShot(CollectLife, 0.2f);
                break;
        }
    }

    public void Bump_Sound()
    {
        MusicSource.PlayOneShot(Bump, 0.8f);
    }

    public void Soun_Effects_ON_OFF()
    {

    }

    //Sets Music, 0 = Menu
    public void Set_Music(int musicClip)
    {
        if (Music_Enabled == false)
        {
            if (MusicSource.isPlaying)
                MusicSource.Stop();

            return;
        }

        if (musicClip >= MusicClip.Length)
            return;

        MusicSource.clip = MusicClip[musicClip];
        MusicSource.Play();
    }

    public void Play_Sound_Effect(Sound_Effect_Type soundEffect, float intensity = 0.6f)
    {
        if (Sound_Effects_Enabled == false)
            return;

        switch (soundEffect)
        {
            case Sound_Effect_Type.Error:
                MusicSource.PlayOneShot(SoundEffects[0], intensity);
                break;

            case Sound_Effect_Type.Correct:
                MusicSource.PlayOneShot(SoundEffects[1], intensity);
                break;

            case Sound_Effect_Type.Side_Pass:
                MusicSource.PlayOneShot(SoundEffects[2], intensity);
                break;

            case Sound_Effect_Type.EnemyPopUp:
                MusicSource.PlayOneShot(SoundEffects[2], intensity);
                break;

            case Sound_Effect_Type.EnemyKilled:
                MusicSource.PlayOneShot(SoundEffects[3], intensity);
                break;

            case Sound_Effect_Type.Impakt:
                MusicSource.PlayOneShot(SoundEffects[4], intensity);
                break;

            case Sound_Effect_Type.PowerUp:
                MusicSource.PlayOneShot(SoundEffects[5], intensity);
                break;

            case Sound_Effect_Type.Teleport:
                MusicSource.PlayOneShot(SoundEffects[6], intensity);
                break;

            case Sound_Effect_Type.Pinball:
                MusicSource.PlayOneShot(SoundEffects[7], intensity);
                break;

            case Sound_Effect_Type.Click:
                MusicSource.PlayOneShot(SoundEffects[8], intensity);
                break;

        }
    }

    public void Play_Click()
    {
        if (Sound_Effects_Enabled == false)
            return;

        Play_Sound_Effect(Sound_Effect_Type.Click, 1.0f);
    }

    public void Play_Sound(AudioClip clip, float intensity = 0.6f)
    {
        if (Sound_Effects_Enabled == false)
            return;

        MusicSource.PlayOneShot(clip, intensity);
    }
}
