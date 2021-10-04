using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketDestroy : MonoBehaviour
{

  private Collectable collectable;

     private void Start()
    {
       collectable = this.gameObject.GetComponent<Collectable>();
    }

  public void onDie(){
      addStars();
      SceneManager.LoadSceneAsync("Menu_Rocket");
  }

  public void addStars(){
      int stars = PlayerPrefs.GetInt("Stars");
      stars = stars + collectable.getStarsAmount();
      PlayerPrefs.SetInt("Stars", stars);
  }


}
