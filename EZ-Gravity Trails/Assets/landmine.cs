using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landmine : MonoBehaviour
{
    public GameObject Sphere;
    public GameObject landmineTrap;
    public GameObject flash;
    public GameObject Effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("projectile"))
        {
            explode();
        }

    }

    private void explode()
    {
        Instantiate(Sphere, landmineTrap.transform.position, landmineTrap.transform.rotation);
        Instantiate(flash, landmineTrap.transform.position, landmineTrap.transform.rotation);
        Instantiate(Effect, landmineTrap.transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
