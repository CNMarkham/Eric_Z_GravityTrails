using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armedenemyfire : MonoBehaviour
{
    public Transform ObjectA;
    public Transform ObjectB;
    public Transform target;

    float lastShot = 0f;
    float delayBetweenShots = 0.5f;
    
    public GameObject bullet;
    public GameObject barrel;
    public GameObject flash;
    public ParticleSystem effect;

    public float distance;
    public float speed = -10f;



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
        }
        lastShot = Time.time;
    }

    void CheckDistance()
    {
        if (distance < 10f)
        {
            WithinDistance();
        }

    }

    //IEnumerator CallCheck()
    //{
        // return new WaitForSeconds(2f);
       // CheckDistance();
    //}

    void Update()
    {
        if (ObjectA != null && ObjectB != null)
        {
            distance = Vector3.Distance(ObjectA.position, ObjectB.position);
        }
        CheckDistance();
        //StartCoroutine(CallCheck());

    }

    private void FixedUpdate()
    {
        //if (target != null)
        //{
        //float step = speed * Time.deltaTime;
        //bullet.transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
        //}
        
    }
}
