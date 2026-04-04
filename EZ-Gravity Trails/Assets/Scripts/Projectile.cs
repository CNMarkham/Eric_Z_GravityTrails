using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Throwable direction;
    public float speed;
    public Vector3 rotationAmount = new Vector3(0, 0, 50);
    // Start is called before the first frame update
    void Start()
    {
        direction = GameObject.FindGameObjectWithTag("Player").GetComponent<Throwable>();
        Invoke(nameof(DestroyThrowable), 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction.offset * Time.deltaTime * speed;
        for (int i = 0; i < 100; i++)
        {
            transform.Rotate(rotationAmount * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Surfaces"))
        {
            Destroy(gameObject);
        }
    }

    private void DestroyThrowable()
    {
        Destroy(gameObject);
    }
}
