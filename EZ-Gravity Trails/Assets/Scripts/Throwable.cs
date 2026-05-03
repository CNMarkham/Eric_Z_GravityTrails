using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    public Text collectableCounter;
    public GameObject objectThrown;
    public Vector3 offset;
    public int throwableCounter = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (throwableCounter >= 1)
            {
                offset = transform.localScale.x * new Vector3(1, 0, 0);
                Vector3 throwablePosition = transform.position + offset;
                Instantiate(objectThrown, throwablePosition, transform.rotation);
                throwableCounter = throwableCounter -= 1;
                collectableCounter.text = throwableCounter.ToString();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            throwableCounter = throwableCounter += 1;
            collectableCounter.text = throwableCounter.ToString();
            Destroy(collision.gameObject);
        }
    }
}
