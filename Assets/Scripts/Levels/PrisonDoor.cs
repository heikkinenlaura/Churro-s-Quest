using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrisonDoor : MonoBehaviour
{
    public GameObject childObject;
    public GameObject winPanel;
    public int openedDoors = 0;
    public TMP_Text openedDoorsText;

    private void Update()
    {
        openedDoorsText.text = "Opened Doors: " + openedDoors.ToString() + " / 10";
        if (openedDoors >= 10)
        {
            winPanel.SetActive(true);
        }
    }
}
