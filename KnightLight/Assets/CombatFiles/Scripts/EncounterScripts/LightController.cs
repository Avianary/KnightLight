using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{


    public Image lightBar;
    public Image darkEverything;
    public Image darkCharacters;

    public static float maxLightLevel = 100;
    public static float currentLightLevel = 80;

    private float lightIncrement;
    private float lightAlphaValue;
    public float baseLightDamageMultiplier = 1f; //1 = enemy deals 100% damage at max light, 200% at no light. 2 = 200% at max, 400% at no. etc.
    public float lightDamageMultiplier = 1f; 

    public static bool lightDecrease = false;
    public static bool lightIncrease = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Completed.GameManager.instance != null)
        {
            lightDamageMultiplier = baseLightDamageMultiplier +  ((float)Completed.GameManager.instance.GetLevel() / 10);
            Debug.Log((float)Completed.GameManager.instance.GetLevel());
            currentLightLevel = Completed.GameManager.instance.playerFoodPoints;
            //If the main game scene has already been loaded, make enemies deal more light based damage depending on level
            //And set light level to light level from the main game scene
        }
        lightIncrement = 1f / maxLightLevel;
        Debug.Log("Increment = " + lightIncrement + "MaxLight = " + maxLightLevel);
        lightBar.fillAmount = currentLightLevel / maxLightLevel;

        lightAlphaValue = 1 - ((currentLightLevel * lightIncrement));
        darkEverything.color = new Vector4(0, 0, 0, lightAlphaValue / 6);
        darkCharacters.color = new Vector4(0, 0, 0, lightAlphaValue / 3);
    }

    public float enemyLightDamageModify(float enemyDamage)
    {
        float percentLightMissing = ((maxLightLevel - currentLightLevel) / maxLightLevel ) * 100;

        float modifiedEnemyDamage = enemyDamage * ((percentLightMissing / 100) + 0.3f) * lightDamageMultiplier;
        Debug.Log(enemyDamage + " Enemy Damage " + "Percentlightmissing " + percentLightMissing + " LightDamMult: " + lightDamageMultiplier);
        Debug.Log(modifiedEnemyDamage + " Modified Enemy Damage");
        return modifiedEnemyDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if (lightIncrease == true || lightDecrease == true)
        {
            if (lightIncrease == true)
            {
                lightIncrease = false;
                if (currentLightLevel + KnightControl.lightPower > maxLightLevel)
                {
                    currentLightLevel = maxLightLevel;
                }
                else if (currentLightLevel < maxLightLevel)
                {
                    currentLightLevel = currentLightLevel + KnightControl.lightPower;
                }
                else
                {
                    Debug.Log("Light level already maximum");
                }
            }
            else
            {
                lightDecrease = false;
                currentLightLevel -= EnemyController.enemyDarkPower;
                if (currentLightLevel < 0)
                {
                    currentLightLevel = 0;
                }

            }
            lightAlphaValue = 1 - ((currentLightLevel * lightIncrement));
            Debug.Log("alpha" + lightAlphaValue + "Current" + currentLightLevel + "Increment" + lightIncrement);
            darkEverything.color = new Vector4(0, 0, 0, lightAlphaValue / 6);
            darkCharacters.color = new Vector4(0, 0, 0, lightAlphaValue / 3);
            lightBar.fillAmount = currentLightLevel / maxLightLevel;
        }
    }
}
