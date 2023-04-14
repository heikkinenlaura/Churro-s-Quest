using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public int cost;
    public GameObject item;
    public Store store;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(BuyItem);
    }

    private void BuyItem()
    {
        store.BuyItem(cost, item);
    }
}