using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fuel : MonoBehaviour
{
    [SerializeField]
    private int maxFuel = 100;
    private int currentFuel;


    private float timer = 0f;
    [SerializeField]
    private float controlTimer;

    public event Action<float> OnFuelPctChanged = delegate {};


    private void OnEnable() {
        currentFuel = maxFuel;    
    }

    public void ModifyFuel(int amount){
        currentFuel += amount;

        float currentFuelPct = (float) currentFuel / (float) maxFuel;
        OnFuelPctChanged(currentFuelPct);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= controlTimer){
            ModifyFuel(-10);
            timer = 0f;
        }
           
    }
}
