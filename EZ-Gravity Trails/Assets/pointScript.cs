using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointScript : MonoBehaviour
{
    public Movement AvatarY;
    public autoRemove EnemyY;
    public float heightDifference;

    public Transform target;

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 newDirection = transform.localScale;
        newDirection.y *= -1;
        transform.localScale = new Vector3(newDirection.x, newDirection.y, 0);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        heightDifference = AvatarY.Ypos - EnemyY.heightDifference - 2;


        Vector2 targetDirection = target.position - transform.position;

        targetDirection.Normalize();

        float singleStep = speed * Time.deltaTime;

        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        float newRotation = Mathf.LerpAngle(transform.eulerAngles.z, angle, singleStep);

        transform.rotation = Quaternion.Euler(0, 0, newRotation);

    }

    
}

