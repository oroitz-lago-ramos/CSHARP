using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleButtonsController : MonoBehaviour
{
    public GameObject mainButtons;
    public GameObject attacksButtons;
    public TextMeshProUGUI[] attacksNames;
   
    private void Start()
    {
        attacksButtons.SetActive(false);
    }
    public void OpenAttackMenu()
    {
        mainButtons.SetActive(false);
        attacksButtons.SetActive(true);
        var classes = new[] { Skills.main.knight, Skills.main.archer, Skills.main.mage };
        var skills = classes[(int)Team.main.members.First().classType];
        for (int i = 0; i < attacksNames.Length; i++)
        {
            attacksNames[i].text = Team.main.members.First().level >= skills[i].minimumLevel ? skills[i].name : "?????";
        }
    }

    public void CloseAttackMenu()
    {   
        attacksButtons.SetActive(false);
        mainButtons.SetActive(true);
    }

    public void OpenMenu()
    {
       mainButtons.SetActive(false);
    }

    public void CloseMenu()
    {
        if (!this.gameObject.activeSelf) { return; }
        mainButtons.SetActive(true);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ViewController.onCombat && ViewController.currentMenu is not ViewType.None)
        {
            ViewController.main.ToggleView(ViewController.currentMenu);
            mainButtons.SetActive(true);
        }
    }

    public void useFirstAttack()
    {
        var classes = new[] { Skills.main.knight, Skills.main.archer, Skills.main.mage };
        var skills = classes[(int)Team.main.members.First().classType];
        if (Team.main.members.First().level < skills[0].minimumLevel) { return; }
        Battle.main.action = ActionType.Attack;
        Battle.main.currentAttack = 0;
        CloseAttackMenu();
    }
    public void useSecondAttack()
    {
        var classes = new[] { Skills.main.knight, Skills.main.archer, Skills.main.mage };
        var skills = classes[(int)Team.main.members.First().classType];
        if (Team.main.members.First().level < skills[1].minimumLevel) { return; }
        Battle.main.action = ActionType.Attack;
        Battle.main.currentAttack = 1;
        CloseAttackMenu();
    }
    public void useThirdAttack()
    {
        var classes = new[] { Skills.main.knight, Skills.main.archer, Skills.main.mage };
        var skills = classes[(int)Team.main.members.First().classType];
        if (Team.main.members.First().level < skills[2].minimumLevel) { return; }
        Battle.main.action = ActionType.Attack;
        Battle.main.currentAttack = 2;
        CloseAttackMenu();
    }
}
