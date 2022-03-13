using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    [SerializeField] int breakableBlocks; // Displays number of breakable blocks

    // cashed reference of SceneLoader game object
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void DestroyedBlocks()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadScene();
        }
    }
}
