using System;
using UnityEngine;
public enum ViewType { None, InGameMenu, Inventory, Combat }

public class ViewController : MonoBehaviour
{
    public static ViewType currentMenu;
    public static bool onCombat;

    public GameObject[] views;
    [HideInInspector] public bool onCombat;
    private bool[] isViewVisible;

    private void Start()
    {
        isViewVisible = new bool[views.Length];

        for (int i = 0; i < views.Length; i++)
        {
            views[i].SetActive(false);
            isViewVisible[i] = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ViewController.currentMenu is ViewType.InGameMenu or ViewType.None && !ViewController.onCombat)
            {
                ToggleView(ViewType.InGameMenu);
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (ViewController.currentMenu is ViewType.Inventory or ViewType.None && !ViewController.onCombat)
            {
                ToggleView(ViewType.Inventory);
            }
        }
        // if (combat.end)
    }

    private void ToggleView(ViewType view)
    {
        int index = (int)view - 1;
        if (index >= 0 && index < views.Length)
        {
            isViewVisible[index] = !isViewVisible[index];
            views[index].SetActive(isViewVisible[index]);
            if (ViewController.currentMenu != ViewType.None)
            {
                ViewController.currentMenu = ViewType.None;
            }
            else
            {
                currentMenu = view;
            }
        }
    }

    public void ToggleCombat()
    {
        int index = (int)ViewType.Combat - 1;
        if (index >= 0 && index < views.Length)
        {
            isViewVisible[index] = !isViewVisible[index];
            views[index].SetActive(isViewVisible[index]);
            ViewController.onCombat = !ViewController.onCombat;
        }
    }

    public void ToggleInventory()
    {
        ToggleView(ViewType.Inventory);
    }

    public void ToggleInGameMenu()
    {
        ToggleView(ViewType.InGameMenu);
    }
}
