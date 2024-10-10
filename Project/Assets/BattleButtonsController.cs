using UnityEngine;

public class BattleButtonsController : MonoBehaviour
{
    public GameObject[] mainButtons;
    public GameObject[] attacksButtons;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        for (int i = 0; i < attacksButtons.Length; i++)
        { attacksButtons[i].SetActive(false); }
    }
    public void OpenAttackMenu()
    {
        for (int i = 0; i < mainButtons.Length; i++)
        {
            mainButtons[i].SetActive(false);
        }
        for (int i = 0; i < attacksButtons.Length; i++)
        { attacksButtons[i].SetActive(true); }
    }

    public void CloseAttackMenu()
    {
        for (int i = 0; i < attacksButtons.Length; i++)
        {
            attacksButtons[i].SetActive(false);
        }
        for (int i = 0; i < mainButtons.Length; i++)
        {
            mainButtons[i].SetActive(true);
        }
    }

    public void OpenMenu()
    {
        for (int i = 0; i < mainButtons.Length; i++)
        {
            mainButtons[i].SetActive(false);
        }
    }

    public void CloseMenu()
    {
        if (!this.gameObject.activeSelf) { return; }
        for (int i = 0; i < mainButtons.Length; i++)
        {
            mainButtons[i].SetActive(true);
        }
    }
}
