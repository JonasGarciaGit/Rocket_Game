using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public Toggle musicToggleControl;
    public Sprite musicTurnOn;
    public Sprite musicTurnOff; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickStart(){
        SceneManager.LoadScene("Fuel_System", LoadSceneMode.Additive);
    }

    public void onClickShop(){
        Debug.Log("Cliquei no botao shop");
    }

    public void onClickHowPlay(){
        Debug.Log("Cliquei no botao de como jogar");
    }

    public void controlMusic(){
        if(musicToggleControl.isOn == true){
            musicToggleControl.GetComponentInChildren<Image>().sprite = musicTurnOn;
        }else{
            musicToggleControl.GetComponentInChildren<Image>().sprite = musicTurnOff;
        }
    }
}
