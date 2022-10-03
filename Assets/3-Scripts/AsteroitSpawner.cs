using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class AsteroitSpawner : MonoBehaviour
{
    [SerializeField]List<GameObject> asteroits;
    GameObject randomAsteroit;

    void Awake()
    {
        //asteroits = new List<GameObject>(); 
    }

    void Update()
    {
        SpawnAsteroit();
    }

    void SpawnAsteroit()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
           randomAsteroit=Instantiate(RandomAsteroit(), gameObject.transform);
        }
    }
    GameObject RandomAsteroit()
    {
        GameObject asteroit = asteroits[Random.Range(0,14)];
        return asteroit;

    }

   /* Vector3 RandomLocation()
    {
        Vector3 location = ();
        return location;
    }*/

  
}
