using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationManager : MonoBehaviour
{
    [SerializeField] private ClosetItem itemPrefab;
    [SerializeField] private GameObject closetContent;
    
    private List<ClosetItem> ownedSkins;
    private PlayerSkin currentSkin;
    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void ClearLists()
    {
        ownedSkins ??= new List<ClosetItem>();
        
        if (ownedSkins.Count > 0)
        {
            foreach (var shopItem in ownedSkins)
            {
                Destroy(shopItem.gameObject);
            }
        }
        ownedSkins.Clear();
        
    }

    private void OnEnable()
    {
        ClearLists();
        SpawnShopItems();
        GetCurrentSkin();
    }

    private void GetCurrentSkin()
    {
        currentSkin = PlayerSave.Instance.GetOwnedSkins().Find(x => x.playerSkinIndex == player.CurrentSkin);
    }

    private void SpawnShopItems()
    {
        foreach (var skin in PlayerSave.Instance.GetOwnedSkins())
        {
            var skinShopItem = Instantiate(itemPrefab, closetContent.transform);
            var isEquipped = player.CurrentSkin == skin.playerSkinIndex;
            skinShopItem.SetupClosetItem(skin.skinIcon, isEquipped, skin.playerSkinIndex, this);
            ownedSkins.Add(skinShopItem);
        }
    }
    public void ShopItemClicked(ClosetItem skin)
    {
        foreach (var ownedSkin in ownedSkins)
        {
            ownedSkin.ChangeIsEquipped(ownedSkin.itemIndex == skin.itemIndex);
        }
        currentSkin = PlayerSave.Instance.GetOwnedSkins().Find(x => x.playerSkinIndex == skin.itemIndex);
        player.ChangePlayerPrefab(currentSkin.playerSkinPrefab, currentSkin.playerSkinIndex);
    }

    public void EquipSkin()
    {
        player.ChangePlayerPrefab(currentSkin.playerSkinPrefab, currentSkin.playerSkinIndex);
        CameraManager.Instance.SwitchToCamera("cm-main");
        gameObject.SetActive(false);
    }
    
}
