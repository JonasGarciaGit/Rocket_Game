using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;
    public GameObject stars;
    public AdmobController ads;

    public void LoadLevel(string name)
    {
        stars.SetActive(false);
        loadingScreen.SetActive(true);

        StartCoroutine(LoadSceneAsync(name));

        ads.DestroyBannerAd();
    }

    IEnumerator LoadSceneAsync(string name)
    {


        AsyncOperation operation = SceneManager.LoadSceneAsync(name);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }

}
