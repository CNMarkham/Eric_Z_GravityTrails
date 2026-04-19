using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedEnemyHealth : MonoBehaviour
{
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
        if (collision.gameObject.CompareTag("projectile") || collision.gameObject.CompareTag("explosion"))
        {

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
