using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    [SerializeField] private PlayerSkin defaultSkin;
    private List<PlayerSkin> ownedSkins;
    public static PlayerSave Instance { get; private set; }

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
        ownedSkins = new List<PlayerSkin>();
        ownedSkins.Add(defaultSkin);
    }

    public void AddSkin(PlayerSkin skin)
    {
        ownedSkins.Add(skin);
    }

    public void RemoveSkin(PlayerSkin skin)
    {
        ownedSkins.Remove(skin);
    }

    public List<PlayerSkin> GetOwnedSkins()
    {
        return ownedSkins;
    }
}
