using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InvetoryController : MonoBehaviour
{
    public Image[] itemsImages;
    public Image[] selectedItemsBackgrounds;
    public TextMeshProUGUI[] itemsText;

    private int selectedItemIndex;
    
    private void Update()
    {
        UpdateItems();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (selectedItemIndex > 0)
            {
                selectedItemIndex -= 1;
                UpdateSelectedItem();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (selectedItemIndex < Inventory.main.items.Count - 1)
            {
                selectedItemIndex += 1;
                UpdateSelectedItem();
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (selectedItemIndex < Inventory.main.items.Count - 1)
            {
                selectedItemIndex += 1;
                UpdateSelectedItem();
            }
            else
            {
                selectedItemIndex = 0;
                UpdateSelectedItem();
            }
        }
        if (Input.GetKeyDown(KeyCode.Return) && Inventory.main.items.Count > 0)
        {        
            var itemTag = Inventory.main.items.Keys.ToArray()[this.selectedItemIndex];
            Enum.TryParse<ItemType>(itemTag,false,out var itemType);
            var itemProfile = Items.main.list[(int)itemType];
            itemProfile.Use(itemTag);
            if(Inventory.main.items.ContainsKey(itemTag)){
                if (Inventory.main.items[itemTag] <= 1) { Inventory.main.items.Remove(itemTag);}
                else {Inventory.main.items[itemTag] -= 1;}
            }
            if (ViewController.onCombat)
            {
                Battle.main.action = ActionType.ItemUse;
                Battle.main.currentItem = itemProfile.name;
            }
        }
    }

    private void OnEnable()
    {
        selectedItemIndex = Inventory.main.items.Count == 0 ? -1 : 0;
        UpdateItems();
    }

    private void UpdateSelectedItem()
    {
        for (int i = 0; i < Inventory.main.items.Count; i++)
        {
            if (i == selectedItemIndex)
            {
                selectedItemsBackgrounds[i].gameObject.SetActive(true);
            }
            else
            {
                selectedItemsBackgrounds[i].gameObject.SetActive(false);
            }
        }
    }

    private void UpdateItems()
    {
        itemsImages.ToList().ForEach(item => item.enabled = false);
        itemsText.ToList().ForEach(item => item.enabled = false);
        selectedItemsBackgrounds.ToList().ForEach(item => item.gameObject.SetActive(false));

        var items = Inventory.main.items;
        var itemTypes = items.Keys.ToArray();
        var itemAmounts = items.Values.ToArray();

        if (items.Count == 0) {selectedItemIndex = -1;}
        else if (items.Count == 1) {selectedItemIndex = 0;}
        for (int i = 0; i < items.Count; i++)
        {
            Enum.TryParse<ItemType>(itemTypes[i],out var itemType);
            itemsImages[i].enabled = true;
            itemsImages[i].sprite = Items.main.list[(int)itemType].sprite;
            itemsImages[i].preserveAspect = true;

            itemsText[i].enabled = true;
            itemsText[i].text = itemAmounts[i].ToString();
        }
        if (selectedItemIndex >= 0)
        {
            selectedItemsBackgrounds[selectedItemIndex].gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
    }
}
