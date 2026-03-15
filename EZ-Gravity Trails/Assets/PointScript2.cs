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
        if (transform.rotation.z <= 90)
        {
            Vector2 newDirection = transform.localScale;
            newDirection.y = 1;
            transform.localScale = new Vector3(newDirection.x, newDirection.y, 0);
        }
        else if (transform.rotation.z >= 90)
        {
            Vector2 newDirection = transform.localScale;
            newDirection.y = -1;
            transform.localScale = new Vector3(newDirection.x, newDirection.y, 0);
        }

        orientTransform = transform.position.x;
        orientTarget = target.position.x;

        Vector3 direction = target.position - transform.position;

        if(orientTransform > orientTarget)
        {
            newRotation = Quaternion.LookRotation(direction, -Vector3.up);
        }
        else
        {
            newRotation = Quaternion.LookRotation(direction, Vector3.up);
        }

        newRotation.x = 0.0f;
        newRotation.y = 0.0f;

        Vector3 angles = newRotation.eulerAngles;

        angles.x = Mathf.Clamp(angles.x, -40f, 40f);
        angles.y = 0f;

        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * enemyAimSpeed);
    }
}
