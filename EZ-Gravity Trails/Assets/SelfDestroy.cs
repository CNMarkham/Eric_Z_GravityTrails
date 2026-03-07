using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float timeUntilDeletion;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(timeUntilDeletion);
        Destroy(gameObject);
    }
}
