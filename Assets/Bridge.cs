using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public float bridgeDestroytime;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine("DestroyBridge");
    }
    IEnumerator DestroyBridge()
    {
        yield return new WaitForSeconds(bridgeDestroytime);
        Destroy(gameObject);
    }
}
