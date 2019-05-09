
using UnityEngine;

public class Block : MonoBehaviour
{
    // config parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject particleExplosion;
    [SerializeField] GameObject extraBall;
    [SerializeField] Sprite[] hitSprites;

    // cached  reference
    Level level;
    GameStatus gameStatus;
    CameraShake cameraShake;


    // state variables 
    [SerializeField] int timesHit;  //serialzed only for debug purposes


    private void Start()
    {
        CountBreakableBlocks();
        gameStatus = FindObjectOfType<GameStatus>();
        cameraShake = FindObjectOfType<CameraShake>();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable" || tag == "Fast" || tag == "Slow" || tag == "+250" || tag == "x10")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable" || tag == "Fast" || tag == "Slow" || tag == "+250" || tag == "x10")
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
        SpeedControls();
        cameraShake.shakecamera();


    }

    private void SpeedControls()
    {
        if (tag == "Fast")
        {
            gameStatus.GameSpeedFast();
        }
        if (tag == "Slow")
        {
            gameStatus.GameSpeedSlow();
        }
        if(tag == "+250")
        {
            FindObjectOfType<GameStatus>().AddToScore(170); //80 is automatically added as it is called twice 
        }
        if(tag == "x10")
        {
            GameObject ExtraBall = Instantiate(extraBall, transform.position, transform.rotation);
            Destroy(ExtraBall, 10);
        }
    }

    private void PlayBlockDestroyeSFX()
    {
        FindObjectOfType<GameStatus>().AddToScore(0); 
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.7f);
    }

    private void triggerExplosionEffects()
    {
        GameObject sparkles = Instantiate(particleExplosion, transform.position, transform.rotation);
        Destroy(sparkles, 2);
    }
}
