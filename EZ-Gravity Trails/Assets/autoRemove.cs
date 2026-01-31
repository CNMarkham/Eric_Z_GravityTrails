using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoRemove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(enableCollider());
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    IEnumerator enableCollider()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<BoxCollider2D>().enabled = true;
    }

}
