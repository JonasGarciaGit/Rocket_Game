using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{

    private bool canCollide = true;
    
    private int collisionCount = 0;

    public bool shieldIsUp = false;

    public MenuController menuController;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Asteroid"))
        {
            if (canCollide && shieldIsUp == false)
            {
                collisionCount += 1;
                canCollide = false;
                menuController.showFloatingText(collisionCount + " collision");

                if(collisionCount > 3){
                    gameObject.GetComponent<RocketDestroy>().onDie();
                }
                
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
