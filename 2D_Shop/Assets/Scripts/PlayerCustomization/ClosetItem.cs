using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClosetItem : MonoBehaviour
{
    [SerializeField] private Image isEquippedImage;
    [SerializeField] private Image image;

    public int itemIndex;
    public int itemCost;
    private CustomizationManager manager;

    public void SetupClosetItem(Sprite icon, bool isEquipped, int index, CustomizationManager manager)
    {
        image.sprite = icon;
        if(isEquipped) isEquippedImage.gameObject.SetActive(true);
        itemIndex = index;
        this.manager = manager;
    }

    public void Click()
    {
        manager.ShopItemClicked(this);
    }

    public void ChangeIsEquipped(bool isEquipped)
    {
        isEquippedImage.gameObject.SetActive(isEquipped);
    }
}
