using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().sortingOrder = 10;
        GetComponent<Rigidbody>().velocity = new Vector2(20, 0);
        Destroy(gameObject, 0.4f);
    }
}
