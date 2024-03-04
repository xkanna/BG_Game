using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickAction : MonoBehaviour
{
    private IButtonAction buttonAction;
    private Button button;

    private void Start()
    {
        buttonAction = GetComponent<IButtonAction>();
        button = GetComponent<Button>();
        button.onClick.AddListener(PerformClickAction);
    }

    private void PerformClickAction()
    {
        buttonAction?.Click();
    }
}
