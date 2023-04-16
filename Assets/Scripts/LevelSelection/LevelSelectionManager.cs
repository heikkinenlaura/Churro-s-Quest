using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionManager : MonoBehaviour
{
    public GameObject hideWhenLevel1Won;
    public GameObject hideWhenLevel2Won;
    public GameObject showWhenLevel2Won;

    private void Start()
    {
        // check if level 1 is won
        if (PlayerPrefs.GetInt("Level1Won") == 1)
        {
            // set level 1 GameObjects to inactive
            hideWhenLevel1Won.SetActive(false);
        }

        // check if level 2 is won
        if (PlayerPrefs.GetInt("Level2Won") == 1)
        {
            // set level 2 GameObjects to inactive and show the "showwhenlevel2won" GameObject
            hideWhenLevel2Won.SetActive(false);
            showWhenLevel2Won.SetActive(true);
        }
    }
}
