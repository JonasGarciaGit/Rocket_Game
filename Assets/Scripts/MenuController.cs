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

    public GameObject shopInterface;

    public Text starsAmount;

    public GameObject [] rocketsPrefabs;
    public int [] rocketsPrice;

    public GameObject rocketSlot;

    [SerializeField]
    private Text rocketPrice;

    private int controlRocketList;

    public GameObject startButton;
    public GameObject shopButton;
    public GameObject howPlayButton;

    public GameObject buyButton;
    public GameObject equipButton;
    private GameObject rocketModel; 

    public Button powerUpBt;
    public GameObject starsParticle;

    public bool isEventSolarOn = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickArrowRight(){
        if(controlRocketList < rocketsPrefabs.Length - 1){
            controlRocketList += 1;
        }else{
            controlRocketList = 0;
        }
        loadRocketModel();

        Debug.Log(controlRocketList);
    }

    public void onClickArrowLeft(){
        controlRocketList -= 1;

        if(controlRocketList < 0){
            controlRocketList = rocketsPrefabs.Length - 1;
        }
        
        loadRocketModel();

        Debug.Log(controlRocketList);
    }


    public void onClickBuy(){

       int myPoints  = PlayerPrefs.GetInt("Stars");
       int rocketValue = rocketsPrice[controlRocketList];
       float finalValue = Mathf.Round(myPoints - rocketValue);
        if(finalValue >= 0){
            Debug.Log("Compra efetuada com sucesso");
            buyButton.SetActive(false);
            equipButton.SetActive(true);
            PlayerPrefs.SetString("Rocket_Number_" + rocketsPrefabs[controlRocketList], "Purchased");
            PlayerPrefs.SetInt("Stars", (int) finalValue);
            loadStarsAmount();
        }else{
            Debug.Log("Saldo insuficiente");
        }

    }

    public void onClickEquip(){
        Debug.Log("Euip button pressionado");
    }

    public void onClickStart(){
        SceneManager.LoadSceneAsync("Scene_Merging");
    }

    public void onClickShop(){
        shopInterface.SetActive(true);
        startButton.SetActive(false);
        howPlayButton.SetActive(false);
        shopButton.SetActive(false);
        controlRocketList = 0;
        loadRocketModel();
        loadStarsAmount();
    }

    public void closeInterface(GameObject uiGame){
        uiGame.SetActive(false);
        startButton.SetActive(true);
        howPlayButton.SetActive(true);
        shopButton.SetActive(true);
        try{
            Destroy(rocketModel);
        }catch{

        }
        
    }

    public void onClickHowPlay(){
        Debug.Log("Cliquei no botao de como jogar");
    }

    public void onClickPowerUp(GameObject powerUpSlot){
        try{

            if(!isEventSolarOn){

            Transform powerUp = powerUpSlot.transform.GetChild(0);


            if("shieldPowerUp(Clone)(Clone)".Equals(powerUp.name)){
                showFloatingText("Shield up!");
                rocket.GetComponent<Collectable>().havePowerUp = false;
                GameObject shield = Instantiate(powerUp.gameObject,rocket.transform.position,Quaternion.identity);
                shield.transform.parent = rocket.transform;
                shield.transform.localScale = new Vector3(9f, 9f, 9f);
                shield.GetComponent<SphereCollider>().isTrigger = false;
                StartCoroutine(waitForSecondsPowerUpShield(shield));
            }

            if("powerUpX2(Clone)(Clone)".Equals(powerUp.name)){
                showFloatingText("x2 Starts!");
                rocket.GetComponent<Collectable>().havePowerUp = false;
                StartCoroutine(waitForSecondsX2Star(10f));
            }

            if("MagnecticItem(Clone)(Clone)".Equals(powerUp.name)){
                showFloatingText("Magnetism up!");
                rocket.GetComponent<Collectable>().havePowerUp = false;
                StartCoroutine(waitForSecondsMagnetism());
            }


            Destroy(powerUp.gameObject);

            } else {
                showFloatingText("Can't use yet");
            }


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
        rocket.GetComponent<AsteroidCollision>().shieldIsUp = true;
        yield return new WaitForSeconds(powerUpDuration);
        rocket.GetComponent<AsteroidCollision>().shieldIsUp = false;
        Destroy(powerUp);
    }

    IEnumerator waitForSecondsX2Star(float time){
        rocket.GetComponent<Collectable>().startCollectedNumber = 2;
        yield return new WaitForSeconds(time);
        rocket.GetComponent<Collectable>().startCollectedNumber = 1;
    }

    IEnumerator waitForSecondsMagnetism(){
        starsParticle.GetComponent<ParticleAttract>().speed =  5f;
        yield return new WaitForSeconds(10f);
        starsParticle.GetComponent<ParticleAttract>().speed =  0f;
    }

    void showFloatingText(string text){
        var textFloating = Instantiate(floatingText, rocket.transform.position, Quaternion.identity, rocket.transform);
        textFloating.GetComponent<TextMesh>().text = text;
        Destroy(textFloating,0.7f);
    }

    void loadStarsAmount(){
        int stars = PlayerPrefs.GetInt("Stars");
        starsAmount.text = stars.ToString();
    }

    void loadRocketModel(){
        try{
            Destroy(rocketModel);
        }catch{

        }
        string purchasedConfirmation = PlayerPrefs.GetString("Rocket_Number_" + rocketsPrefabs[controlRocketList]);

        if(purchasedConfirmation.Equals("Purchased")){
            buyButton.SetActive(false);
            equipButton.SetActive(true);
        }else{
            buyButton.SetActive(true);
            equipButton.SetActive(false);
        }

        rocketModel = Instantiate(rocketsPrefabs[controlRocketList], rocketSlot.transform.position, Quaternion.identity);
        rocketModel.transform.localScale = new Vector3(3,3,3);
        rocketModel.AddComponent<SimpleRotateObject>();
        rocketPrice.text = rocketsPrice[controlRocketList].ToString();
    }

}
