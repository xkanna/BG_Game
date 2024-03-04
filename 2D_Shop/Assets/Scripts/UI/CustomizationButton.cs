using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationButton : MonoBehaviour, IButtonAction
{
    public void Click()
    {
        UiManager.Instance.ShowCustomization();
        CameraManager.Instance.SwitchToCamera("cm-zoomed");
    }
}
