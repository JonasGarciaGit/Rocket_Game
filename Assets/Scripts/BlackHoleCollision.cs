using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlackHoleCollision : MonoBehaviour
{
    [SerializeField]
    private Text score;

    private ParticleSystem starBackground;

    private GameObject rocket;

    private System.Random random = new System.Random();

    private bool canDestroyBlackHoles;

    private bool canExecuteEvent;

    private void Start()
    {
        score = GameObject.Find("ScoreTxt").GetComponent<IncreaseScore>().scorePoints;
        starBackground = GameObject.Find("Stars").GetComponent<ParticleSystem>();
        rocket = GameObject.Find("Rocket_Sculpt");
        canDestroyBlackHoles = false;
        canExecuteEvent = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Rocket_Sculpt") && canExecuteEvent)
        {
            int fiftyFifty = random.Next(1, 3);
            if (fiftyFifty == 1)
            {
                stopEvent(-300);
            }
            else
            {
                stopEvent(300);
            }
        }
      
    }

    private void stopEvent(int value)
    {
        int scoreInt = Int32.Parse(score.text);
        scoreInt = scoreInt + (value);
        GameObject.Find("ScoreTxt").GetComponent<IncreaseScore>().points = scoreInt;
        GameObject.Find("SpecialEvents").GetComponent<BlackHoleEvent>().insideBlackHole = true;
        Debug.Log("Cheguei aqui antes da rotina");
        StartCoroutine("increaseBackgroundSpeed");
        GameObject.Find("SpecialEvents").GetComponent<BlackHoleEvent>().enabled = false;
    }

    IEnumerator increaseBackgroundSpeed()
    {
        float originalPlaySpeed = starBackground.playbackSpeed;
        starBackground.playbackSpeed = 10f;
        rocket.SetActive(false);
        Debug.Log("Cheguei aqui e desabilitei o rocket");
        yield return new WaitForSeconds(2f);
        rocket.SetActive(true);
        rocket.GetComponent<AsteroidCollision>().canCollide = true;
        Debug.Log("Cheguei aqui e habilitei o rocket");
        starBackground.playbackSpeed = originalPlaySpeed;
        canDestroyBlackHoles = true;
        canExecuteEvent = false;
        GameObject.Find("SpecialEvents").GetComponent<BlackHoleEvent>().insideBlackHole = false;
    }

    private void Update()
    {
        if (canDestroyBlackHoles)
        {
            GameObject[] blackHoles = GameObject.FindGameObjectsWithTag("BlackHole");
            foreach (GameObject bk in blackHoles)
            {
                Destroy(bk);
            }
            canDestroyBlackHoles = false;
            GameObject.Find("SpecialEvents").GetComponent<BlackHoleEvent>().respawnAgain = true;
            GameObject.Find("SpecialEvents").GetComponent<EventControlSystem>().hasStarted = false;
        }
    }



}
