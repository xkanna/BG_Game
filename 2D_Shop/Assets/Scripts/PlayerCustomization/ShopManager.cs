using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private List<PlayerSkin> allSkins;
    [SerializeField] private ShopItem shopItemPrefab;
    [SerializeField] private GameObject shopContent;
    [SerializeField] private GameObject cartContent;
    [SerializeField] private TextMeshProUGUI totalCost;
    [SerializeField] private CoinAmount coins;

    private int totalPrice = 0;
    private List<ShopItem> skinsInShop;
    private List<ShopItem> skinsInCart;

    private void ClearLists()
    {
        skinsInShop ??= new List<ShopItem>();
        skinsInCart ??= new List<ShopItem>();
        
        if (skinsInShop.Count > 0)
        {
            foreach (var shopItem in skinsInShop)
            {
                Destroy(shopItem.gameObject);
            }
        }
        skinsInShop.Clear();
        
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
            if (ownedSkins.Contains(skin)) continue;
            var skinShopItem = Instantiate(shopItemPrefab, shopContent.transform);
            skinShopItem.SetupShopItem(skin.skinIcon, skin.cost, skin.playerSkinIndex, this);
            skinsInShop.Add(skinShopItem);
        }
    }

    public void ShopItemClicked(ShopItem skin)
    {
        if (skinsInShop.Contains(skin))
        {
            skinsInShop.Remove(skin);
            skinsInCart.Add(skin);
            skin.transform.parent = cartContent.transform;
        } 
        else if (skinsInCart.Contains(skin))
        {
            skinsInCart.Remove(skin);
            skinsInShop.Add(skin);
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

    public void Purchase()
    {
        if (totalPrice <= coins.Amount)
        {
            coins.ChangeAmount(-totalPrice);
            foreach (var skinInCart in skinsInCart)
            {
                var skin = allSkins.Find(x => x.playerSkinIndex == skinInCart.itemIndex);
                PlayerSave.Instance.AddSkin(skin);
            }
        }
        gameObject.SetActive(false);
    }
}
