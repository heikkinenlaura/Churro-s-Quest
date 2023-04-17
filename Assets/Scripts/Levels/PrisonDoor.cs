using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrisonDoor : MonoBehaviour
{
    public GameObject childObject;
    public GameObject winPanel;
    private static int openedDoors;
    public TMP_Text openedDoorsText;

    public void Update()
    {
        openedDoorsText.text = "Opened Doors: " + openedDoors.ToString() + " / 7";

        if (openedDoors >= 7)
        {
            winPanel.SetActive(true);
        }
    }
    public void OpenDoor()
    {
        openedDoors++;
    }
}
