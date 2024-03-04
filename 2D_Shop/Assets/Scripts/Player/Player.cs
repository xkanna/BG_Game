using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private int currentSkin;

    public Animator PlayerAnimator => animator;
    public SpriteRenderer SpriteRenderer => spriteRenderer;

    public int CurrentSkin => currentSkin;

    private void Start()
    {
        animator = playerPrefab.GetComponent<Animator>();
        spriteRenderer = playerPrefab.GetComponent<SpriteRenderer>();
        currentSkin = 1;
    }

    public void ChangePlayerPrefab(GameObject newPlayerPrefab, int newCUrrentSkin)
    {
        Destroy(playerPrefab);
        playerPrefab = Instantiate(newPlayerPrefab, transform);
        animator = playerPrefab.GetComponent<Animator>();
        spriteRenderer = playerPrefab.GetComponent<SpriteRenderer>();
        currentSkin = newCUrrentSkin;
    }
}
