using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbar : MonoBehaviour
{
    public health healthscriptRef;
    public float hpNormalizedScale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpNormalizedScale = healthscriptRef.hp / 35;
        Vector2 currentHealth = new Vector2(hpNormalizedScale, 0.2f);
        transform.localScale = currentHealth;
    }
}
