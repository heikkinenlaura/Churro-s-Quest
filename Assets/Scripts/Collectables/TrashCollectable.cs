using UnityEngine;
using TMPro;

public class TrashCollectable : MonoBehaviour
{
    public TMP_Text trashCountText;
    public int requiredTrashCount = 3;
    public LevelComplete levelComplete;

    public GameObject trashPanel;

    public GameObject winningPanel; // Reference to the panel to be displayed when the boss is defeated

    private static int collectedTrashCount = 0;

    private void Start()
    {
        UpdateTrashCountText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collectedTrashCount++;
            UpdateTrashCountText();
            if (collectedTrashCount >= requiredTrashCount)
            {
                ShowWinningPanel();
            }
            Destroy(gameObject);
        }
    }

    private void UpdateTrashCountText()
    {
        trashCountText.text = "Trash Collected: " + collectedTrashCount.ToString() + "/" + requiredTrashCount.ToString();
    }

    private void ShowWinningPanel()
    {
        trashPanel.SetActive(false);
        winningPanel.SetActive(true);
        levelComplete.NextLevel();
    }
}