using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    /*---------------------------------------------------------------------------------------------
    *  Attached to Collectable Parent
    *  Manage collectables
    *--------------------------------------------------------------------------------------------*/

    [Header("References")]
    [SerializeField] Collectable[] colectables;

    [Header("Variables")]
    [SerializeField] Collectable_Type collectable_Type;


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
        foreach (var item in colectables)
        {
            item.Activate();
        }
    }
}
