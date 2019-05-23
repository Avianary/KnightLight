using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]
public class ButtonTextColourChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    Text txt;
    Color baseColor;
    Button btn;
    bool interactableDelay;

    // Use this for initialization
    void Start()
    {
        txt = GetComponentInChildren<Text>();
        baseColor = txt.color;
        btn = gameObject.GetComponent<Button>();
        interactableDelay = btn.interactable;
    }

    // Update is called once per frame
    void Update()
    {
        if (btn.interactable != interactableDelay)
        {
            if (btn.interactable)
            {
                txt.color = baseColor * btn.colors.normalColor * btn.colors.colorMultiplier;
            } else
            {
                txt.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
            }
        }
        interactableDelay = btn.interactable;
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (btn.interactable)
        {
            txt.color = baseColor * btn.colors.highlightedColor * btn.colors.colorMultiplier;
        } else
        {
            txt.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (btn.interactable)
        {
            txt.color = baseColor * btn.colors.pressedColor * btn.colors.colorMultiplier;
        }
        else
        {
            txt.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (btn.interactable)
        {
            txt.color = baseColor * btn.colors.highlightedColor * btn.colors.colorMultiplier;
        }
        else
        {
            txt.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (btn.interactable)
        {
            txt.color = baseColor * btn.colors.normalColor * btn.colors.colorMultiplier;
        }
        else
        {
            txt.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
        }
    }
}
