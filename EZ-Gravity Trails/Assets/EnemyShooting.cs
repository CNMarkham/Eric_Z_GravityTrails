using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform ObjectA;
    public Transform ObjectB;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject flash;
    public ParticleSystem effect;
    public GameObject flashLight;

    public float FireRate = 3.0f;
    public float NextFire = 3.0f;
    public float timeToDisappear = 5;
    public float distance;

    void Start()
    {
        
    }


    void Update() 
    {
        if (ObjectA != null && ObjectB != null)
        {
            distance = Vector3.Distance(ObjectA.position, ObjectB.position);
        }

        if (Time.time > NextFire)
        {
            NextFire = Time.time + FireRate;
            {
                if (distance < 20f)
                {
                    Shoot();
                }
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(flash, firePoint.transform.position, Quaternion.identity);
        Instantiate(effect, firePoint.transform.position, firePoint.transform.rotation);
        Instantiate(flashLight, firePoint.transform.position, firePoint.transform.rotation);
    }
}
