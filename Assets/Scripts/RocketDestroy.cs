using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketDestroy : MonoBehaviour
{

  private Collectable collectable;

  [SerializeField]
  private IncreaseScore increaseScore;

     private void Start()
    {
       collectable = this.gameObject.GetComponent<Collectable>();
    }

  public void onDie(){
      addStars();
      addScorePoints();
      SceneManager.LoadSceneAsync("Menu_Rocket");
  }

  public void addStars(){
      int stars = PlayerPrefs.GetInt("Stars");
      stars = stars + collectable.getStarsAmount();
      PlayerPrefs.SetInt("Stars", stars);
  }

  public void addScorePoints(){
    int bestScore = PlayerPrefs.GetInt("Score");
    int scorePoints = increaseScore.getPointsAmount();
    if(scorePoints > bestScore){
       PlayerPrefs.SetInt("Score", scorePoints);
    }

  }


}
