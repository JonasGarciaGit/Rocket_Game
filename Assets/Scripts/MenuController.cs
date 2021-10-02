using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuController : MonoBehaviour
{

    public Toggle musicToggleControl;
    public Sprite musicTurnOn;
    public Sprite musicTurnOff; 

    public GameObject rocket;
    public float powerUpDuration;

    public GameObject floatingText;

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

    public void onClickPowerUp(GameObject powerUpSlot){
        try{

            Transform powerUp = powerUpSlot.transform.GetChild(0);
            Debug.Log(powerUp.name);

            if("shieldPowerUp(Clone)".Equals(powerUp.name)){
                showFloatingText("Shield up!");
                rocket.GetComponent<Collectable>().havePowerUp = false;
                GameObject shield = Instantiate(powerUp.gameObject,rocket.transform.position,Quaternion.identity);
                shield.transform.parent = rocket.transform;
                shield.transform.localScale = new Vector3(9f, 9f, 9f);
                shield.GetComponent<SphereCollider>().isTrigger = false;
                StartCoroutine(waitForSecondsPowerUpShield(shield));
            }

            if("powerUpX2(Clone)".Equals(powerUp.name)){
                showFloatingText("x2 Starts!");
                rocket.GetComponent<Collectable>().havePowerUp = false;
                StartCoroutine(waitForSecondsX2Star(10f));
            }


            Destroy(powerUp.gameObject);
        }catch{
           Debug.Log("Erro ao intanciar");
        }

     
    }

    public void controlMusic(){
        if(musicToggleControl.isOn == true){
            musicToggleControl.GetComponentInChildren<Image>().sprite = musicTurnOn;
        }else{
            musicToggleControl.GetComponentInChildren<Image>().sprite = musicTurnOff;
        }
    }

    IEnumerator waitForSecondsPowerUpShield(GameObject powerUp){
        yield return new WaitForSeconds(powerUpDuration);
        Destroy(powerUp);
    }

    IEnumerator waitForSecondsX2Star(float time){
        rocket.GetComponent<Collectable>().startCollectedNumber = 2;
        yield return new WaitForSeconds(time);
        rocket.GetComponent<Collectable>().startCollectedNumber = 1;
    }

    void showFloatingText(string text){
        var textFloating = Instantiate(floatingText, rocket.transform.position, Quaternion.identity, rocket.transform);
        textFloating.GetComponent<TextMesh>().text = text;
        Destroy(textFloating,0.7f);
    }
}
