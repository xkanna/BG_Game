using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPoint : MonoBehaviour
{
    [SerializeField] private GameObject glow;
    [SerializeField] private ActionBox actionBox;
    private void PerformAction()
    {
        actionBox.gameObject.SetActive(true);
    }

    private void OnMouseDown()
    {
        PerformAction();
    }

    private void OnMouseOver()
    {
        glow.SetActive(true);
    }

    private void OnMouseExit()
    {
        glow.SetActive(false);
    }
}
