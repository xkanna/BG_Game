using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject defaultPlayerPrefab;
    private GameObject playerPrefab;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private int currentSkin;

    public Animator PlayerAnimator => animator;
    public SpriteRenderer SpriteRenderer => spriteRenderer;
    public int CurrentSkin => currentSkin;
    
    public static Player Instance { get; private set; }

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

    private void Start()
    {
        playerPrefab = Instantiate(defaultPlayerPrefab, transform);
        animator = playerPrefab.GetComponent<Animator>();
        spriteRenderer = playerPrefab.GetComponent<SpriteRenderer>();
        currentSkin = 1;
    }

    public void ChangePlayerPrefab(GameObject newPlayerPrefab, int newCurrentSkin)
    {
        Destroy(playerPrefab);
        playerPrefab = Instantiate(newPlayerPrefab, transform);
        animator = playerPrefab.GetComponent<Animator>();
        spriteRenderer = playerPrefab.GetComponent<SpriteRenderer>();
        currentSkin = newCurrentSkin;
    }

    public void CheckIfOwnsSkin()
    {
        if (!PlayerSave.Instance.GetOwnedSkins().Find(x => x.playerSkinIndex == currentSkin))
        {
            ChangePlayerPrefab(defaultPlayerPrefab, 1);
        }
    }
}
