using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardClickScript : MonoBehaviour
{
    void OnMouseOver()
    {
        Debug.Log("Hover");
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Clicked");
            KnightControl.buttonClicked = true;
        }
    }
}


