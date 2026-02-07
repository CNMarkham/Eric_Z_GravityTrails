using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(destruct), 0.04f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void destruct()
    {
        Destroy(gameObject);
    }
}
