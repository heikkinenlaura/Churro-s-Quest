using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RockPaperScissors : MonoBehaviour
{
    public TMP_Text resultText;
    public TMP_Text aiChoiceText;

    public Button rockButton;
    public Button paperButton;
    public Button scissorsButton;

    private int aiChoice;

    void Start()
    {
        rockButton.onClick.AddListener(() => { PlayerChoice(0); });
        paperButton.onClick.AddListener(() => { PlayerChoice(1); });
        scissorsButton.onClick.AddListener(() => { PlayerChoice(2); });
        resultText.text = "And AI will choose ";
        aiChoiceText.text = "Choose ";
    }

    void PlayerChoice(int playerChoice)
    {
        aiChoice = Random.Range(0, 3);
        aiChoiceText.text = "AI chose: " + GetChoiceString(aiChoice);

        int result = GetResult(playerChoice, aiChoice);
        if (result == 0)
        {
            resultText.text = "It's a tie!";
        }
        else if (result == 1)
        {
            resultText.text = "You win!";
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
            return 0; // tie
        }
        else if ((playerChoice == 0 && aiChoice == 2) || (playerChoice == 1 && aiChoice == 0) || (playerChoice == 2 && aiChoice == 1))
        {
            return 1; // player wins
        }
        else
        {
            return -1; // player loses
        }
    }

    string GetChoiceString(int choice)
    {
        switch (choice)
        {
            case 0:
                return "Rock";
            case 1:
                return "Paper";
            case 2:
                return "Scissors";
            default:
                return "";
        }
    }
}