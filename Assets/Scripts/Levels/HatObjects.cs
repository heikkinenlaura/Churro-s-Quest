using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatObjects : MonoBehaviour
{
    public string minigameObjectName;

    private void Start()
    {

        // Check if the game object should be active based on PlayerPrefs value
        if (PlayerPrefs.GetInt(minigameObjectName + "Active", 0) == 1)
        {
            // Set the active state of the game object
            transform.GetChild(0).gameObject.SetActive(true);
           
        }
        if (PlayerPrefs.GetInt(minigameObjectName + "Active", 0) == 2)
        {
            // Set the active state of the game object
            transform.GetChild(1).gameObject.SetActive(true);
           
        }
        if (PlayerPrefs.GetInt(minigameObjectName + "Active", 0) == 3)
        {
            // Set the active state of the game object
            transform.GetChild(2).gameObject.SetActive(true);

        }
        if (PlayerPrefs.GetInt(minigameObjectName + "Active", 0) == 4)
        {
            // Set the active state of the game object
            transform.GetChild(3).gameObject.SetActive(true);

        }
    }
}

