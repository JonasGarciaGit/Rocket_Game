using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroGame : MonoBehaviour
{
    public GameObject background;
    public GameObject starsBackground;
    public GameObject starsCollectable;
    public GameObject asteroidSpawner;
    public GameObject fuelSpawner;
    public GameObject platform;
    public GameObject clouds;
    public GameObject rocket;
    private GameObject vfxPropulsion;
    public GameObject powerUpSpawner;
    public Text stopWatch;
    private int stopWatchTime;
    public float introSpeed;
    private bool start;
    private float controlTimerTemp;
    [SerializeField]
    public AudioSource audioSource;
    [SerializeField]
    public AudioClip stopwatchClip;
    [SerializeField]
    public AudioClip rocketLaunchClip;

    public GameObject fuelBar;
    public GameObject fuelFill;
    public GameObject powerUpButton;
    public Material materialPowerUp;

    public GameObject buttonPowerUp;

    public Text bestScore;

    // Start is called before the first frame update
    void Start()
    {

        for (int i= 0; i < rocket.transform.childCount; i++)
        {
            string name = PlayerPrefs.GetString("Rocket_Equiped_Name");

            if ("".Equals(name))
            {
                name = "Rocket1";
            }

            if (name.Equals(rocket.transform.GetChild(i).gameObject.name))
            {
                rocket.transform.GetChild(i).gameObject.SetActive(true);
            }

            if (rocket.transform.GetChild(i).gameObject.active)
            {
                vfxPropulsion = rocket.transform.GetChild(i).Find("vfx_propulsion").gameObject;
                GameObject.Find("Rocket_Sculpt").GetComponent<RocketDestroy>().vfxPropulsion = vfxPropulsion;
            }
        }
        

        stopWatchTime = 10;
        stopWatch.text = "10";
        rocket.GetComponent<RocketMovementAcelerometer>().enabled = false;
        rocket.GetComponent<RocketMovement>().enabled = false;
        start = false;
        vfxPropulsion.SetActive(false);
        starsBackground.SetActive(false);
        starsCollectable.SetActive(false);
        asteroidSpawner.SetActive(false);
        fuelSpawner.SetActive(false);
        powerUpSpawner.SetActive(false);
        fuelBar.SetActive(false);
        fuelFill.SetActive(false);
        buttonPowerUp.SetActive(false);
        materialPowerUp.SetColor("Color_ba20f8732d69407d8e52f3d6041799d7",new Color(255,255,255,250) / 30);
        powerUpButton.SetActive(false);
        controlTimerTemp = rocket.GetComponent<Fuel>().controlTimer;
        rocket.GetComponent<Fuel>().controlTimer = 1000f;
        background.transform.position = new Vector3(background.transform.position.x,84f,50f);
        bestScore.text = PlayerPrefs.GetInt("Score").ToString();
        StartCoroutine("startGame");
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            StartCoroutine("downBackground");
        }

        if (background.transform.position.y <= -50)
        {
            starsBackground.SetActive(true);
            starsCollectable.SetActive(true);
            asteroidSpawner.SetActive(true);
            fuelSpawner.SetActive(true);
            powerUpSpawner.SetActive(true);
            fuelBar.SetActive(true);
            fuelFill.SetActive(true);
            powerUpButton.SetActive(true);
            buttonPowerUp.SetActive(true);
            rocket.GetComponent<Fuel>().controlTimer = controlTimerTemp;
        }
    }

    IEnumerator downBackground()
    {
        start = false;
        while (background.transform.position.y > -50)
        {
            yield return new WaitForSeconds(introSpeed);
            background.transform.position = new Vector3(background.transform.position.x, background.transform.position.y -1, 50f);
            platform.transform.position = new Vector2(platform.transform.position.x, platform.transform.position.y - 1);
            clouds.transform.position = new Vector2(clouds.transform.position.x, clouds.transform.position.y - 1f);
        }
    }

    IEnumerator startGame()
    {
        while (stopWatchTime != 0)
        {
            yield return new WaitForSeconds(1f);
            stopWatchTime = stopWatchTime - 1;
            stopWatch.text = stopWatchTime.ToString();
            audioSource.volume = 0.1f;
            audioSource.PlayOneShot(stopwatchClip);
        }

        if(stopWatchTime == 0)
        {
            start = true;
            audioSource.PlayOneShot(rocketLaunchClip);
            // rocket.GetComponent<RocketMovementAcelerometer>().enabled = true;
            rocket.GetComponent<RocketMovement>().enabled = true;
            vfxPropulsion.SetActive(true);
            stopWatch.enabled = false;
            Destroy(platform, 15f);
        }
    }

}


