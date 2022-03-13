using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroyer : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    GameLevel level;
    [SerializeField] int timesHit;  // for debug

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<GameLevel>();
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
            DestroyBlocks();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.Log("Sprite is missing from array!" + gameObject.name);
        }
    }

    private void DestroyBlocks()
    {
        PlaySFX();
        Destroy(gameObject);
        level.DestroyedBlocks();
        ParticleEffects();
    }

    private void PlaySFX()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void ParticleEffects()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
