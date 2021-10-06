using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnClickSound : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip clickSound;

    public void ClickSound(){
        audioSource.PlayOneShot(clickSound);
    }
    
}
