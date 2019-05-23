using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public LightController lightController;

    public Text enemyMaxHealthText;
    public Text enemyCurrentHealthText;
    public Transform damTextObj;
    public Image healthBar; //Put healthbarbar here
    public float enemyMaxHP = 100;
    public float enemyHP = 100;
    public static int enemyDarkPower = 10;
    public float enemyAttDamLow = 5;
    public float enemyAttDamHigh = 10;
    public static int enemyXP = 20;

    private float enemyAttDam = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemyMaxHP = Random.Range(200, 400);
        enemyAttDamLow = Random.Range(10, 20);
        enemyAttDamHigh = Random.Range(15, 25);
        if (enemyAttDamLow < enemyAttDamHigh)
        {
            enemyAttDamLow = enemyAttDamHigh;
        }
        enemyHP = enemyMaxHP;
        enemyMaxHealthText.text = enemyMaxHP.ToString();
        enemyCurrentHealthText.text = enemyHP.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (BattleFlow.whichTurn == 2)
        {
            BattleFlow.whichTurn = 0;
            enemyAttDam = Random.Range(enemyAttDamLow, enemyAttDamHigh + 1);
            BattleFlow.currentDamage = lightController.enemyLightDamageModify(enemyAttDam);
            GetComponent<Animator>().SetTrigger("EnemyMelee");
            StartCoroutine (enemyAttack());
        }

        if (BattleFlow.damageDisplayEnemy == true)
        {
            GetComponent<Animator>().SetTrigger("OnHit_Enemy");
            enemyHP -= BattleFlow.currentDamage;
            if (enemyHP < 0)
            {
                enemyHP = 0;
            }
            healthBar.fillAmount = (enemyHP / enemyMaxHP);
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
            enemyCurrentHealthText.text = Mathf.Round(enemyHP).ToString();
            Debug.Log(enemyHP);
            BattleFlow.damageDisplayEnemy = false;
        }

        if (enemyHP <= 0)
        {
            BattleFlow.battleWon = true;
            BattleFlow.playerTotalXP += enemyXP;
            Destroy(gameObject);
        }
    }

    IEnumerator enemyAttack()
    {
        GetComponent<Rigidbody>().velocity = new Vector2(-20, 0);
        yield return new WaitForSeconds(0.4f);
        GetComponent<Rigidbody>().velocity = new Vector2(0, 0);
        Instantiate(damTextObj, new Vector2(-6.2f, 1.0f), damTextObj.rotation);
        BattleFlow.damageDisplayKnight = true;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Rigidbody>().velocity = new Vector2(40, 0);
        yield return new WaitForSeconds(0.2f);
        GetComponent<Rigidbody>().velocity = new Vector2(0, 0);
        GetComponent<Transform>().position = new Vector2(4.63f, -0.12f);
        BattleFlow.whichTurn = 1;

        /*yield return new WaitForSeconds(0.4f);
        GetComponent<Rigidbody>().velocity = new Vector2(0, 0);
        GetComponent<Transform>().position = new Vector2(4.63f, -0.12f);
        BattleFlow.whichTurn = 1;*/
    }
}
