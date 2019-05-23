using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideOptions : MonoBehaviour
{
    public GameObject panel;
    bool state;

    public void SwitchShowHide()
    {
        state = !state;
        panel.SetActive(false);
    }
}
