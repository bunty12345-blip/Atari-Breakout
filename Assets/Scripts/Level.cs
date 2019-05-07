using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;  // Serialized for debugging purposes

    // cached reference
    Scene_loader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<Scene_loader>();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }
    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            sceneloader.LoadNextScene();
        }
    }
}
