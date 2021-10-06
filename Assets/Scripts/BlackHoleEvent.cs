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

    [SerializeField]
    public Transform rocketPosition;

    [SerializeField]
    public  bool respawnAgain;

    private System.Random random = new System.Random();

    [SerializeField]
    public float eventDuration;

    private List<GameObject> blackHoleList = new List<GameObject>();

    [SerializeField]
    public bool insideBlackHole;

    // Start is called before the first frame update
    void Start()
    {
        respawnAgain = true;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {

        if (respawnAgain)
        {
            for (int i = 0; i <= numberOfBlackHoles; i++)
            {
                int posX = random.Next((int)-screenBounds.x, (int)screenBounds.x);
                int posY = random.Next((int)-screenBounds.y, (int)screenBounds.y);

                if (posX != rocketPosition.position.x && posY != rocketPosition.position.y)
                {
                    GameObject bk = Instantiate<GameObject>(blackHolePrefab, new Vector3(posX, posY, 0), Quaternion.identity);
                    blackHoleList.Add(bk);
                }
            }
            respawnAgain = false;
            StartCoroutine("DestroyBlackHoles", blackHoleList);
        }
    }

    IEnumerator DestroyBlackHoles(List<GameObject> blackHoles)
    {
        yield return new WaitForSeconds(eventDuration);
        if (insideBlackHole == false)
        {
            if (blackHoles != null)
            {
                foreach (GameObject bk in blackHoles)
                {
                    Destroy(bk);
                }
                respawnAgain = true;
            }
        }
        else
        {
            yield return null;
        }
       

    }



}
