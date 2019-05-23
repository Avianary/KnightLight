using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class BattleFlow : MonoBehaviour
{

    public static int whichTurn = 1;
    public static float currentDamage = 0;
    public static int playerTotalXP = 0;

    public static bool battleWon = false;
    public static bool damageDisplayEnemy = false;
    public static bool damageDisplayKnight = false;


    private void Start()
    {
        whichTurn = 1;
        currentDamage = 0;
        battleWon = false;
        damageDisplayEnemy = false;
        damageDisplayKnight = false;
    }

}
