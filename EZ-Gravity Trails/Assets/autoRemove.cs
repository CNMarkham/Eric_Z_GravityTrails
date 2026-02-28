using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoRemove : MonoBehaviour
{
    public Movement AvatarY;
    public float heightDifference;
    public float bulletSpeed = 100f;

    public float speed = 1000f;

    public Rigidbody2D rb;
    public ParticleSystem Hiteffect;
    public GameObject EffectReference;

    public Transform target;
    public float enemyAimSpeed = 50000f;
    Quaternion newRotation;
    float orientTransform;
    float orientTarget;

    Quaternion bullet;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GetComponent<BoxCollider2D>().enabled = true;
        StartCoroutine(enableCollider());
        StartCoroutine(SelfDestruct());

        bullet = transform.rotation; 
        
    }

    // Update is called once per frame
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    IEnumerator enableCollider()
    {
        yield return new WaitForSeconds(0.05f);
        GetComponent<BoxCollider2D>().enabled = true;
    }

    private void FixedUpdate()
    {

        rb.velocity = transform.right * bulletSpeed;


        if(transform.rotation != bullet)
        {
            transform.rotation = bullet;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Surfaces"))
        {
            Destroy(gameObject);
            Instantiate(Hiteffect, transform.position, EffectReference.transform.rotation);
            Hiteffect.Play();
        }
    }
}
