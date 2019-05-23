using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Game Elements/My Hand Card")]
public class HandCard : GE_Logic
{
    public override void OnClick(CardInstance inst)
    {
        Debug.Log("a");
    }

    public override void OnHighlight(CardInstance inst)
    {
        
    }
}
