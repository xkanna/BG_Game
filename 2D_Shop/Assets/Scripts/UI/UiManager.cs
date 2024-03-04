using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject customizationUi;
    [SerializeField] private GameObject shopUi;
    [SerializeField] private GameObject shopSellUi;
    public static UiManager Instance { get; private set; }

    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
    
    public void ShowCustomization()
    {
        customizationUi.SetActive(true);
    }

    public void ShowShop()
    {
        shopUi.SetActive(true);
    }
    
    public void ShowShopSell()
    {
        shopSellUi.SetActive(true);
    }
}
