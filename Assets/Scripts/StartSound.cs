using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartSound : MonoBehaviour
{
    [Header("Sonido")]
    [SerializeField] private AudioSource StartAudio;

    private void Start()
    {
        StartCoroutine(AudioStart());
    }

    IEnumerator  AudioStart()
    {
        yield return new WaitForSeconds(20);
        StartAudio.Play();
    }
}
