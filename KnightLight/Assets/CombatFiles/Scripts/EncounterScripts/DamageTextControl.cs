using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DamageTextControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().sortingOrder = 10;
        GetComponent<TextMesh>().text = Mathf.Round(BattleFlow.currentDamage).ToString();
        GetComponent<Rigidbody>().velocity = new Vector2(0, 5);
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
