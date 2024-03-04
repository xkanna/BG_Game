using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Image image;

    public int itemIndex;
    public int itemCost;
    private ShopManager shopManager;

    public void SetupShopItem(Sprite icon, int cost, int index, ShopManager manager)
    {
        image.sprite = icon;
        itemCost = cost;
        costText.text = cost.ToString() + "$";
        itemIndex = index;
        shopManager = manager;
    }

    public void MoveItem()
    {
        shopManager.ChangeSkinPosition(this);
    }
}
