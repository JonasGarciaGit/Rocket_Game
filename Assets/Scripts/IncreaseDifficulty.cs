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

    private void Start()
    {
        distance = 0;
        StartCoroutine("increaseDistance");
    }

    // Update is called once per frame
    void Update()
    {
      

        if (distance == 1)
        {
            asteroidRespawn.GetComponent<AsteroidSpawner>().respawnTime = 0.68f;
            starDropping.GetComponent<ParticleSystem>().playbackSpeed = 1.2f;
            starBackground.GetComponent<ParticleSystem>().playbackSpeed = 2.2f;
            fuelDroppingSpeed.GetComponent<FuelRespawn>().instanceSpeed = 4.9f;
        }
        else if (distance == 2)
        {
            asteroidRespawn.GetComponent<AsteroidSpawner>().respawnTime = 0.66f;
            starDropping.GetComponent<ParticleSystem>().playbackSpeed = 1.4f;
            starBackground.GetComponent<ParticleSystem>().playbackSpeed = 2.4f;
            fuelDroppingSpeed.GetComponent<FuelRespawn>().instanceSpeed = 4.8f;
        }
        else if (distance == 3)
        {
            asteroidRespawn.GetComponent<AsteroidSpawner>().respawnTime = 0.64f;
            starDropping.GetComponent<ParticleSystem>().playbackSpeed = 1.6f;
            starBackground.GetComponent<ParticleSystem>().playbackSpeed = 2.6f;
            fuelDroppingSpeed.GetComponent<FuelRespawn>().instanceSpeed = 4.7f;
        }
        else if (distance == 4)
        {
            asteroidRespawn.GetComponent<AsteroidSpawner>().respawnTime = 0.62f;
            starDropping.GetComponent<ParticleSystem>().playbackSpeed = 1.8f;
            starBackground.GetComponent<ParticleSystem>().playbackSpeed = 2.8f;
            fuelDroppingSpeed.GetComponent<FuelRespawn>().instanceSpeed = 4.6f;
        }
        else if (distance == 5)
        {
            asteroidRespawn.GetComponent<AsteroidSpawner>().respawnTime = 0.6f;
            starDropping.GetComponent<ParticleSystem>().playbackSpeed = 2f;
            starBackground.GetComponent<ParticleSystem>().playbackSpeed = 3f;
            fuelDroppingSpeed.GetComponent<FuelRespawn>().instanceSpeed = 4.5f;
        }
        else if (distance == 6)
        {
            asteroidRespawn.GetComponent<AsteroidSpawner>().respawnTime = 0.58f;
            starDropping.GetComponent<ParticleSystem>().playbackSpeed = 2.2f;
            starBackground.GetComponent<ParticleSystem>().playbackSpeed = 3.2f;
            fuelDroppingSpeed.GetComponent<FuelRespawn>().instanceSpeed = 4.4f;
        }
        else if (distance == 7)
        {
            asteroidRespawn.GetComponent<AsteroidSpawner>().respawnTime = 0.56f;
            starDropping.GetComponent<ParticleSystem>().playbackSpeed = 2.4f;
            starBackground.GetComponent<ParticleSystem>().playbackSpeed = 3.4f;
            fuelDroppingSpeed.GetComponent<FuelRespawn>().instanceSpeed = 4.3f;
        
        }
        else if (distance == 8)
        {
            asteroidRespawn.GetComponent<AsteroidSpawner>().respawnTime = 0.54f;
            starDropping.GetComponent<ParticleSystem>().playbackSpeed = 2.6f;
            starBackground.GetComponent<ParticleSystem>().playbackSpeed = 3.6f;
            fuelDroppingSpeed.GetComponent<FuelRespawn>().instanceSpeed = 4.2f;
          
        }
        else if (distance == 9)
        {
            asteroidRespawn.GetComponent<AsteroidSpawner>().respawnTime = 0.52f;
            starDropping.GetComponent<ParticleSystem>().playbackSpeed = 2.8f;
            starBackground.GetComponent<ParticleSystem>().playbackSpeed = 3.8f;
            fuelDroppingSpeed.GetComponent<FuelRespawn>().instanceSpeed = 4.1f;

        }
    }

    IEnumerator increaseDistance()
    {
        while(distance != 9)
        {
            yield return new WaitForSeconds(120f);
            this.distance = this.distance + 1;
            Debug.Log("asteroid speed .: " + asteroidRespawn.GetComponent<AsteroidSpawner>().respawnTime);
            Debug.Log("starDropping speed .: " + starDropping.GetComponent<ParticleSystem>().playbackSpeed);
            Debug.Log("starBackground speed .: " + starBackground.GetComponent<ParticleSystem>().playbackSpeed);
            Debug.Log("fuel speed .: " + fuelDroppingSpeed.GetComponent<FuelRespawn>().instanceSpeed);
        }
    }
}
