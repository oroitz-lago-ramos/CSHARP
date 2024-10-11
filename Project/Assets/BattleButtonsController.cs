using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleButtonsController : MonoBehaviour
{
    public GameObject[] mainButtons;
    public GameObject[] attacksButtons;
    public TextMeshProUGUI[] attacksNames;
   
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
        var classes = new[] { Skills.main.knight, Skills.main.archer, Skills.main.mage };
        var skills = classes[(int)Team.main.members.First().classType];
        for (int i = 0; i < attacksNames.Length; i++)
        {
            attacksNames[i].text = skills[i].name;
        }
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

    public void Update()
    {
        if (Battle.main.currentTurnEnded)
        {
            for (int i = 0; i < mainButtons.Length; i++)
            {
                mainButtons[i].SetActive(true);
            }
        }
    }
}
