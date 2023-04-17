using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public Image corgiImage;          // A reference to the corgi image UI element
    public Image catImage;            // A reference to the cat image UI element
    public TMP_Text dialogueText;     // A reference to the dialogue text UI element

    private string[] corgiDialogue = { "Hey there! ", "I need your help.", "The animals in this forest are being denied access to clean water.", " ", "If you want to get rid of that dam, I think you need to use your loud bark to break it" };
    // An array of strings containing the corgi's dialogue lines
    private string[] catDialogue = { "I'm ready to help.", "What can I do?", "Lead the way.", "Let's save our animals." };
    // An array of strings containing the cat's dialogue lines

    private int currentLine = 0;     // An integer representing the current dialogue line being displayed
    private bool dialogueActive = false;  // A boolean representing whether or not the dialogue is currently active

    void Start()
    {
        StartDialogue();            // Call the StartDialogue method

        Time.timeScale = 0;         // Pause the game
    }

    void Update()
    {
        if (dialogueActive && Input.anyKeyDown)  // If the dialogue is active and the player presses any key
        {
            NextLine();             // Call the NextLine method
        }
    }

    public void StartDialogue()
    {
        currentLine = 0;            // Set the current dialogue line to 0
        dialogueActive = true;      // Set dialogueActive to true
        ShowDialogue();             // Call the ShowDialogue method
        ShowCorgi();                // Call the ShowCorgi method
        SetDialogueText(corgiDialogue[currentLine]);   // Call the SetDialogueText method and pass in the first corgi dialogue line
    }

    public void NextLine()
    {
        if (currentLine < corgiDialogue.Length - 1)    // If the current dialogue line is less than the length of the corgiDialogue array - 1
        {
            currentLine++;          // Increment the currentLine
            if (currentLine % 2 == 1)   // If the currentLine is odd
            {
                ShowCat();          // Call the ShowCat method
                SetDialogueText(catDialogue[currentLine]);  // Call the SetDialogueText method and pass in the current cat dialogue line
            }
            else                    // Otherwise (if the currentLine is even)
            {
                ShowCorgi();        // Call the ShowCorgi method
                SetDialogueText(corgiDialogue[currentLine]);   // Call the SetDialogueText method and pass in the current corgi dialogue line
            }
        }
        else                        // Otherwise (if the currentLine is greater than or equal to the length of the corgiDialogue array - 1)
        {
            EndDialogue();          // Call the EndDialogue method
        }
    }

    public void EndDialogue()
    {
        dialogueActive = false;     // Set dialogueActive to false
        HideDialogue();             // Call the HideDialogue method
        Time.timeScale = 1f;        // Unpause the game
        this.gameObject.SetActive(false);   // Deactivate this game object
    }

    private void ShowCorgi()
    {
        corgiImage.gameObject.SetActive(true);    // Set the corgi image UI element to active
        catImage.gameObject.SetActive(false);    // Set the cat image UI element to inactive
    }

    private void ShowCat()
    {
        corgiImage.gameObject.SetActive(false);  
        catImage.gameObject.SetActive(true);
    }

    private void SetDialogueText(string text)
    {
        dialogueText.text = text;
    }

    private void ShowDialogue()
    {
        corgiImage.gameObject.SetActive(true);
        catImage.gameObject.SetActive(false);
        dialogueText.gameObject.SetActive(true);
    }

    private void HideDialogue()
    {
        corgiImage.gameObject.SetActive(false);
        catImage.gameObject.SetActive(false);
        dialogueText.gameObject.SetActive(false);
    }
}