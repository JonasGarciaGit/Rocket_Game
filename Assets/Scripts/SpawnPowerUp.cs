using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour
{

    public GameObject[] powerUps;
    private Vector2 screenBounds;
    public float timerSpawn;
    private bool canSpawn;


    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        canSpawn = true;
    }

    private void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(respawnPowerUp());
        }
        
    }

    void respawn()
    {
        System.Random random = new System.Random();
        int randomInt = random.Next(0, 2);
        Debug.Log(randomInt);
        GameObject powerUp = Instantiate(powerUps[randomInt]) as GameObject;
        powerUp.transform.position = new Vector3(UnityEngine.Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2, 0f);
        Destroy(powerUp, 5f);
    }

    IEnumerator respawnPowerUp()
    {
            canSpawn = false;
            yield return new WaitForSeconds(timerSpawn);
            respawn();
            canSpawn = true;
        
    }
}
