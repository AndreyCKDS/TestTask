using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour
{
    [SerializeField] private AudioClip[] StepsSounds;
    private AudioSource AudioSource;
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    public void StepSoundPlay()
    {
        AudioSource.PlayOneShot(StepsSounds[Random.Range(0,StepsSounds.Length)]);
    }
}
