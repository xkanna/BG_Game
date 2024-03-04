using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinAmount", menuName = "Game/CoinAmount", order = 100)]
public class CoinAmount : ScriptableObject
{
    private int coinAmount = 18000;
    public int Amount => coinAmount;
    public Action OnAmountChanged { get; set; }

    public void ChangeAmount(int amount)
    {
        coinAmount += amount;
        OnAmountChanged.Invoke();
    }
}
