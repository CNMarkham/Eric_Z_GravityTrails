using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript3 : MonoBehaviour
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

        Vector2 direction = target.position - transform.position;


        if (orientTransform > orientTarget)
        {
            newRotation = Quaternion.LookRotation(direction, -Vector3.up);
        }
        else
        {
            newRotation = Quaternion.LookRotation(direction, Vector3.up);
        }

        newRotation.x = 0.0f;
        newRotation.y = 0.0f;

        Vector2 angles = newRotation.eulerAngles;

        angles.x = 0f;
        angles.y = 0f;

        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * enemyAimSpeed);
    }
}
