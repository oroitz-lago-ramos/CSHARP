using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            var itemTypes = Inventory.main.items.Keys.ToArray();
            itemTypes[selectedItemIndex].Use(ref Team.main.members.First().baseStats.health);
            Inventory.main.OnItemUsed(itemTypes[selectedItemIndex]);
            selectedItemIndex = Inventory.main.items.Count == 0 ? -1 : 0;
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
        for (int i = 0; i < items.Count; i++)
        {
            itemsImages[i].enabled = true;
            itemsImages[i].sprite = itemTypes[i].sprite;
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
