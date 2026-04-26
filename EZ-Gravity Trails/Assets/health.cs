using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{
    public float hp = 100;
    public float shot_damage = 20;
    public float bleed_damage = 1;
    public float explosion_damage = 96;
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
            hp = hp - shot_damage;
        }
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.4f);
            hp = hp - bleed_damage;
        }
    }

    private IEnumerator Exploded()
    {
        hp = hp - explosion_damage;
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.1f);
            hp = hp - bleed_damage;
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
        if (collision.gameObject.CompareTag("Landmine"))
        {
            StartCoroutine(Exploded());
        }
        if (collision.gameObject.CompareTag("Vest"))
        {
            Destroy(collision.gameObject);
            shot_damage = 10;
            bleed_damage = 0.5f;
            explosion_damage = 50;
        }
        if (collision.gameObject.CompareTag("HealthPotion"))
        {
            hp = hp + 50;
        }
    }
}
