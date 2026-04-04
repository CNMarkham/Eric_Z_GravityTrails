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

        if (Input.GetKeyDown(KeyCode.R))
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

    private IEnumerator Shot()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.01f);
            hp = hp - 20;
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.4f);
            hp = hp - 1;
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
            StartCoroutine(Shot());
        }

    }
}
