using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelControlBar : MonoBehaviour
{

    [SerializeField]
    private Image foregroundImage;
    [SerializeField]
    private float updateSpeedSeconds = 0.5f;

    public GameObject rocket;

    private void Awake() {
        rocket.GetComponentInParent<Fuel>().OnFuelPctChanged += HandleFuelChanged;    
    }

    private void HandleFuelChanged(float pct){
        StartCoroutine(ChangeToPct(pct));
    }

    private IEnumerator ChangeToPct(float pct){
        float preChangePct = foregroundImage.fillAmount;
        float elapsed = 0f;

        while(elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            foregroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }
    foregroundImage.fillAmount = pct;
    }
}
