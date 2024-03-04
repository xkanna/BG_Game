using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinAmountUi : MonoBehaviour
{
    [SerializeField] private CoinAmount coins;
    [SerializeField] private TextMeshProUGUI coinsText;

    private void Start()
    {
        coins.OnAmountChanged += ChangeText;
        ChangeText();
    }

    private void ChangeText()
    {
        coinsText.text = coins.Amount.ToString();
    }
}
