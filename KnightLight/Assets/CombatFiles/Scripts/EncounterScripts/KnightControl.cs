using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnightControl : MonoBehaviour
{
    public GameObject sceneController;
    public Transform fireballObj;

    public Text knightMaxHealthText;
    public Text knightCurrentHealthText;
    public Button attackButton;
    public static bool buttonClicked;
    public Transform damTextObj;
    public Image healthBar; //Put healthbarbar here
    public static int attackToUse;

    public float knightHP = 100;
    public float knightMaxHP = 100;
    public static float knightAttDamLow = 20;
    public static float knightAttDamHigh = 70;
    public static float knightMagDam = 40;
    public static int lightPower = 15;
    public static int cardAmount = 3;

    private float knightAttDam = 0;

    // Start is called before the first frame update
    void Start()
    {
        CardControl.drawCards = true;
        knightMaxHealthText.text = knightMaxHP.ToString();
        knightCurrentHealthText.text = knightHP.ToString();
        BattleFlow.currentDamage = knightAttDam;
    }

    // Update is called once per frame
    void Update()
    {
        if (BattleFlow.battleWon == true)
        {
            BattleFlow.battleWon = false;
            if (Completed.GameManager.instance != null)
            {
                Completed.GameManager.instance.playerFoodPoints = (int)LightController.currentLightLevel;
            }
            else
            {
                Debug.Log("No main game initialised yet");
            }
            Debug.Log("BATTLE END");
            sceneController.GetComponent<AutoFade>().LevelTransition(1);

        }
        else if ((BattleFlow.whichTurn == 1) && (buttonClicked == true))
        {
            BattleFlow.whichTurn = 0;
            buttonClicked = false;
            if (attackToUse == 0)
            {
                knightAttDam = Random.Range(knightAttDamLow, knightAttDamHigh + 1);
                BattleFlow.currentDamage = knightAttDam;
                GetComponent<Animator>().SetTrigger("KnightMelee");
                StartCoroutine(knightAttack());
                LightController.lightDecrease = true;
            }
            else if (attackToUse == 1)
            {
                BattleFlow.currentDamage = knightMagDam;
                GetComponent<Animator>().SetTrigger("KnightMagic");
                StartCoroutine(knightMagic());
                LightController.lightDecrease = true;
            }
            else if (attackToUse == 2)
            {
                LightController.lightIncrease = true;
                GetComponent<Animator>().SetTrigger("KnightLight");
                StartCoroutine(knightLightUp());
            }
            else
            {

            }
        } else
        {
            buttonClicked = false;
        }

        if (BattleFlow.damageDisplayKnight == true)
        {
            GetComponent<Animator>().SetTrigger("OnHit_Knight");
            knightHP -= BattleFlow.currentDamage;
            if (knightHP < 0)
            {
                knightHP = 0;
            }
            healthBar.fillAmount = (knightHP / knightMaxHP);
            if (healthBar.fillAmount > 0.7)
            {
                healthBar.color = Color.green;
            }
            else if (healthBar.fillAmount < 0.25)
            {
                healthBar.color = Color.red;
            }
            else
            {
                healthBar.color = Color.yellow;
            }
            knightCurrentHealthText.text = Mathf.Round(knightHP).ToString();
            //Debug.Log(knightHP);
            BattleFlow.damageDisplayKnight = false;
        }

        if (knightHP <= 0)
        {
            sceneController.GetComponent<AutoFade>().LevelTransition(0);
            Destroy(gameObject);
        }
    }
    IEnumerator knightMagic()
    {
        Vector3 fireballPosition = this.transform.position;
        fireballPosition.x += 1;
        fireballPosition.y -= 1.7f;
        Instantiate(fireballObj, fireballPosition, fireballObj.rotation);
        yield return new WaitForSeconds(0.4f);
        Instantiate(damTextObj, new Vector2(5.0f, 1.0f), damTextObj.rotation);
        BattleFlow.damageDisplayEnemy = true;
        yield return new WaitForSeconds(0.1f);
        yield return new WaitForSeconds(0.2f);
        BattleFlow.whichTurn = 2;
    }

    IEnumerator knightLightUp()
    {
        yield return new WaitForSeconds(0.4f);
        BattleFlow.whichTurn = 2;
    }
    IEnumerator knightAttack()
    {
        GetComponent<Rigidbody>().velocity = new Vector2(20, 0);
        yield return new WaitForSeconds(0.4f);
        GetComponent<Rigidbody>().velocity = new Vector2(0, 0);
        Instantiate(damTextObj, new Vector2(5.0f, 1.0f), damTextObj.rotation);
        BattleFlow.damageDisplayEnemy = true;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Rigidbody>().velocity = new Vector2(-40, 0);
        yield return new WaitForSeconds(0.2f);
        GetComponent<Rigidbody>().velocity = new Vector2(0, 0);
        GetComponent<Transform>().position = new Vector2(-6f, 1f);
        BattleFlow.whichTurn = 2;
    }

   /* public void onAttackButtonClick()
    {
        buttonClicked = true;
    }*/
}
