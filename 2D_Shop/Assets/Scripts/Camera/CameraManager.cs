using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> allCameras;
    public static CameraManager Instance { get; private set; }

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

    public void SwitchToCamera(string cameraName)
    {
        foreach (var cmCamera in allCameras)
        {
            if (cmCamera.name == cameraName)
            {
                cmCamera.Priority = 20;
            }
            else
            {
                cmCamera.Priority = 10;
            }
        }
    }
}
