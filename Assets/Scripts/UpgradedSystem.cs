using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradedSystem : MonoBehaviour
{
    [SerializeField]
    private Button shieldUpgradedUp;

    [SerializeField]
    private Button magnetismUpgradedUp;

    [SerializeField]
    private Button x2UpgradedUp;

    [SerializeField]
    private Image[] slotsShield;

    [SerializeField]
    private Image[] slotsMagnetism;

    [SerializeField]
    private Image[] slotsX2Stars;

    [SerializeField]
    private Sprite upgradeButtonFill;

    [SerializeField] Text starsCoinShield;
    [SerializeField] Text starsCoinMagnetism;
    [SerializeField] Text starsCoinX2;

    [SerializeField] Text actualStars;

   

    void Start()
    {
        actualStars.text = getActualStars().ToString();
        verifyUpgradeShield();
        verifyUpgradedMag();
        verifyUpgradedX2();
    }

    
    void Update()
    {
        
    }

    public void onClickShieldUp()
    {
        int stars = getActualStars();
        int priceStars = 0;

        if (!"MAX LEVEL".Equals(starsCoinShield.text))
        {
            priceStars = int.Parse(starsCoinShield.text);
        }
        
        
        if (stars >= priceStars && priceStars != 0)
        {
           int actualLevel = PlayerPrefs.GetInt("UpgradeShieldLevel");

           if(actualLevel < 4)
            {
                actualLevel += 1;
                int newStarsAmount = stars - priceStars;
                setActualStars(newStarsAmount);
                actualStars.text = getActualStars().ToString();
                PlayerPrefs.SetInt("UpgradeShieldLevel", actualLevel);
                verifyUpgradeShield();
            }
           
        }
    }

    public void onClickMagnetismUp()
    {

        int stars = getActualStars();
        int priceStars = 0;

        if (!"MAX LEVEL".Equals(starsCoinMagnetism.text))
        {
            priceStars = int.Parse(starsCoinMagnetism.text);
        }


        if (stars >= priceStars && priceStars != 0)
        {
            int actualLevel = PlayerPrefs.GetInt("UpgradeMagLevel");

            if (actualLevel < 4)
            {
                actualLevel += 1;
                int newStarsAmount = stars - priceStars;
                setActualStars(newStarsAmount);
                actualStars.text = getActualStars().ToString();
                PlayerPrefs.SetInt("UpgradeMagLevel", actualLevel);
                verifyUpgradedMag();
            }

        }

    }

    public void onClickX2StarsUp()
    {
        int stars = getActualStars();
        int priceStars = 0;

        if (!"MAX LEVEL".Equals(starsCoinX2.text))
        {
            priceStars = int.Parse(starsCoinX2.text);
        }


        if (stars >= priceStars && priceStars != 0)
        {
            int actualLevel = PlayerPrefs.GetInt("UpgradeX2Level");

            if (actualLevel < 4)
            {
                actualLevel += 1;
                int newStarsAmount = stars - priceStars;
                setActualStars(newStarsAmount);
                actualStars.text = getActualStars().ToString();
                PlayerPrefs.SetInt("UpgradeX2Level", actualLevel);
                verifyUpgradedX2();
            }

        }
    }

    public void verifyUpgradeShield()
    {
      int actualLevelShield = PlayerPrefs.GetInt("UpgradeShieldLevel") == 0 ? 0 : PlayerPrefs.GetInt("UpgradeShieldLevel");

        if(actualLevelShield == 0)
        {
     
            starsCoinShield.text = "500";

        }else if(actualLevelShield == 1)
        {
            slotsShield[0].sprite = upgradeButtonFill;
            starsCoinShield.text = "1000";
        }
        else if (actualLevelShield == 2)
        {
            slotsShield[0].sprite = upgradeButtonFill;
            slotsShield[1].sprite = upgradeButtonFill;
            starsCoinShield.text = "1500";
        }
        else if (actualLevelShield == 3)
        {
            slotsShield[0].sprite = upgradeButtonFill;
            slotsShield[1].sprite = upgradeButtonFill;
            slotsShield[2].sprite = upgradeButtonFill;
            starsCoinShield.text = "2000";
        }else if(actualLevelShield == 4)
        {
            slotsShield[0].sprite = upgradeButtonFill;
            slotsShield[1].sprite = upgradeButtonFill;
            slotsShield[2].sprite = upgradeButtonFill;
            slotsShield[3].sprite = upgradeButtonFill;
            starsCoinShield.text = "MAX LEVEL";
        }
    }

    public void verifyUpgradedMag()
    {
        int actualLevelMag = PlayerPrefs.GetInt("UpgradeMagLevel") == 0 ? 0 : PlayerPrefs.GetInt("UpgradeMagLevel");

        if (actualLevelMag == 0)
        {

            starsCoinMagnetism.text = "500";

        }
        else if (actualLevelMag == 1)
        {
            slotsMagnetism[0].sprite = upgradeButtonFill;
            starsCoinMagnetism.text = "1000";
        }
        else if (actualLevelMag == 2)
        {
            slotsMagnetism[0].sprite = upgradeButtonFill;
            slotsMagnetism[1].sprite = upgradeButtonFill;
            starsCoinMagnetism.text = "1500";
        }
        else if (actualLevelMag == 3)
        {
            slotsMagnetism[0].sprite = upgradeButtonFill;
            slotsMagnetism[1].sprite = upgradeButtonFill;
            slotsMagnetism[2].sprite = upgradeButtonFill;
            starsCoinMagnetism.text = "2000";
        }
        else if (actualLevelMag == 4)
        {
            slotsMagnetism[0].sprite = upgradeButtonFill;
            slotsMagnetism[1].sprite = upgradeButtonFill;
            slotsMagnetism[2].sprite = upgradeButtonFill;
            slotsMagnetism[3].sprite = upgradeButtonFill;
            starsCoinMagnetism.text = "MAX LEVEL";
        }
    }

    public void verifyUpgradedX2()
    {
        int actualLevelX2 = PlayerPrefs.GetInt("UpgradeX2Level") == 0 ? 0 : PlayerPrefs.GetInt("UpgradeX2Level");

        if (actualLevelX2 == 0)
        {

            starsCoinX2.text = "500";

        }
        else if (actualLevelX2 == 1)
        {
            slotsX2Stars[0].sprite = upgradeButtonFill;
            starsCoinX2.text = "1000";
        }
        else if (actualLevelX2 == 2)
        {
            slotsX2Stars[0].sprite = upgradeButtonFill;
            slotsX2Stars[1].sprite = upgradeButtonFill;
            starsCoinX2.text = "1500";
        }
        else if (actualLevelX2 == 3)
        {
            slotsX2Stars[0].sprite = upgradeButtonFill;
            slotsX2Stars[1].sprite = upgradeButtonFill;
            slotsX2Stars[2].sprite = upgradeButtonFill;
            starsCoinX2.text = "2000";
        }
        else if (actualLevelX2 == 4)
        {
            slotsX2Stars[0].sprite = upgradeButtonFill;
            slotsX2Stars[1].sprite = upgradeButtonFill;
            slotsX2Stars[2].sprite = upgradeButtonFill;
            slotsX2Stars[3].sprite = upgradeButtonFill;
            starsCoinX2.text = "MAX LEVEL";
        }
    }

    private int getActualStars()
    {
        int stars = PlayerPrefs.GetInt("Stars");
        return stars;
    }

    private void setActualStars(int stars)
    {
        PlayerPrefs.SetInt("Stars", stars);
    }
}
