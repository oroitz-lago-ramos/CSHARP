using UnityEngine;

public class InGameMenuController : MonoBehaviour
{
    private bool isMenuVisible = false;

    private void Start()
    {
        Debug.Log("Set active false");
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc key pressed");
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        Debug.Log("Toggling Menu");
        isMenuVisible = !isMenuVisible;
        this.gameObject.SetActive(isMenuVisible);
    }
}