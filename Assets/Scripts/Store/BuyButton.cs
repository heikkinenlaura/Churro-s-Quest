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
    public GameObject hat4ToActivate;
    public GameObject hat5ToActivate;
    public GameObject hat6ToActivate;

    public void BuyHat1()
    {
        store.BuyItem(10, hat1ToBuy, hat4ToActivate);
    }

    public void BuyHat2()
    {
        store.BuyItem(50, hat2ToBuy, hat5ToActivate);
    }

    public void BuyHat3()
    {
        store.BuyItem(80, hat3ToBuy, hat6ToActivate);
    }
}