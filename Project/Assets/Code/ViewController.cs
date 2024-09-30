using UnityEngine;

public class ViewController : MonoBehaviour
{
    public enum ViewType { IngameMenu }

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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleView(ViewType.IngameMenu);
        }
    }

    private void ToggleView(ViewType view)
    {
        int index = (int)view;
        if (index >= 0 && index < views.Length)
        {
            isViewVisible[index] = !isViewVisible[index];
            views[index].SetActive(isViewVisible[index]);
        }
    }
}