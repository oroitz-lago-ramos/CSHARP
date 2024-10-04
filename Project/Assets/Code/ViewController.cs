using UnityEngine;
public enum ViewType { None, IngameMenu, Inventory }

public class ViewController : MonoBehaviour
{
    public static ViewType currentMenu;

    public GameObject[] views;
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
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            if (ViewController.currentMenu is ViewType.IngameMenu or ViewType.None)
            {
                ToggleView(ViewType.IngameMenu);
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (ViewController.currentMenu is ViewType.Inventory or ViewType.None)
            {
                ToggleView(ViewType.Inventory);
            }
        }
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
}