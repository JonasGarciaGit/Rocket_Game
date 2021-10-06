using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolarStorm : MonoBehaviour
{
    
    public GameObject thermometerFill;
    public GameObject thermometer;
    public GameObject rocket;

    public GameObject ParticleEffetSolar;

    public Material powerUpSphere;
    public Button powerUpButton;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(rocket.GetComponent<Thermometer>().currentTemperature >= 100){
            closeSolarStormEvent();
        }

    }

    public void initializeSolarStorm(){
        thermometer.SetActive(true);
        thermometerFill.SetActive(true);
        rocket.GetComponent<Thermometer>().eventIsActive = true;
        rocket.GetComponent<Fuel>().decaySpeed = -20;
        ParticleEffetSolar.SetActive(true);
        powerUpSphere.SetColor("Color_ba20f8732d69407d8e52f3d6041799d7",new Color(255,12,0,250));
        powerUpButton.GetComponentInParent<MenuController>().isEventSolarOn = true;
    }

    public void closeSolarStormEvent(){
        rocket.GetComponent<Thermometer>().currentTemperature = 0;
        rocket.GetComponent<Thermometer>().ModifyTemperature(-100);
        thermometer.SetActive(false);
        thermometerFill.SetActive(false);
        rocket.GetComponent<Thermometer>().eventIsActive = false;
        rocket.GetComponent<Fuel>().decaySpeed = -10;
        ParticleEffetSolar.SetActive(false);
        powerUpSphere.SetColor("Color_ba20f8732d69407d8e52f3d6041799d7",new Color(255,255,255,250) / 30);
        powerUpButton.GetComponentInParent<MenuController>().isEventSolarOn = false;
        this.gameObject.GetComponent<EventControlSystem>().hasStarted = false;
    }

}
