using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUI : MonoBehaviour
{
    public TMP_Text coinCountText;
    public TMP_Text boneCountText;

    void Update()
    {
        // Show current coin count in UI
        coinCountText.text = " " + PlayerStats.instance.CoinCount;

        // Show current bone count in UI
        boneCountText.text = " " + PlayerStats.instance.BoneCount;
    }
}
