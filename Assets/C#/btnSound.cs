using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnSound : MonoBehaviour
{
    public AudioSource myAudio;
    public AudioClip clickAudio;

    public void clickSound()
    {
        myAudio.PlayOneShot(clickAudio);
    }
}
