using System.Collections;
using UnityEngine;
using System;
using System.Collections.Generic;

public class AsteroidSpawner : MonoBehaviour
{

    public GameObject[] asteroidPrefabs;
    private Vector2 screenBounds;
    public float respawnTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }

    private void spawnEnemy()
    {
        System.Random random = new System.Random();
        int randomInt = random.Next(0, 4);
        GameObject asteroid = Instantiate(asteroidPrefabs[randomInt]) as GameObject;
        asteroid.transform.position = new Vector3(UnityEngine.Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2, 0f);
    }

    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }



}
