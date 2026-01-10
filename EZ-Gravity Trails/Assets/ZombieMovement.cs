using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float speed;
    public int maximumXPosition = -13;
    public int minimumXPosition = -30;

    private void Movement()
    {
        //if (transform.position.x <= -30 || transform.position.x >= -13)
        //{
        //speed *= -1;
        //Vector2 newDirection = transform.localScale;
        //newDirection.x *= -1;
        //transform.localScale = new Vector3(newDirection.x, newDirection.y, 0);
        //}


        while (true)
        {
            for (int i = 0; i < 20; i++)
            {
                float newXPosition = transform.position.x + speed * Time.fixedDeltaTime;
                float newYPosition = transform.position.y;
                Vector2 newPosition = new Vector2(newXPosition, newYPosition);
                transform.position = newPosition;
            }

            speed *= -1;
            Vector2 newDirection = transform.localScale;
            newDirection.x *= -1;
            transform.localScale = new Vector3(newDirection.x, newDirection.y, 0);

            for (int i = 0; i < 20; i++)
            {
                float newXPosition = transform.position.x + speed * Time.fixedDeltaTime;
                float newYPosition = transform.position.y;
                Vector2 newPosition = new Vector2(newXPosition, newYPosition);
                transform.position = newPosition;
            }
        }
    }
}
