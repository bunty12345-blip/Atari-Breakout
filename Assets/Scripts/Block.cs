﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject particleExplosion;
    [SerializeField] Sprite[] hitSprites;

    // cached  reference
    Level level;

    // state variables 
    [SerializeField] int timesHit;  //serialzed only for debug purposes


    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHits();
        }

    }

    private void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is missing from array " + gameObject.name);    // valuabe debugging code
        }
        
        
    }

    private void DestroyBlock()
    {
        PlayBlockDestroyeSFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        triggerExplosionEffects();

    }

    private void PlayBlockDestroyeSFX()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.7f);
    }

    private void triggerExplosionEffects()
    {
        GameObject sparkles = Instantiate(particleExplosion, transform.position, transform.rotation);
        Destroy(sparkles, 2);
    }
}
