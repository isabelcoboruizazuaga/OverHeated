using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPlatFormSound : MonoBehaviour
{
   public void PlayAudio()
    {
        GetComponent<AudioSource>().Play();
    }
}
