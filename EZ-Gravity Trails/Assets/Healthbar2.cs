using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar2 : MonoBehaviour
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
        hpNormalizedScale = healthscriptRef.hp / 49;
        Vector2 currentHealth = new Vector2(hpNormalizedScale, 0.14f);
        transform.localScale = currentHealth;
    }
}
