using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothesButton : MonoBehaviour
{
    private Image ButtonImage;
    private bool Equip;
    [SerializeField] private Sprite ClothesSprite;
    [SerializeField] private Sprite ClothesEquipSprite;
    [SerializeField] private GameObject Naked;
    [SerializeField] private GameObject Clothes;
    void Start()
    {
        ButtonImage = GetComponent<Image>();
        Equip = true;
    }

    public void EquipClothes()
    {
        if (Equip)
        {
            ButtonImage.sprite = ClothesSprite;
            Equip = false;
            Naked.SetActive(true);
            Clothes.SetActive(false);
        }
        else
        {
            ButtonImage.sprite = ClothesEquipSprite;
            Equip = true;
            Naked.SetActive(false);
            Clothes.SetActive(true);
        }
    }
}
