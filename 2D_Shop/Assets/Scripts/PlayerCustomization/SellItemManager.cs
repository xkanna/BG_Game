using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SellItemManager : MonoBehaviour
{
    [SerializeField] private List<PlayerSkin> allSkins;
    [SerializeField] private SellShopItem shopItemPrefab;
    [SerializeField] private GameObject shopContent;
    [SerializeField] private GameObject cartContent;
    [SerializeField] private TextMeshProUGUI totalCost;
    [SerializeField] private CoinAmount coins;

    private int totalPrice = 0;
    private List<SellShopItem> skinsInInventory;
    private List<SellShopItem> skinsInCart;

    private void ClearLists()
    {
        skinsInInventory ??= new List<SellShopItem>();
        skinsInCart ??= new List<SellShopItem>();
        
        if (skinsInInventory.Count > 0)
        {
            foreach (var shopItem in skinsInInventory)
            {
                Destroy(shopItem.gameObject);
            }
        }
        skinsInInventory.Clear();
        
        if (skinsInCart.Count > 0)
        {
            foreach (var shopItem in skinsInCart)
            {
                Destroy(shopItem.gameObject);
            }
        }
        skinsInCart.Clear();
    }

    private void OnEnable()
    {
        ClearLists();
        CalculatePrice();
        SpawnShopItems();
    }

    private void SpawnShopItems()
    {
        foreach (var skin in allSkins)
        {
            var ownedSkins = PlayerSave.Instance.GetOwnedSkins();
            if (!ownedSkins.Contains(skin) || skin.isPermanent) continue;
            var skinShopItem = Instantiate(shopItemPrefab, shopContent.transform);
            skinShopItem.SetupShopItem(skin.skinIcon, skin.cost, skin.playerSkinIndex, this);
            skinsInInventory.Add(skinShopItem);
        }
    }

    public void ShopItemClicked(SellShopItem skin)
    {
        if (skinsInInventory.Contains(skin))
        {
            skinsInInventory.Remove(skin);
            skinsInCart.Add(skin);
            skin.transform.parent = cartContent.transform;
        } 
        else if (skinsInCart.Contains(skin))
        {
            skinsInCart.Remove(skin);
            skinsInInventory.Add(skin);
            skin.transform.parent = shopContent.transform;
        }
        CalculatePrice();
    }

    private void CalculatePrice()
    {
        totalPrice = 0;
        foreach (var shopItem in skinsInCart)
        {
            totalPrice += shopItem.itemCost;
        }

        totalCost.text = totalPrice.ToString();
    }

    public void Sell()
    {
        if (totalPrice <= coins.Amount)
        {
            coins.ChangeAmount(totalPrice);
            foreach (var skinInCart in skinsInCart)
            {
                var skin = allSkins.Find(x => x.playerSkinIndex == skinInCart.itemIndex);
                PlayerSave.Instance.RemoveSkin(skin);
            }
        }
        Player.Instance.CheckIfOwnsSkin();
        gameObject.SetActive(false);
    }
}
