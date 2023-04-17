using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RockPaperScissors : MonoBehaviour
{
    public TMP_Text resultText;
    public TMP_Text aiChoiceText;
    public TMP_Text coinCountText;

    public Button rockButton;
    public Button paperButton;
    public Button scissorsButton;

    public GameObject playerSprite;
    public Sprite rock;
    public Sprite paper;
    public Sprite scissors;

    public GameObject aiSprite;
    public Sprite catRock;
    public Sprite catPaper;
    public Sprite catScissors;

    private int aiChoice;
    private int coinValue = 1;
    public PlayerStats playerStats;

    void Start()
    {
        // Set up listeners for the rock, paper, and scissors buttons
        rockButton.onClick.AddListener(() => { PlayerChoice(0); playerSprite.GetComponent<Image>().sprite = rock;});
        paperButton.onClick.AddListener(() => { PlayerChoice(1); playerSprite.GetComponent<Image>().sprite = paper; });
        scissorsButton.onClick.AddListener(() => { PlayerChoice(2); playerSprite.GetComponent<Image>().sprite = scissors;});

        // Set the initial text for the result and AI choice text objects
        resultText.text = "And Cat will choose ";
        aiChoiceText.text = "Choose ";
        coinCountText.text = "Coins: " + playerStats.CoinCount.ToString();
    }

    void PlayerChoice(int playerChoice)
    {
        // Randomly generate a choice for the AI
        aiChoice = Random.Range(0, 3);

        // Update the AI choice text object with the choice string
        aiChoiceText.text = "Cat chose: " + GetChoiceString(aiChoice);

        // Determine the result of the game based on the player and AI choices
        int result = GetResult(playerChoice, aiChoice);
        // Update the result text object with the appropriate message based on the result
        if (result == 0)
        {
            resultText.text = "It's a tie!";
        }
        else if (result == 1)
        {
            resultText.text = "You win 1 coin!";
            // Increase the coin count in PlayerStats
            playerStats.IncreaseCoins(coinValue);
            // Update the coin count text object
            coinCountText.text = "Coins: " + playerStats.CoinCount.ToString();

        }
        else
        {
            resultText.text = "You lose!";
        }
    }

    int GetResult(int playerChoice, int aiChoice)
    {
        if (playerChoice == aiChoice)
        {
            // tie
            return 0; 
        }
        else if ((playerChoice == 0 && aiChoice == 2) || (playerChoice == 1 && aiChoice == 0) || (playerChoice == 2 && aiChoice == 1))
        {
            // player wins
            return 1; 
        }
        else
        {
            // player loses
            return -1; 
        }
    }

    string GetChoiceString(int choice)
    {
        switch (choice)
        {
            case 0:
                aiSprite.GetComponent<Image>().sprite = catRock;
                return "Rock";
            case 1:
                aiSprite.GetComponent<Image>().sprite = catPaper;
                return "Paper";
            case 2:
                aiSprite.GetComponent<Image>().sprite = catScissors;
                return "Scissors";
            default:
                return "";
        }
    }
}