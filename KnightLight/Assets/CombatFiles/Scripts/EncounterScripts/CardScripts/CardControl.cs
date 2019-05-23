using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardControl : MonoBehaviour
{
    public GameObject canvasScene;

    public GameObject attackCard;
    public GameObject defendCard;
    public GameObject lightCard;
    public GameObject lootCard;
    public GameObject magicCard;

    //public Card cardToCreate;
    public static bool drawCards;
    public static bool deleteCards;
    private int cardAmount;
    //public static List<card> cards = new List<card>;
    public List<GameObject> cardObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        deleteCards = false;
        drawCards = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (deleteCards == true)
        {
            deleteCards = false;
            if (cardObjects != null)
            {
                foreach (GameObject element in cardObjects)
                {
                    Destroy(element);
                }
                cardObjects.Clear();
            }
            Debug.Log("DELETING");
            drawCards = true;
        }

        if (BattleFlow.whichTurn == 1 && drawCards == true)
        {
            if (cardObjects != null)
            {
                foreach (GameObject element in cardObjects)
                {
                    Destroy(element);
                }
                cardObjects.Clear();
            }
            cardAmount = KnightControl.cardAmount;
            drawCards = false;
            for (int x = 0; x < cardAmount; x++)
            {
                Debug.Log("DRAWING CARD");
                if (x == 0)
                    cardObjects.Add(Instantiate(attackCard));
                else if(x == 1)
                    cardObjects.Add(Instantiate(magicCard));
                else if (x == 2)
                    cardObjects.Add(Instantiate(lightCard));

                cardObjects[x].transform.SetParent(canvasScene.transform);
                cardObjects[x].transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                cardObjects[x].transform.localPosition = new Vector3(((130 * x) - (130 * (cardAmount / 2))), -150f, 0f);
                cardObjects[x].name = "Card" + x;
            }

        }



    }
}
