using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    private Image ButtonImage;
    private bool Mute;
    [SerializeField] private Sprite MusicSprite;
    [SerializeField] private Sprite NoMusicSprite;

    void Start()
    {
        Mute = false;
        ButtonImage = GetComponent<Image>();
    }

    public void MuteGame()
    {
        if (Mute)
        {
            ButtonImage.sprite = MusicSprite;
            Mute = false;
            AudioListener.volume = 1;
        }
        else
        {
            ButtonImage.sprite = NoMusicSprite;
            Mute = true;
            AudioListener.volume = 0;
        }
    }
}
