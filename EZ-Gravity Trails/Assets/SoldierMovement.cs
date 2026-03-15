using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    public float thrust = 20f;
    public float speed;
    public GameObject target1, target2;
    Rigidbody2D rb;
    bool move = true;
    public float gunRotation = 1;
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<Rigidbody2D>();
        //Movement();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if ((transform.position.x <= target1.transform.position.x) || (transform.position.x >= target2.transform.position.x))
        {
            speed *= -1;
            gunRotation *= -1;
            Vector3 newDirection = transform.localScale;
            if (speed < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        float newXPosition = transform.position.x + speed * Time.fixedDeltaTime;
        float newYPosition = transform.position.y;
        Vector2 newPosition = new Vector2(newXPosition, newYPosition);
        transform.position = newPosition;
    }
}
