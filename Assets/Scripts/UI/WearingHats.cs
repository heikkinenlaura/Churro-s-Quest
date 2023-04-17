using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WearingHats : MonoBehaviour
{
    public int buttonIndex;
    public string minigameObjectName;

    public void OnClickCap()
    {
        // Set the active state of the game object
        PlayerPrefs.SetInt(minigameObjectName + "Active", 1);
        PlayerPrefs.Save();

        Debug.Log("PlayerPrefs value set for " + minigameObjectName + "Active");

        // Load the minigame scene
        SceneManager.LoadScene("MiniGame");
    }
    public void OnClickFrog()
    {
        // Set the active state of the game object
        PlayerPrefs.SetInt(minigameObjectName + "Active", 2);
        PlayerPrefs.Save();

        Debug.Log("PlayerPrefs value set for " + minigameObjectName + "Active");

        // Load the minigame scene
        SceneManager.LoadScene("MiniGame");
    }
    public void OnClickCat()
    {
        // Set the active state of the game object
        PlayerPrefs.SetInt(minigameObjectName + "Active", 3);
        PlayerPrefs.Save();

        Debug.Log("PlayerPrefs value set for " + minigameObjectName + "Active");

        // Load the minigame scene
        SceneManager.LoadScene("MiniGame");
    }
    public void OnClickChurro()
    {
        // Set the active state of the game object
        PlayerPrefs.SetInt(minigameObjectName + "Active", 4);
        PlayerPrefs.Save();

        Debug.Log("PlayerPrefs value set for " + minigameObjectName + "Active");

        // Load the minigame scene
        SceneManager.LoadScene("MiniGame");
    }
}
