using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public int cost;
    public GameObject item;
    public Store store;

    public GameObject hat1ToBuy;
    public GameObject hat2ToBuy;
    public GameObject hat3ToBuy;
    public GameObject hat4ToBuy;
    public GameObject hat1ToActivate;
    public GameObject hat2ToActivate;
    public GameObject hat3ToActivate;
    public GameObject hat4ToActivate;

    public void BuyHat1()
    {
        store.BuyItem(10, hat1ToBuy, hat1ToActivate);
    }

    public void BuyHat2()
    {
        store.BuyItem(50, hat2ToBuy, hat2ToActivate);
    }

    public void BuyHat3()
    {
        store.BuyItem(80, hat3ToBuy, hat3ToActivate);
    }
    public void BuyHat4()
    {
        store.BuyItem(150, hat4ToBuy, hat4ToActivate);
    }
}