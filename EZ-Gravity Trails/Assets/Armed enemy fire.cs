using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armedenemyfire : MonoBehaviour
{
    public Transform ObjectA;
    public Transform ObjectB;
    public Transform target;

    float lastShot = 0f;
    float delayBetweenShots = 2f;
    
    public GameObject bullet;
    public GameObject barrel;
    public GameObject flash;
    public ParticleSystem effect;

    public float distance;
    public float speed = 0f;



    private void Start()
    {
        lastShot = Time.time;
    }
    void WithinDistance()
    {
        if (Time.time - lastShot >= delayBetweenShots)
        {
            Instantiate(bullet, barrel.transform.position, Quaternion.identity);
            Instantiate(flash, barrel.transform.position, Quaternion.identity);
            Instantiate(effect, barrel.transform.position, barrel.transform.rotation);
            effect.Play();
            lastShot = Time.time;
        }
    }

    private IEnumerator CallCheck()
    {
        yield return new WaitForSeconds(1f);
        WithinDistance();
    }

    void Update()
    {
        if (ObjectA != null && ObjectB != null)
        {
            distance = Vector3.Distance(ObjectA.position, ObjectB.position);
        }
        //CheckDistance();
        if (distance < 10f)
        {
            StartCoroutine(CallCheck());
        }

    }

    private void FixedUpdate()
    {
       
        float step = speed * Time.deltaTime;

        bullet.transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        
    }
}
