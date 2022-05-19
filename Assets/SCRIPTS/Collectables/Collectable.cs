using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Collectable_Type
{
    Coin,
    Life,
};

public class Collectable : MonoBehaviour
{
    /*---------------------------------------------------------------------------------------------
    *  Attached to Collectable
    *  Manage collectables
    *--------------------------------------------------------------------------------------------*/

    [Header("References")]
    [SerializeField] Collectable_Type collectable_Type = Collectable_Type.Coin;
    [SerializeField] GameObject Model;
    [SerializeField] ParticleSystem particleSyste;

    [Header("Variables")]
    float rotSpeed = 90.0f;

    //EVENTS
    //GameStart
    public delegate void PickCollectable(Collectable_Type colType);
    public static event PickCollectable pickCollectable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = transform.localEulerAngles + new Vector3(0, rotSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Model.SetActive(false);
            particleSyste.Play(true);
            pickCollectable(collectable_Type);
        }
    }

    private void OnEnable()
    {
        Activate();
    }

    public void Activate()
    {
        Model.SetActive(true);
        particleSyste.Play();
    }
}
