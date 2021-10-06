using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseScore : MonoBehaviour
{
    public Text scorePoints;
    private bool gameOver;
    public float increasePointSpeed;
    [SerializeField]
    public int points;
    public int pointsPerSecond;

    private int bestScore;

    public GameObject newScoreAlert;

    private bool triggerNewScore = false;
    public static IncreaseScore Instance {get;private set;}

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        scorePoints.text = points.ToString();
        gameOver = false;
        StartCoroutine("gameStarted");
        bestScore = PlayerPrefs.GetInt("Score");
    }

    private void Update()
    {
        if(points > bestScore && triggerNewScore == false && bestScore != 0){
            StartCoroutine(showEventAlert());
        }

        scorePoints.text = points.ToString();
    }

    IEnumerator gameStarted()
    {
        yield return new WaitForSeconds(10f);
        StartCoroutine("increasingPoints");
    }

    IEnumerator increasingPoints()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(increasePointSpeed);
            points = points + pointsPerSecond;
        }
    }

    public int getPointsAmount(){
        return this.points;
    }

    IEnumerator showEventAlert(){
            triggerNewScore = true;
            newScoreAlert.SetActive(true);
            newScoreAlert.GetComponent<TextMesh>().text = "NEW RECORD!";
            yield return new WaitForSeconds(1f);
            newScoreAlert.SetActive(false);
    }
}
