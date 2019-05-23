using UnityEngine;
using System.Collections;

public class CardInstance : MonoBehaviour, IClickable
{

    public GE_Logic currentLogic;
    private bool isHighlighted = false;
    Vector3 basePosition;
    Vector3 baseScale;


    void Start()
    {
        basePosition = this.transform.localPosition;
        baseScale = this.transform.localScale;
    }
    public void OnClick()
    {
        if ((KnightControl.buttonClicked != true) && (BattleFlow.whichTurn == 1))
        {
            if (this.name == "Card0")
            {
                KnightControl.attackToUse = 0;
            }
            if (this.name == "Card1")
            {
                KnightControl.attackToUse = 1;
            }
            if (this.name == "Card2")
            {
                KnightControl.attackToUse = 2;
            }
            KnightControl.buttonClicked = true;
            CardControl.deleteCards = true;
            BattleFlow.whichTurn = 1;
        }
    }

    public void OnHighlight()
    {
        if (isHighlighted != true)
        {
            isHighlighted = true;
            Vector3 newPos = basePosition;
            Vector3 scale = Vector3.one * 1.5f;
            this.transform.localScale = scale;
            newPos.y = this.transform.localPosition.y + 50;
            this.transform.localPosition = newPos;
        }
    }

    public void OnDehighlight()
    {
        Debug.Log("Dehighlighted");
        this.transform.localPosition = basePosition;
        this.transform.localScale = baseScale;
        isHighlighted = false;
    }
}
