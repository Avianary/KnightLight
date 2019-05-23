using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Game Elements/My Card Down")]
public class MyCardDown : GE_Logic
{
    public override void OnClick(CardInstance inst)
    {
        Debug.Log("This card is on my table");
    }

    public override void OnHighlight(CardInstance inst)
    {

    }
}
