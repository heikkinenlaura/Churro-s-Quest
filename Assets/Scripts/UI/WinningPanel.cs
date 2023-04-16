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

        bonesCollectedText.text = "Bones Collected: " + bonesCollected;

        if (bonesCollected <= 70)
        {
            medalText.text = "You got 1 star";
        }
        else if (bonesCollected > 70 && bonesCollected <= 150)
        {
            medalText.text = "You got 2 stars";
        }
        else
        {
            medalText.text = "You got 3 stars!";
        }

        Time.timeScale = 0f;
    }
}