using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Thermometer : MonoBehaviour
{
     [SerializeField]
    private int maxOverload = 100;
    public int currentTemperature;

    public bool eventIsActive = false;

    private float timer = 0f;
    
    public float controlTimer;

    public event Action<float> OnTemperaturePctChanged = delegate {};


    private void OnEnable() {
        currentTemperature = 0;    
    }

    public void ModifyTemperature(int amount){
        currentTemperature += amount;

        float currentTemperaturePct = (float) currentTemperature / (float) maxOverload;
        OnTemperaturePctChanged(currentTemperaturePct);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= controlTimer && eventIsActive){
            ModifyTemperature(+10);
            timer = 0f;
        }
           
    }
}
