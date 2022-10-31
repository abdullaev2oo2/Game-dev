using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemSelector : MonoBehaviour
{
    public int currentShopItemIndex;
    public GameObject[] items;

    //public ShopItemBluePrint[] shopItems;
    // Start is called before the first frame update
    void Start()
    {
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
        
    }
}
