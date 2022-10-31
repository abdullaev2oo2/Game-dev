using TMPro;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ShopManager : MonoBehaviour
{
    public int currentShopItemIndex;
    public GameObject[] items;

    public ShopItemBluePrint[] shopItems;
    public Button buyButton;
    public Text buyButtonText;
    public Text CoinsText;
    // Start is called before the first frame update
    void Start()
    {
        foreach (ShopItemBluePrint shopitem in shopItems)
        {
            if(shopitem.price == 0)
            {
                shopitem.isUnlocked = true;
            }else
            {
                shopitem.isUnlocked = PlayerPrefs.GetInt(shopitem.name, 0) == 0 ? false : true; 
            }
        }

        currentShopItemIndex = PlayerPrefs.GetInt("SelectedShopItem", 0);
        foreach (GameObject item in items)
        {   
            item.SetActive(false);

            items[currentShopItemIndex].SetActive(true);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        //CoinsText.text = "COINS: " + PlayerManager.numberOfCoins.ToString();
        CoinsText.text = "COINS: " + PlayerPrefs.GetInt("NumberOfCoins", 0);
        updateUI();
    }

    public void ChangeNext()
    {
        items[currentShopItemIndex].SetActive(false);

        currentShopItemIndex++;

        if(currentShopItemIndex == items.Length)
            currentShopItemIndex = 0;

        items[currentShopItemIndex].SetActive(true);

        ShopItemBluePrint item = shopItems[currentShopItemIndex];
        if (!item.isUnlocked) return;

        PlayerPrefs.SetInt("SelectedShopItem", currentShopItemIndex);
    }    
    public void ChangePrev()
    {
        items[currentShopItemIndex].SetActive(false);

        currentShopItemIndex--;

        if(currentShopItemIndex == -1)
            currentShopItemIndex = items.Length - 1;

        items[currentShopItemIndex].SetActive(true);

        ShopItemBluePrint item = shopItems[currentShopItemIndex];
        if (!item.isUnlocked) return;
        PlayerPrefs.SetInt("SelectedShopItem", currentShopItemIndex);
    }

    public void UnlockCar()
    {
        ShopItemBluePrint item = shopItems[currentShopItemIndex];

        PlayerPrefs.SetInt(item.name, 1);
        PlayerPrefs.SetInt("SelectedShopItem", currentShopItemIndex);
        item.isUnlocked = true;
        PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins") - item.price);

    }

    public void updateUI()
    {
        ShopItemBluePrint item = shopItems[currentShopItemIndex];
        if(item.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
        }else
        {
            buyButton.gameObject.SetActive(true);
            buyButtonText.text = "BUY -" + item.price;
            if(item.price > PlayerManager.numberOfCoins)
            {
                buyButton.interactable = false;
            }else
            {
                buyButton.interactable = true;
            }
        }
    }

}
