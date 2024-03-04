using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour, IButtonAction
{
    [SerializeField] private ActionBox actionBox;
    public void Click()
    {
        UiManager.Instance.ShowShop();
        actionBox.gameObject.SetActive(false);
    }
}
