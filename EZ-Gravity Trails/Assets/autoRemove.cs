using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoRemove : MonoBehaviour
{
    public Movement AvatarY;
    public float heightDifference;
    public float bulletSpeed;

    public Transform target;

    public float speed = 1000f;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GetComponent<BoxCollider2D>().enabled = true;
        StartCoroutine(enableCollider());
        StartCoroutine(SelfDestruct());

        for (int i = 0; i < 100; i++)
        {
            Vector2 targetDirection = target.position - transform.position;

            targetDirection.Normalize();

            float singleStep = speed * Time.deltaTime;

            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

            float newRotation = Mathf.LerpAngle(transform.eulerAngles.z, angle, singleStep);

            transform.rotation = Quaternion.Euler(0, 0, newRotation);
        }
        
    }

    // Update is called once per frame
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    IEnumerator enableCollider()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<BoxCollider2D>().enabled = true;
    }
    private void FixedUpdate()
    {
        //float newXPosition = transform.position.x + bulletSpeed * Time.fixedDeltaTime;
        //float newYPosition = transform.position.y;
        //Vector2 newPosition = new Vector2(newXPosition, newYPosition);
        //transform.position = newPosition;

        rb.velocity = transform.forward * bulletSpeed * Time.deltaTime * 1000;
        
    }
}
