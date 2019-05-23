using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodTextManager : MonoBehaviour
{
    public static Text lightText;
    public static FoodTextManager instance = null;

    void Awake()
    {
        if (instance == null)

            instance = this;

        else if (instance != this)

            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }


    public static void ChangeLightAmount(int lightChangeAmount)
    {
        Completed.Player.food += lightChangeAmount;
        if (Completed.Player.food < 0)
        {
            Completed.Player.food = 0;
        }
        else if (Completed.Player.food > 100)
        {
            Completed.Player.food = 100;
        }
        else
        {
            lightText.text = "Light: " + Completed.Player.food.ToString();
        }
    }
}
