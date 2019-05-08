using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject particleExplosion;

    Level level; // cached  reference
    

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
       



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
