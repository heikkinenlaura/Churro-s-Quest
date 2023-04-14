using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinningPanel : MonoBehaviour
{
    public TMP_Text bonesCollectedText;
    public TMP_Text medalText;
    public Transform UI;

    private void Start()
    {
        int bonesCollected = PlayerStats.instance.BoneCount;
        UI.gameObject.SetActive(false);

        bonesCollectedText.text = "Food Collected: " + bonesCollected;

        if (bonesCollected <= 10)
        {
            medalText.text = "Bronze Medal";
        }
        else if (bonesCollected > 10 && bonesCollected <= 30)
        {
            medalText.text = "Silver Medal";
        }
        else
        {
            medalText.text = "Gold Medal";
        }

        Time.timeScale = 0f;
    }
}