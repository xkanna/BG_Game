using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSkin_000", menuName = "Game/Player skin", order = 100)]
public class PlayerSkin : ScriptableObject
{
    public GameObject playerSkinPrefab;
    public Sprite skinIcon;
    public int playerSkinIndex;
    public int cost;
    public bool isPermanent;
}
