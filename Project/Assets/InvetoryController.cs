using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvetoryController : MonoBehaviour
{
    public Image[] itemsImages;
    public TextMeshProUGUI[] itemsText;
    
    private void Update()
    {
        
    }

    private void OnEnable()
    {
        itemsImages.ToList().ForEach(item => item.enabled = false);
        var items = Inventory.main.items;
        var itemTypes = items.Keys.ToArray();
        var itemAmounts = items.Values.ToArray();
        for (int i = 0; i < items.Count; i++)
        {
            itemsImages[i].enabled = true;
            itemsImages[i].sprite = itemTypes[i].sprite;
            itemsImages[i].preserveAspect = true;
        }
    }

    private void OnDisable()
    {
    }
}
