using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fuel : MonoBehaviour
{
    [SerializeField]
    private int maxFuel = 100;
    [SerializeField]
    private int currentFuel;

    public int decaySpeed;

    private float timer = 0f;
    
    public float controlTimer;

    public event Action<float> OnFuelPctChanged = delegate {};


    private void OnEnable() {
        currentFuel = maxFuel;
        decaySpeed = -10;    
    }

    public void ModifyFuel(int amount){

            currentFuel += amount;

        if(currentFuel >= maxFuel)
        {
            currentFuel = maxFuel;
        }

        float currentFuelPct = (float)currentFuel / (float)maxFuel;
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
            ModifyFuel(decaySpeed);
            timer = 0f;
        }
        
        if(currentFuel <= 0){
            this.gameObject.GetComponent<RocketDestroy>().onDie();
        }
    }
}
