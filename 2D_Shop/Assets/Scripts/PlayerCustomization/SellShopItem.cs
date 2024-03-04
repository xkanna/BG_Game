using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellShopItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Image image;

    public int itemIndex;
    public int itemCost;
    private SellItemManager manager;

    public void SetupShopItem(Sprite icon, int cost, int index, SellItemManager manager)
    {
        image.sprite = icon;
        itemCost = cost;
        costText.text = cost.ToString() + "$";
        itemIndex = index;
        this.manager = manager;
    }

    public void Click()
    {
        manager.ShopItemClicked(this);
    }
}
