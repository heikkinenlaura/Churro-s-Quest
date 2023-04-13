using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject inventoryPanel;
    public TMP_Text coinCountText;
    public int coinCount;
    private List<GameObject> purchasedItems = new List<GameObject>();
    [SerializeField] private List<GameObject> items = new List<GameObject>();
    

    private void Start()
    {
        // Load the player's coin count from PlayerPrefs
        coinCount = PlayerPrefs.GetInt("CoinCount", 0);
        UpdateCoinCountText();
        LoadPurchasedItems();

        // Set the initial state of the panels
        shopPanel.SetActive(false);
        inventoryPanel.SetActive(false);
    }

    private void UpdateCoinCountText()
    {
        coinCountText.text = coinCount.ToString() + " ";
    }

    private void SaveCoinCount()
    {
        PlayerPrefs.SetInt("CoinCount", coinCount);
    }
    private void LoadPurchasedItems()
    {
        // Load purchased items from PlayerPrefs
        string purchasedItemsString = PlayerPrefs.GetString("PurchasedItems", "");
        string[] purchasedItemsNames = purchasedItemsString.Split(';');

        if (purchasedItemsNames.Length == 0 || (purchasedItemsNames.Length == 1 && string.IsNullOrEmpty(purchasedItemsNames[0])))
        {
            // No purchased items to load
            Debug.Log("PlayerPrefs is empty");
            return;
        }

        foreach (string itemName in purchasedItemsNames)
        {
            if (string.IsNullOrEmpty(itemName)) continue;
            GameObject item = items.Find(i => i.name == itemName);
            if (item != null)
            {
                // Instantiate a new image of the purchased item and add it to the inventory panel
                GameObject itemImage = Instantiate(item, inventoryPanel.transform);
                purchasedItems.Add(itemImage);

                // Disable the item's button and change its color to gray
                Button itemButton = item.GetComponent<Button>();
                if (itemButton != null)
                {
                    itemButton.interactable = false;
                    itemButton.GetComponent<Image>().color = Color.gray;
                }
            }
        }
    }
    private void SavePurchasedItems()
    {
        // Save purchased items to PlayerPrefs
        string purchasedItemsString = string.Join(";", purchasedItems.ConvertAll(i => i.name).ToArray());

        // Save each purchased item as a separate player preference
        for (int i = 0; i < purchasedItems.Count; i++)
        {
            string key = "PurchasedItem_" + i;
            PlayerPrefs.SetString(key, purchasedItems[i].name);
            PlayerPrefs.Save();
        }

        PlayerPrefs.SetInt("PurchasedItemCount", purchasedItems.Count);
        PlayerPrefs.Save();
    }
    public void BuyItem(int cost, GameObject item)
    {
        // Check if the player has enough coins to buy the item
        if (coinCount >= cost && !purchasedItems.Contains(item))
        {
            // Subtract the cost from the player's coin count
            coinCount -= cost;
            UpdateCoinCountText();
            SaveCoinCount();

            // Add the purchased item to the inventory panel
            GameObject itemImage = Instantiate(item, inventoryPanel.transform);
            purchasedItems.Add(itemImage);

            // Disable the item's button and change its color to gray
            Button itemButton = item.GetComponent<Button>();
            if (itemButton != null)
            {
                itemButton.interactable = false;
                itemButton.GetComponent<Image>().color = Color.gray;
            }

            // Save the purchased item
            SavePurchasedItems();
        }
    }

    public void ShowShopPanel()
    {
        shopPanel.SetActive(true);
    }

    public void HideShopPanel()
    {
        shopPanel.SetActive(false);
    }

    public void ShowInventoryPanel()
    {
        inventoryPanel.SetActive(true);
    }

    public void HideInventoryPanel()
    {
        inventoryPanel.SetActive(false);
    }
}