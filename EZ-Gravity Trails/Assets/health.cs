using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    public float hp = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            StartCoroutine(ReloadScene());
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private IEnumerator SlowDeath()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.1f);
            hp = hp - 2;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(SlowDeath());
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hp = hp - 1;
        }

    }
}
