using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NebulaEvent : MonoBehaviour
{
    public GameObject nebulosaEffect;


    public void startNebulaEffect()
    {
        nebulosaEffect.SetActive(true);
        ParticleSystem.EmissionModule emission = nebulosaEffect.GetComponentInChildren<ParticleSystem>().emission;
        emission.rateOverTime = 10;
    }

    public void finishNebulaEffect()
    {

        StartCoroutine(reduceEmission());

    }

    IEnumerator reduceEmission()
    {
        yield return new WaitForSeconds(20f);
        ParticleSystem.EmissionModule emission = nebulosaEffect.GetComponentInChildren<ParticleSystem>().emission;
        emission.rateOverTime = 0;
        yield return new WaitForSeconds(5f);
        this.gameObject.GetComponent<EventControlSystem>().hasStarted = false;
    }
}
