using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleButtonsController : MonoBehaviour
{
    public StatBar playerHealthBar;
    public StatBar playerManaBar;
    public StatBar enemyHealthBar;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI manaText;

    public GameObject mainButtons;
    public GameObject attacksButtons;
    public TextMeshProUGUI[] attacksNames;

    private void Start()
    {
        attacksButtons.SetActive(false);
        mainButtons.SetActive(false);
    }

    private void OnEnable()
    {
    }

    private void SetInitialSliderValues()
    {
        var player = Team.main.members.First();

        playerHealthBar.SetMaxValue((int)player.baseStats.health);
        playerHealthBar.SetValue((int)player.currentStats.health);
        healthText.text = player.currentStats.health.ToString() + " / " + player.baseStats.health;
        manaText.text = player.currentStats.mana.ToString() + " / " + player.baseStats.mana.ToString();

        playerManaBar.SetMaxValue((int)player.baseStats.mana);
        playerManaBar.SetValue((int)player.currentStats.mana);

        var enemy = Battle.main.opponent;
        enemyHealthBar.SetMaxValue((int)enemy.baseStats.health);
        enemyHealthBar.SetValue((int)enemy.currentStats.health);
    }

    public void UpdateSliderBars()
    {
        var player = Team.main.members.First();
        playerHealthBar.SetValue((int)player.currentStats.health);
        playerManaBar.SetValue((int)player.currentStats.mana);
        healthText.text = player.currentStats.health.ToString() + " / " + player.baseStats.health;
        manaText.text = player.currentStats.mana.ToString() + " / " + player.baseStats.mana.ToString();

        var enemy = Battle.main.opponent;
        enemyHealthBar.SetValue((int)enemy.currentStats.health);
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
        SetInitialSliderValues();

        if (Input.GetKeyDown(KeyCode.Escape) && ViewController.onCombat && ViewController.currentMenu is not ViewType.None)
        {
            ViewController.main.ToggleView(ViewController.currentMenu);
            mainButtons.SetActive(true);
        }
        if (!Battle.main.script.enabled && !attacksButtons.activeSelf && !Battle.main.opponentTurn && ViewController.currentMenu is ViewType.None)
        {
            mainButtons.SetActive(true);
        }
        else if (Battle.main.script.enabled)
        {
            mainButtons.SetActive(false);
            attacksButtons.SetActive(false);
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
