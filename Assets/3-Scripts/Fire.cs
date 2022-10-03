using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject muzzleFlash;

    [SerializeField] float bulletForce;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
            MuzzleEffect();
        }
    }

    void FireBullet()
    {
        
        
        GameObject firedBullet = Instantiate(bullet, transform.position,transform.rotation);
        Rigidbody rb = firedBullet.GetComponent<Rigidbody>();
        rb.AddForce(-transform.up * bulletForce, ForceMode.Impulse);
        
        
    }

    void MuzzleEffect()
    {
        GameObject flash = Instantiate(muzzleFlash, transform.position, transform.rotation);
        flash.GetComponent<ParticleSystem>().Play();
    }
}
