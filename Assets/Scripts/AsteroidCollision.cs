using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{

    private bool canCollide = true;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Asteroid"))
        {
            if (canCollide)
            {
                Debug.Log("Colidi com um asteroid");
                canCollide = false;
                StartCoroutine("CanCollideAgain");
            }
            
        }
    }

    IEnumerator CanCollideAgain()
    {
        yield return new WaitForSeconds(1f);
        canCollide = true;
    }


}
