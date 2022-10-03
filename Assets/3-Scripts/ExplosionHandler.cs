using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionHandler : MonoBehaviour
{
    [SerializeField]GameObject bigExplosion;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Untagged")
        {
            Instantiate(bigExplosion, this.gameObject.transform);
        }
        
    }
}
