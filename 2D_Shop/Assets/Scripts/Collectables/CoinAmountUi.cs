using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinAmountUi : MonoBehaviour
{
    [SerializeField] private CoinAmount coins;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private Animator animator;

    private void Start()
    {
        coins.OnAmountChanged += ChangeText;
        ChangeText();
    }

    private void ChangeText()
    {
        coinsText.text = coins.Amount.ToString();
        animator.Play("AmountChanged");
    }
}
