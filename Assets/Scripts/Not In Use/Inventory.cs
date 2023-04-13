using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//public class Inventory : MonoBehaviour
//{
//    public GameObject inventoryPanel;
//    private List<GameObject> items;

//    private void Awake()
//    {
//        // Initialize the items list
//        items = new List<GameObject>();
//    }

//    private void Start()
//    {
//        // Load the inventory items from PlayerPrefs
//        string inventoryItemsString = PlayerPrefs.GetString("InventoryItems", "");
//        if (!string.IsNullOrEmpty(inventoryItemsString))
//        {
//            string[] inventoryItemNames = inventoryItemsString.Split(',');
//            foreach (string itemName in inventoryItemNames)
//            {
//                GameObject item = GameObject.Find(itemName);
//                if (item != null)
//                {
//                    items.Add(item);
//                    item.transform.SetParent(inventoryPanel.transform, false);
//                    item.SetActive(false);
//                }
//            }
//        }
//    }

//    public void AddItem(GameObject item)
//    {
//        // Add the item to the inventory
//        items.Add(item);
//        item.transform.SetParent(inventoryPanel.transform, false);
//        item.SetActive(false);

//        // Save the updated inventory items to PlayerPrefs
//        string[] inventoryItemNames = new string[items.Count];
//        for (int i = 0; i < items.Count; i++)
//        {
//            inventoryItemNames[i] = items[i].name;
//        }
//        string inventoryItemsString = string.Join(",", inventoryItemNames);
//        PlayerPrefs.SetString("InventoryItems", inventoryItemsString);
//    }
//}