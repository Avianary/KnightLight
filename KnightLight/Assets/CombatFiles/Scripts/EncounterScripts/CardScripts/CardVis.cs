using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardVis : MonoBehaviour
{

    public Card card;
    public CardVisProperties[] properties;

    private void Start()
    {
        LoadCard(card);
    }

    public void LoadCard(Card c)
    {
        if (c == null)
            return;
        card = c;
        for (int i = 0; i < c.properties.Length; i++)
        {
            CardProperties cp = c.properties[i];
            CardVisProperties p = GetProperty(cp.element);
            if (p == null)
                continue;

            if (cp.element is ElementInt || cp.element is ElementText)
            {
                if (cp.element is ElementInt)
                {
                    if (c.name == "Attack")
                    {
                        p.text.text = KnightControl.knightAttDamLow.ToString() + " - " + KnightControl.knightAttDamHigh.ToString();
                    }
                    else if (c.name == "Magic")
                    {
                        p.text.text = KnightControl.knightMagDam.ToString();
                    }
                    else if (c.name == "Light")
                    {
                        p.text.text = KnightControl.lightPower.ToString();
                    }
                }
                else
                {
                    p.text.text = cp.stringValue;
                }

                for (int j = 0; j < c.properties.Length; j++)
                {
                    CardProperties cp2 = c.properties[j];
                    
                    if (cp2.element is ElementColor)
                    {
                        p.text.color = cp2.color;
                    }
                }
            }
            else if (cp.element is ElementImage)
            {
                p.img.sprite = cp.sprite;
            }
        }
    }

    public CardVisProperties GetProperty(Element e)
    {
        CardVisProperties result = null;
        for (int i = 0; i < properties.Length; i++)
        {
            if (properties[i].element == e)
            {
                result = properties[i];
                break;
            }
        }
        return result;
    }
}
