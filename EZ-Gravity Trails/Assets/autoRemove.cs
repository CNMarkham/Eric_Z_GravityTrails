using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoRemove : MonoBehaviour
{
    public Movement AvatarY;
    public float heightDifference;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = true;
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
        yield return new WaitForSeconds(0.1f);
        GetComponent<BoxCollider2D>().enabled = true;
    }
    private void FixedUpdate()
    {
        heightDifference = AvatarY.Ypos - transform.position.y;
        Debug.Log(heightDifference);

        float newXPosition = transform.position.x + speed * Time.fixedDeltaTime;
        float newYPosition = transform.position.y;
        Vector2 newPosition = new Vector2(newXPosition, newYPosition);
        transform.position = newPosition;
    }
}
