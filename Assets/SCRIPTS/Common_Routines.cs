using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common_Routines : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Vector3 StringToVector3(string sVector)
    {
        // Remove the parentheses
        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }

        // split the items
        string[] sArray = sVector.Split(',');

        // store as a Vector3
        Vector3 result = new Vector3(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2]));

        return result;
    }

    public static GameObject Spawn_Particle(GameObject part, Transform tran, float scale, bool randRotation = false)
    {
        GameObject obj = Spawn_Particle(part, tran);
        obj.transform.localScale = Vector3.one * (scale + Random.Range(scale * 0.6f, scale * 1.4f));

        if (randRotation)
            obj.transform.rotation = Random.rotation;

        return obj;
    }

    public static GameObject Spawn_Particle(GameObject part, Transform tran)
    {
        GameObject obj = Instantiate(part, tran.position, tran.rotation);

        return obj;
    }
}
