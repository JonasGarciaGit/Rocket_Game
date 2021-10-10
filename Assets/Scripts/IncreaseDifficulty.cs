using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDifficulty : MonoBehaviour
{
    private int distance;
    public GameObject asteroidRespawn;
    public GameObject starDropping;
    public GameObject starBackground;
    public GameObject fuelDroppingSpeed;
    public GameObject backgroundRenderer;
    public List<Sprite> bkImages;
    private bool alreadyChanged;

    private Vector3 target;
    private Vector3 startPosition;
    private float timer;
    public float timeDistancePlanets;
    private float timeToReachTarget;


    private void Start()
    {
        distance = 0;
        StartCoroutine("increaseDistance");
        alreadyChanged = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (distance == 1)
        {
            if (alreadyChanged == false)
            {
                backgroundRenderer.gameObject.SetActive(true);
                backgroundRenderer.gameObject.transform.position = new Vector3(-3.3f, 80f, 45f);
                backgroundRenderer.GetComponent<SpriteRenderer>().sprite = bkImages[0];
                startPosition = backgroundRenderer.transform.position;
                target = new Vector3(backgroundRenderer.transform.position.x, -50f, backgroundRenderer.transform.position.z);
                timeToReachTarget = timeDistancePlanets;
                alreadyChanged = true;
            }

            timer += Time.deltaTime / timeToReachTarget;
            backgroundRenderer.transform.position = Vector3.Lerp(startPosition, target, timer);

            if (backgroundRenderer.transform.position == target)
            {
                cleanValues();
            }

        }
        else if (distance == 2)
        {
            if (alreadyChanged == false)
            {
                backgroundRenderer.GetComponent<SpriteRenderer>().flipX = true;
                backgroundRenderer.gameObject.transform.position = new Vector3(-3.3f, 80f, 45f);
                backgroundRenderer.GetComponent<SpriteRenderer>().sprite = bkImages[1];
                startPosition = backgroundRenderer.transform.position;
                target = new Vector3(backgroundRenderer.transform.position.x, -50f, backgroundRenderer.transform.position.z);
                timeToReachTarget = timeDistancePlanets;
                alreadyChanged = true;
            }

            timer += Time.deltaTime / timeToReachTarget;
            backgroundRenderer.transform.position = Vector3.Lerp(startPosition, target, timer);


            if (backgroundRenderer.transform.position == target)
            {
                cleanValues();
            }

        }
        else if (distance == 3)
        {
            if (alreadyChanged == false)
            {
                backgroundRenderer.GetComponent<SpriteRenderer>().flipX = false;
                backgroundRenderer.gameObject.transform.position = new Vector3(16f, 80f, 45f);
                backgroundRenderer.GetComponent<SpriteRenderer>().sprite = bkImages[2];
                startPosition = backgroundRenderer.transform.position;
                target = new Vector3(backgroundRenderer.transform.position.x, -50f, backgroundRenderer.transform.position.z);
                timeToReachTarget = timeDistancePlanets;
                alreadyChanged = true;
            }

            timer += Time.deltaTime / timeToReachTarget;
            backgroundRenderer.transform.position = Vector3.Lerp(startPosition, target, timer);


            if (backgroundRenderer.transform.position == target)
            {
                cleanValues();
            }

        }
        else if (distance == 4)
        {
            if (alreadyChanged == false)
            {
                backgroundRenderer.gameObject.transform.position = new Vector3(-9.8f, 80f, 45f);
                backgroundRenderer.GetComponent<SpriteRenderer>().sprite = bkImages[3];
                startPosition = backgroundRenderer.transform.position;
                target = new Vector3(backgroundRenderer.transform.position.x, -50f, backgroundRenderer.transform.position.z);
                timeToReachTarget = timeDistancePlanets;
                alreadyChanged = true;
            }

            timer += Time.deltaTime / timeToReachTarget;
            backgroundRenderer.transform.position = Vector3.Lerp(startPosition, target, timer);


            if (backgroundRenderer.transform.position == target)
            {
                cleanValues();
            }

        }
        else if (distance == 5)
        {
            if (alreadyChanged == false)
            {
                backgroundRenderer.gameObject.transform.position = new Vector3(-9.8f, 80f, 45f);
                backgroundRenderer.GetComponent<SpriteRenderer>().sprite = bkImages[4];
                startPosition = backgroundRenderer.transform.position;
                target = new Vector3(backgroundRenderer.transform.position.x, -50f, backgroundRenderer.transform.position.z);
                timeToReachTarget = timeDistancePlanets;
                alreadyChanged = true;
            }

            timer += Time.deltaTime / timeToReachTarget;
            backgroundRenderer.transform.position = Vector3.Lerp(startPosition, target, timer);


            if (backgroundRenderer.transform.position == target)
            {
                cleanValues();
            }
        }
        else if (distance == 6)
        {
            if(alreadyChanged == false)
            {
                backgroundRenderer.gameObject.transform.position = new Vector3(-3.3f, 80f, 45f);
                backgroundRenderer.GetComponent<SpriteRenderer>().sprite = bkImages[5];
                startPosition = backgroundRenderer.transform.position;
                target = new Vector3(backgroundRenderer.transform.position.x, -50f, backgroundRenderer.transform.position.z);
                timeToReachTarget = timeDistancePlanets;
                alreadyChanged = true;
            }

            timer += Time.deltaTime / timeToReachTarget;
            backgroundRenderer.transform.position = Vector3.Lerp(startPosition, target, timer);
        }


    }

    IEnumerator increaseDistance()
    {
        while (distance != 7)
        {
            yield return new WaitForSeconds(timeDistancePlanets);
            distance = distance + 1;

            asteroidRespawn.GetComponent<AsteroidSpawner>().respawnTime = asteroidRespawn.GetComponent<AsteroidSpawner>().respawnTime - 0.02f;
            starDropping.GetComponent<ParticleSystem>().playbackSpeed = starDropping.GetComponent<ParticleSystem>().playbackSpeed + 0.2f;
            starBackground.GetComponent<ParticleSystem>().playbackSpeed = starBackground.GetComponent<ParticleSystem>().playbackSpeed + 0.2f;
            fuelDroppingSpeed.GetComponent<FuelRespawn>().instanceSpeed = fuelDroppingSpeed.GetComponent<FuelRespawn>().instanceSpeed - 0.1f;

        }
    }

    private void cleanValues()
    {
        startPosition = new Vector3();
        target = new Vector3();
        timeToReachTarget = 0f;
        timer = 0f;
        backgroundRenderer.GetComponent<SpriteRenderer>().sprite = null;
        backgroundRenderer.gameObject.transform.position = new Vector3();
        alreadyChanged = false;
    }


}
