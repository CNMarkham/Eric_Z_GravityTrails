using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnzome : MonoBehaviour
{
    public float Turn;
    public GameObject Avatar;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Turn = 1;
        }
        else
        {
            Turn = 0;
        }
    }
}
