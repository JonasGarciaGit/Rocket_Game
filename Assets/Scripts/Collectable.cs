using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public GameObject starVfx;
    public Text starsCollectedTxt;
    private int starCollected;

    public int startCollectedNumber;

    public bool havePowerUp;

    [SerializeField]
    private GameObject powerUpSlot;
    private Fuel fuelScript;

    [SerializeField]
    public AudioSource audioSource;

    [SerializeField]
    public AudioClip starClip;

    [SerializeField]
    public AudioClip fuelClip;

    [SerializeField]
    public AudioClip powerUpClip;

    public static Collectable Instance { get; private set; }

    private void Start()
    {
        audioSource.volume = 0.1f;
        startCollectedNumber = 1;
        starsCollectedTxt.text = "000";
        starCollected = 0;
        fuelScript = this.gameObject.GetComponentInParent<Fuel>();
        havePowerUp = false;
        audioSource.loop = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Fuel"))
        {
            audioSource.PlayOneShot(fuelClip);
            Destroy(other.gameObject);
            fuelScript.ModifyFuel(20);
        }

        if (other.tag.Equals("PowerUp"))
        {
            if (havePowerUp)
            {

            }
            else
            {
                audioSource.PlayOneShot(powerUpClip);
                GameObject powerUpModel = Instantiate(other.gameObject, powerUpSlot.transform.position, Quaternion.identity);
                powerUpModel.transform.parent = powerUpSlot.transform;
                Destroy(powerUpModel.GetComponent<Rigidbody>());
                powerUpModel.AddComponent<SimpleRotateObject>();
                Destroy(other.gameObject);
                havePowerUp = true;
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject star = Instantiate(starVfx, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(starClip);
        starCollected = starCollected + startCollectedNumber;

        if (starCollected < 10)
        {
            starsCollectedTxt.text = "00" + starCollected.ToString();
        }
        else if (starCollected < 100)
        {
            starsCollectedTxt.text = "0" + starCollected.ToString();
        }
        else
        {
            starsCollectedTxt.text = starCollected.ToString();
        }



        StartCoroutine("DestroyVfx", star);
    }

    IEnumerator DestroyVfx(GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        Destroy(obj);
    }

    public int getStarsAmount()
    {
        return starCollected;
    }

}
