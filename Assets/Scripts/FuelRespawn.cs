using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FuelRespawn : MonoBehaviour
{

    public GameObject fuelPrefab;
    private bool canInstanceFuel = true;
    public float instanceSpeed;
    public float destroySpeed;
    private Vector2 screenBounds;
    private GameObject objInstatiate = null;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }


    // Update is called once per frame
    void Update()
    {

        if (canInstanceFuel)
        {
            System.Random random = new System.Random();
            int randomInt = random.Next((int) -screenBounds.x, (int) screenBounds.x);
            float posX = (float) randomInt;
            objInstatiate = Instantiate(fuelPrefab, new Vector3(posX, transform.position.y, transform.position.z), Quaternion.identity);
            canInstanceFuel = false;
        }

        if (objInstatiate != null)
        {

            if (objInstatiate.transform.position.y < (screenBounds.y * -1))
            {
                Destroy(objInstatiate);
                canInstanceFuel = true;
            }

        }
        else
        {
            canInstanceFuel = true;
        }

    }




 
}
