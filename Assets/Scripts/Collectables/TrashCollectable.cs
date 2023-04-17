using UnityEngine;
using TMPro;

public class TrashCollectable : MonoBehaviour
{
    public TMP_Text trashCountText;

    // The number of trash items that need to be collected to complete the level
    public int requiredTrashCount = 5;

    public LevelComplete levelComplete;

    // Reference to the panel that displays the trash count
    public GameObject trashPanel;

    // Reference to the panel to be displayed when the boss is defeated
    public GameObject winningPanel;

    // The number of trash items that have been collected
    private static int collectedTrashCount = 0;

    private void Start()
    {
        // Updates the trash count text when the game starts
        UpdateTrashCountText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the player collides with the trash, increase the collectedTrashCount
        if (collision.CompareTag("Player"))
        {
            collectedTrashCount++;
            UpdateTrashCountText();

            // If the required amount of trash has been collected, show the winning panel
            if (collectedTrashCount >= requiredTrashCount)
            {
                ShowWinningPanel();
            }

            // Destroy the trash object
            Destroy(gameObject);
        }
    }

    // Updates the trash count text with the current number of collected trash items
    private void UpdateTrashCountText()
    {
        trashCountText.text = "Trash Collected: " + collectedTrashCount.ToString() + "/" + requiredTrashCount.ToString();
    }

    // Shows the winning panel and advances to the next level
    private void ShowWinningPanel()
    {
        trashPanel.SetActive(false);
        winningPanel.SetActive(true);
        levelComplete.NextLevel();
        collectedTrashCount = 0;
    }
}