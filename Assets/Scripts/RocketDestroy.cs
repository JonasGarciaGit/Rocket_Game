using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RocketDestroy : MonoBehaviour
{

    private Collectable collectable;

    [SerializeField]
    private IncreaseScore increaseScore;

    private RocketMovementAcelerometer rocketMovement;

    public RocketMovement rocketMove;

    public GameObject vfxPropulsion;

    public PreventRocketGetOutView preventRocketGetOutView;

    public GameObject gameOverInterface;

    public Text starsAmountText;

    private bool isDie;


    private void Start()
    {
        isDie = false;
        collectable = this.gameObject.GetComponent<Collectable>();
        rocketMovement = this.gameObject.GetComponent<RocketMovementAcelerometer>();
        preventRocketGetOutView = this.gameObject.GetComponent<PreventRocketGetOutView>();
    }

    private void Update()
    {

        if (isDie)
        {
            this.gameObject.transform.Rotate(new Vector3(0, 0, 40) * Time.deltaTime);
        }

    }


    public void onDie()
    {
        addStars();
        addScorePoints();
        StartCoroutine(dieCoroutine());
        //SceneManager.LoadSceneAsync("Menu_Rocket");
    }

    public void addStars()
    {
        int stars = PlayerPrefs.GetInt("Stars");
        stars = stars + collectable.getStarsAmount();
        PlayerPrefs.SetInt("Stars", stars);
    }

    public void addScorePoints()
    {
        int bestScore = PlayerPrefs.GetInt("Score");
        int scorePoints = increaseScore.getPointsAmount();
        if (scorePoints > bestScore)
        {
            PlayerPrefs.SetInt("Score", scorePoints);
        }

    }

    IEnumerator dieCoroutine()
    {
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        this.gameObject.GetComponent<RocketMovement>().enabled = false;
        this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        rocketMove.enabled = false;
        rocketMovement.enabled = false;
        vfxPropulsion.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        vfxPropulsion.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        vfxPropulsion.SetActive(false);
        isDie = true;
        increaseScore.enabled = false;
        yield return new WaitForSeconds(5f);
        preventRocketGetOutView.enabled = true;
        gameOverInterface.SetActive(true);
        starsAmountText.text = collectable.getStarsAmount().ToString();
    }


}
