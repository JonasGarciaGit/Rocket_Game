using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseScore : MonoBehaviour
{
    public Text scorePoints;
    private bool gameOver;
    public float increasePointSpeed;
    private int points;
    public int pointsPerSecond;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        scorePoints.text = points.ToString();
        gameOver = false;
        StartCoroutine("gameStarted");
    }

    private void Update()
    {
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
}
