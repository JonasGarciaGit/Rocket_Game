using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerChoose : MonoBehaviour
{

    private GameObject introStart;
    private GameObject controlChooseCanvas;
    private GameObject playlist;

    private void Start()
    {
        introStart = GameObject.Find("IntroStart");
        controlChooseCanvas = GameObject.Find("ConfigControl");
        playlist = GameObject.Find("AudioManager");
    }

    public void fingerTouch()
    {
        introStart.GetComponent<IntroGame>().controllerChoosed = "FINGER_TOUCH";
        controlChooseCanvas.SetActive(false);
        introStart.GetComponent<IntroGame>().controlSelected = true;
        introStart.GetComponent<IntroGame>().callStartGame();
        playlist.GetComponent<Playlist>().callStartPlayList();

    }

    public void ScreenShake()
    {
        introStart.GetComponent<IntroGame>().controllerChoosed = "SCREEN_SHAKE";
        controlChooseCanvas.SetActive(false);
        introStart.GetComponent<IntroGame>().controlSelected = true;
        introStart.GetComponent<IntroGame>().callStartGame();
        playlist.GetComponent<Playlist>().callStartPlayList();
    }
}
