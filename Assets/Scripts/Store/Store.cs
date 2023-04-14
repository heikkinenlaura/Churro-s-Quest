using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class Store : MonoBehaviour
{
    public TMP_Text coinCountText;
    public int coinCount;

    public GameObject[] availableItems;
    public List<GameObject> purchasedItems;
    public BuyButton buyButton;

    private void Awake()
    {
        LoadPurchasedItems();
    }

    private void Start()
    {
        // Load the player's coin count from PlayerPrefs
        coinCount = PlayerPrefs.GetInt("CoinCount", 0);
        UpdateCoinCountText();
    }

    private void UpdateCoinCountText()
    {
        coinCountText.text = coinCount.ToString() + " ";
    }

    private void SaveCoinCount()
    {
        PlayerPrefs.SetInt("CoinCount", coinCount);
    }
    private void SavePurchasedItems()
    {
        List<string> purchasedItemNames = new List<string>();
        List<bool> purchasedItemActiveStates = new List<bool>();

        // Loop through all purchased items and add their names and active states to the respective lists
        foreach (GameObject item in purchasedItems)
        {
            purchasedItemNames.Add(item.name);
            purchasedItemActiveStates.Add(item.activeInHierarchy);
        }

        // Save the purchased item names and active states to PlayerPrefs as comma-separated strings
        PlayerPrefs.SetString("PurchasedItems", string.Join(",", purchasedItemNames.ToArray()));
        PlayerPrefs.SetString("PurchasedItemActiveStates", string.Join(",", purchasedItemActiveStates.Select(b => b.ToString()).ToArray()));
        // Save the changes to PlayerPrefs immediately
        PlayerPrefs.Save();
    }

    // Load purchased items from player preferences
    private void LoadPurchasedItems()
    {
        // Get the purchased item names and active states from player preferences
        string purchasedItemNamesString = PlayerPrefs.GetString("PurchasedItems", "");
        string purchasedItemActiveStatesString = PlayerPrefs.GetString("PurchasedItemActiveStates", "");
        
        // Check if the purchased item names string is not empty
        if (!string.IsNullOrEmpty(purchasedItemNamesString))
        {
            // Split the purchased item names and active states into arrays
            string[] purchasedItemNames = purchasedItemNamesString.Split(',');
            bool[] purchasedItemActiveStates = purchasedItemActiveStatesString.Split(',').Select(bool.Parse).ToArray();
            
            // Loop through each purchased item
            for (int i = 0; i < purchasedItemNames.Length; i++)
            {
                // Find the purchased item by name in the available items array
                GameObject purchasedItem = Array.Find(availableItems, item => item.name == purchasedItemNames[i]);
                
                // Check if the purchased item exists
                if (purchasedItem != null)
                {
                    purchasedItems.Add(purchasedItem);

                    // Activate the corresponding itemToActivate object if it exists
                    if (i < purchasedItemActiveStates.Length && purchasedItemActiveStates[i])
                    {
                        if (purchasedItem == buyButton.hat1ToBuy)
                        {
                            buyButton.hat1ToBuy.GetComponent<Button>().GetComponent<Image>().color = Color.gray;
                            buyButton.hat4ToActivate.SetActive(true);
                        }
                        else if (purchasedItem == buyButton.hat2ToBuy)
                        {
                            buyButton.hat2ToBuy.GetComponent<Button>().GetComponent<Image>().color = Color.gray;
                            buyButton.hat5ToActivate.SetActive(true);
                        }
                        else if (purchasedItem == buyButton.hat3ToBuy)
                        {
                            buyButton.hat3ToBuy.GetComponent<Button>().GetComponent<Image>().color = Color.gray;
                            buyButton.hat6ToActivate.SetActive(true);
                        }
                    }
                }
            }
        }
    }
    public void BuyItem(int cost, GameObject itemToBuy, GameObject itemToActivate)
    {
        // Check if the player has enough coins to buy the item
        if (coinCount >= cost && !purchasedItems.Contains(itemToBuy))
        {
            // Subtract the cost from the player's coin count
            coinCount -= cost;
            UpdateCoinCountText();
            SaveCoinCount();

            /// Add the purchased item to the inventory
            purchasedItems.Add(itemToBuy);

            // Activate the desired item instead
            itemToActivate.SetActive(true);

            // Disable the item's button and change its color to gray
            Button itemButton = itemToBuy.GetComponent<Button>();
            if (itemButton != null)
            {
                itemButton.interactable = false;
                itemButton.GetComponent<Image>().color = Color.gray;
            }

            // Save the purchased item
            SavePurchasedItems();
        }
    }
}