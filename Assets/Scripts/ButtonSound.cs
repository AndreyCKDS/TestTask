using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    private AudioSource AudioSource;
    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ButtonPlaySound()
    {
        AudioSource.Play();
    }

}
