using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Actions/MouseOverDetection")]
public class MouseOverDetection : Action
{
    IClickable lastClickable = null;
    public override void Execute(float d)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        IClickable c = null;

        foreach (RaycastResult r in results)
        {
            c = r.gameObject.GetComponentInParent<IClickable>();
            if (c != lastClickable && lastClickable != null && c != null)
            {
                lastClickable.OnDehighlight();
            }
            if (c != null)
            {
                lastClickable = c;
                c.OnHighlight();
                break;
            }
            else
            {
                if (lastClickable != null)
                {
                    lastClickable.OnDehighlight();
                    lastClickable = null;
                }
                //Runs for any object that is not clickable
            }
        }
    }
}
