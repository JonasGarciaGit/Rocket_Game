using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playlist : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        string canPlay = PlayerPrefs.GetString("playMusic");

        Debug.Log("Can play in game .:" + canPlay);

        if("Y".Equals(canPlay)){
            StartCoroutine("startPlaylist");
        }
        
    }

    private AudioClip GetRandomClip()
    {
        AudioClip music = null;
        music = clips[Random.Range(0, clips.Length)];

        while (music == audioSource.clip)
        {
            music = clips[Random.Range(0, clips.Length)];
        }
        return music;
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource != null)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = GetRandomClip();
                audioSource.Play();
            }
        }
        
    }

    IEnumerator startPlaylist()
    {
        yield return new WaitForSeconds(15f);
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.volume = 0.1f;
    }
}
