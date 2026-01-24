using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armedenemyfire : MonoBehaviour
{
    public Transform ObjectA;
    public Transform ObjectB;
    public Transform target;
    
    public GameObject bullet;

    public float distance;
    public float speed = 10;

    void WithinDistance()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    void Update()
    {
        if (ObjectA != null && ObjectB != null)
        {
            distance = Vector3.Distance(ObjectA.position, ObjectB.position);

            if (distance < 10f)
            {
                //Debug.Log("you are within enemy sight");
                Invoke(nameof(WithinDistance), 2f);
            }
        }
    }

    //private void FixedUpdate()
    //{
        //bullet.transform.position = Vector2.MoveTowards(
            //transform.position,
            //target.position,
            //speed * Time.deltaTime);
    //}
}
