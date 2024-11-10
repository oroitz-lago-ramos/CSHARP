using System;
using UnityEngine;
public enum ViewType { None, InGameMenu, Inventory, Combat }

public class ViewController : MonoBehaviour
{
    public static ViewController main;
    public static ViewType currentMenu;
    public static bool onCombat;

    public GameObject[] views;
    private bool[] isViewVisible;

    public void Awake()
    {
        ViewController.main = this;
    }
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
        if (Input.GetKeyDown(KeyCode.U) && !ViewController.onCombat)
        {
            ToggleInGameMenu();
        }
        if (Input.GetKeyDown(KeyCode.I) && !ViewController.onCombat)
        {
            ToggleInventory();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !ViewController.onCombat && ViewController.currentMenu is not ViewType.None or ViewType.Combat)
        {
            ToggleView(ViewController.currentMenu);
        }
        // if (combat.end)
    }

    public void ToggleView(ViewType view)
    {
        int index = (int)view - 1;
        if (index >= 0 && index < views.Length)
        {
            isViewVisible[index] = !isViewVisible[index];
            views[index].SetActive(isViewVisible[index]);
            ViewController.currentMenu = ViewController.currentMenu != ViewType.None ? ViewType.None : view;
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
        if (ViewController.currentMenu is ViewType.Inventory or ViewType.None)
        {
            ToggleView(ViewType.Inventory);
        }
    }

    public void ToggleInGameMenu()
    {
        if (ViewController.currentMenu is ViewType.InGameMenu or ViewType.None)
        {
            ToggleView(ViewType.InGameMenu);
        }
    }
}
