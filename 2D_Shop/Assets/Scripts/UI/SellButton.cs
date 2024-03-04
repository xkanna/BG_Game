using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButton : MonoBehaviour,IButtonAction
{
    [SerializeField] private ActionBox actionBox;
    public void Click()
    {
        UiManager.Instance.ShowShopSell();
        actionBox.gameObject.SetActive(false);
    }
}
