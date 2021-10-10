using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStarsAmount : MonoBehaviour
{

    private int actualStars;
    // Start is called before the first frame update
    void Start()
    {
        actualStars = getStars();
        Debug.Log("Estrelas atuais .:" + actualStars);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void addStars(int amount)
    {
        Debug.Log("addStarts() .:" + actualStars + " " + amount);
        this.actualStars = actualStars + amount;
        Debug.Log("Estrelas adicionadas .:" + actualStars);
    }

    public void loadStarsInPrefabs()
    {
        PlayerPrefs.SetInt("Stars", actualStars);
        Debug.Log("Estrelas carregadas .:" + actualStars);
    }

    public int getStars()
    {
        return PlayerPrefs.GetInt("Stars");
    }
}
