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
    public SpriteRenderer backgroundRenderer;
    public List<Sprite> bkImages;

    private void Start()
    {
        distance = 0;
        StartCoroutine("increaseDistance");
        StartCoroutine("backgroundTransition");
    }

    // Update is called once per frame
    void Update()
    {
      

        if (distance == 1)
        {
            backgroundRenderer.gameObject.SetActive(true);
            backgroundRenderer.sprite = bkImages[0];
        }
        else if (distance == 3)
        {
            backgroundRenderer.flipX = true;
            backgroundRenderer.sprite = bkImages[1];
        }
        else if (distance == 4)
        {
            backgroundRenderer.flipX = false;
            backgroundRenderer.gameObject.transform.position = new Vector3(16f, 9.8f, 45f);
            backgroundRenderer.sprite = bkImages[2];
        }
        else if (distance == 6)
        {
            backgroundRenderer.gameObject.transform.position = new Vector3(-9.8f, 9.8f, 45f);
            backgroundRenderer.sprite = bkImages[3];
        }
        else if (distance == 8)
        {
            backgroundRenderer.gameObject.transform.position = new Vector3(-9.8f, 9.8f, 45f);
            backgroundRenderer.sprite = bkImages[4];
        }
        else if (distance == 9)
        {
            backgroundRenderer.gameObject.transform.position = new Vector3(-3.3f, 9.8f, 45f);
            backgroundRenderer.sprite = bkImages[5];
        }
    }

    IEnumerator increaseDistance()
    {
        while(distance != 9)
        {
            yield return new WaitForSeconds(30f);
            this.distance = this.distance + 1;

            asteroidRespawn.GetComponent<AsteroidSpawner>().respawnTime = asteroidRespawn.GetComponent<AsteroidSpawner>().respawnTime - 0.02f;
            starDropping.GetComponent<ParticleSystem>().playbackSpeed = starDropping.GetComponent<ParticleSystem>().playbackSpeed + 0.2f;
            starBackground.GetComponent<ParticleSystem>().playbackSpeed = starBackground.GetComponent<ParticleSystem>().playbackSpeed + 0.2f;
            fuelDroppingSpeed.GetComponent<FuelRespawn>().instanceSpeed = fuelDroppingSpeed.GetComponent<FuelRespawn>().instanceSpeed - 0.1f;

        }
    }


    IEnumerator backgroundTransition()
    {
        while(distance != 9)
        {
            yield return new WaitForSeconds(30f);
            if (distance == 1)
            {
                StartCoroutine("fadeOutSprite");
                StartCoroutine("fadeInSprite"); 
            }
            else if (distance == 3)
            {
                StartCoroutine("fadeOutSprite");
                StartCoroutine("fadeInSprite");          
            }
            else if (distance == 4)
            {
                StartCoroutine("fadeOutSprite");
                StartCoroutine("fadeInSprite");
            }
            else if (distance == 6)
            {
                StartCoroutine("fadeOutSprite");
                StartCoroutine("fadeInSprite");              
            }
            else if (distance == 8)
            {
                StartCoroutine("fadeOutSprite");
                StartCoroutine("fadeInSprite");            
            }
            else if (distance == 9)
            {
                StartCoroutine("fadeOutSprite");
                StartCoroutine("fadeInSprite");            
            }
        }
    }

    IEnumerator fadeInSprite()
    {
        for (float f = 0.1f; f <= 1; f +=0.1f)
        {
            Color c = backgroundRenderer.color;
            c.a = f;
            backgroundRenderer.color = c;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator fadeOutSprite()
    {
        for (float f = 1f; f >= 0f; f -= 0.20f)
        {
            Color c = backgroundRenderer.color;
            c.a = f;
            backgroundRenderer.color = c;
            yield return new WaitForSeconds(5f);
        }
    }


}
