using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventControlSystem : MonoBehaviour
{
    private int choseEvent;        
    public bool hasStarted = false;

    public float startEventTimer = 400f;
    private float timer = 0f;

    [SerializeField]
    private int numberEvents;

    [SerializeField]
    private GameObject floatingTextEvent;

    void Start()
    {
        
    }

    void Update()
    {

        if(!hasStarted){
            timer += Time.deltaTime;
            int last10sec = Mathf.RoundToInt(startEventTimer - timer);
            
            if(last10sec <= 10){

                floatingTextEvent.SetActive(true);
                floatingTextEvent.GetComponent<TextMesh>().text = "Event start in " + last10sec + " sec"; 
            }  
        }

        if(timer >= startEventTimer && hasStarted == false){
            

            int randomEvent = Random.Range(0,numberEvents);

            if(randomEvent == 0){
                this.gameObject.GetComponent<SolarStorm>().initializeSolarStorm();
                hasStarted = true;
                timer = 0f;
                floatingTextEvent.SetActive(false);
            }else{
                Debug.Log("Nenhum evento selecionado");
            }

        }






    }
}
