using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript2 : MonoBehaviour
{

    public Transform target;
    public float enemyAimSpeed = 2.0f;
    Quaternion newRotation;
    float orientTransform;
    float orientTarget;
    Vector2 pos;

    void Start()
    {
        
    }


    void Update()
    {
        orientTransform = transform.position.x;
        orientTarget = target.position.x;
        if(orientTransform > orientTarget)
        {
            newRotation = Quaternion.LookRotation(transform.position - target.position, -Vector3.up);
        }
        else
        {
            newRotation = Quaternion.LookRotation(transform.position - target.position, Vector3.up);
        }

        newRotation.x = 0.0f;
        newRotation.y = 0.0f;

        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * enemyAimSpeed);


        //pos = transform.position;
        //pos.x += Input.GetAxis("depth");
    }
}
