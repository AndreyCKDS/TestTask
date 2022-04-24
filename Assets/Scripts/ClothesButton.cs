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
    [SerializeField] private string ClothesType;
    private GameObject NackedClothes;
    private GameObject Clothes;
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
            Clothes = GameObject.Find(ClothesType);
            Clothes.SetActive(false);
            /*NackedClothes = GameObject.Find("Nacked"+ClothesType);
            NackedClothes.SetActive(true);*/
        }
        else
        {
            ButtonImage.sprite = ClothesEquipSprite;
            Equip = true;
            Clothes = GameObject.Find(ClothesType);
            Clothes.SetActive(true);
            /*NackedClothes = GameObject.Find("Nacked" + ClothesType);
            NackedClothes.SetActive(false);*/
        }
    }
}
