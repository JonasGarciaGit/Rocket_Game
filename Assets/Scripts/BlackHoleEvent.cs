using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleEvent : MonoBehaviour
{

    [SerializeField]
    public GameObject blackHolePrefab;

    [SerializeField]
    public int numberOfBlackHoles;

    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        System.Random random = new System.Random();
     

        for (int i = 0; i <= numberOfBlackHoles; i ++)
        {
            int posX = random.Next((int)-screenBounds.x, (int)screenBounds.x);
            int posY = random.Next((int)-screenBounds.y, (int)screenBounds.y);
            Instantiate<GameObject>(blackHolePrefab, new Vector3(posX, posY, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
