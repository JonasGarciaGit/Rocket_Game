using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauronEyeEvent : MonoBehaviour
{

    public GameObject sauronEye;
    public ParticleAttract particleAttract; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startSauronEyeEvent()
    {
        sauronEye.SetActive(true);
        particleAttract.sauronEyeIsUp = true;
    }

    public void finishSauronEyeEvent()
    {
        StartCoroutine(sauronDuration());
    }


    IEnumerator sauronDuration()
    {
        yield return new WaitForSeconds(20f);
        particleAttract.sauronEyeIsUp = false;
        sauronEye.SetActive(false);
        this.gameObject.GetComponent<EventControlSystem>().hasStarted = false;
        particleAttract.speed = 0f;
    }
}
