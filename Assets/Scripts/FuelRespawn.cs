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


    // Update is called once per frame
    void Update()
    {
        if (canInstanceFuel)
        {
            System.Random random = new System.Random();
            int randomInt = random.Next(-10,10);
            float posX = (float)randomInt;
            StartCoroutine("InstanceFuel", posX);
        }
    }


    IEnumerator InstanceFuel(float posX)
    {
        GameObject fuelObj = Instantiate(fuelPrefab, new Vector3(posX,transform.position.y , transform.position.z), Quaternion.identity);
        canInstanceFuel = false;
        yield return new WaitForSeconds(instanceSpeed);
        canInstanceFuel = true;
        StartCoroutine("DestroyFuel", fuelObj);
    }

    IEnumerator DestroyFuel(GameObject fuel)
    {
        yield return new WaitForSeconds(destroySpeed);
        if (fuel != null)
        {
            Destroy(fuel);
        }
    }
}
