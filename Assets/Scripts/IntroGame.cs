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
    public GameObject rocket;
    public GameObject vfxPropulsion;
    public Text stopWatch;
    private int stopWatchTime;
    public float introSpeed;
    private bool start;

    // Start is called before the first frame update
    void Start()
    {
        stopWatchTime = 10;
        stopWatch.text = "10";
        rocket.GetComponent<RocketMovementAcelerometer>().enabled = false;
        start = false;
        vfxPropulsion.SetActive(false);
        starsBackground.SetActive(false);
        starsCollectable.SetActive(false);
        asteroidSpawner.SetActive(false);
        fuelSpawner.SetActive(false);
        background.transform.position = new Vector3(background.transform.position.x,84f,12);
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
        }
    }

    IEnumerator downBackground()
    {
        start = false;
        while (background.transform.position.y > -50)
        {
            yield return new WaitForSeconds(introSpeed);
            background.transform.position = new Vector3(background.transform.position.x, background.transform.position.y -1, 12);
            platform.transform.position = new Vector2(platform.transform.position.x, platform.transform.position.y - 1);
        }
    }

    IEnumerator startGame()
    {
        while (stopWatchTime != 0)
        {
            yield return new WaitForSeconds(1f);
            stopWatchTime = stopWatchTime - 1;
            stopWatch.text = stopWatchTime.ToString();
        }

        if(stopWatchTime == 0)
        {
            start = true;
            rocket.GetComponent<RocketMovementAcelerometer>().enabled = true;
            vfxPropulsion.SetActive(true);
            stopWatch.enabled = false;
        }
    }

}


