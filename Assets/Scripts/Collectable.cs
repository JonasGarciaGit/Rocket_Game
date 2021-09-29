using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public GameObject starVfx;
    public Text starsCollectedTxt;
    private int starCollected;

    private void Start()
    {
        starsCollectedTxt.text = "000";
        starCollected = 0;
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject star =  Instantiate(starVfx, transform.position, Quaternion.identity);
       
        starCollected = starCollected + 1;
       
        if (starCollected < 10)
        {
            starsCollectedTxt.text = "00" + starCollected.ToString();
        }else if (starCollected < 100)
        {
            starsCollectedTxt.text = "0" + starCollected.ToString();
        }
        else
        {
            starsCollectedTxt.text = starCollected.ToString();
        }

       

        StartCoroutine("DestroyVfx", star);
    }

    IEnumerator DestroyVfx(GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        Destroy(obj);
    }


}
