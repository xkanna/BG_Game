using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    private Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(CloseAction);
    }

    private void CloseAction()
    {
        CameraManager.Instance.SwitchToCamera("cm-main");
    }
}
