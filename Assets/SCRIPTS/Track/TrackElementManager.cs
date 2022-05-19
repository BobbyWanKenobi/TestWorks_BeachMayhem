using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackElementManager : MonoBehaviour
{
    /*---------------------------------------------------------------------------------------------
    *  Attached to Track_Element
    *  Manage Spawn on tracks
    *--------------------------------------------------------------------------------------------*/

    [Header("References")]
    [SerializeField] GameObject[] TrackElement_Pool;
    [SerializeField] GameObject[] Collectables_Pool;

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

    public void Activate()
    {
        foreach (var item in Collectables_Pool)
        {
            item.GetComponent<CollectableManager>().Activate();
        }
    }
}
