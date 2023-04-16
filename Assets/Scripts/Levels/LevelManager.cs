using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int currentLevel = 1;
    public PlayerController playerController;

    private void Start()
    {
        if (currentLevel == 3)
        {
            playerController.shouldBark = false;
        }
    }
}
