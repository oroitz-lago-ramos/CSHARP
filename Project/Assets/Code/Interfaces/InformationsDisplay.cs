using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class InformationsDisplay : MonoBehaviour
{
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI accuracyText;
    public TextMeshProUGUI criticalRateText;
    public int selectedCharacterIndex = 0;

    public Image[] selectedCharacterBackground;

    public Image[] images;

    private SpriteRenderer playerSprite;

    void Start()
    {
        selectedCharacterBackground[0].gameObject.SetActive(true);
        playerSprite = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        TextAttribution();
        SpriteAttribution();

    }

    void Update()
    {
        TextAttribution();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (selectedCharacterIndex > 0)
            {
                selectedCharacterIndex -= 1;
                UpdateSelectedCharacterBackgroundPosition();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (selectedCharacterIndex < 2)
            {
                selectedCharacterIndex += 1;
                UpdateSelectedCharacterBackgroundPosition();
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (selectedCharacterIndex < 2)
            {
                selectedCharacterIndex += 1;
                UpdateSelectedCharacterBackgroundPosition();
            }
            else
            {
                selectedCharacterIndex = 0;
                UpdateSelectedCharacterBackgroundPosition();
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Team.main.Swap(selectedCharacterIndex);
            selectedCharacterIndex = 0;
            SpriteAttribution();
            UpdateSelectedCharacterBackgroundPosition();
            if (ViewController.onCombat)
            {
                Battle.main.action = ActionType.TeamSwap;
                Battle.main.player = Team.main.members.First();
                ViewController.main.ToggleInGameMenu();
            }
        }
    }

    private void TextAttribution()
    {
        if (selectedCharacterIndex < Team.main.members.Length)
        {
            var member = Team.main.members[selectedCharacterIndex];
            characterName.text = member.name;
            healthText.text = "Health: " + member.currentStats.health + "/" + member.baseStats.health;
            manaText.text = "Mana: " + member.currentStats.mana + "/" + member.baseStats.mana;
            attackText.text = "Attack: " + member.baseStats.attack;
            defenseText.text = "Defense: " + member.baseStats.defense;
            speedText.text = "Speed: " + member.baseStats.speed;
            accuracyText.text = "Accuracy: " + member.baseStats.accuracy;
            criticalRateText.text = "Crit. Rate: " + member.baseStats.criticalRate;
        }
        else
        {
            characterName.text = "None";
            healthText.text = "None";
            manaText.text = "None";
            attackText.text = "None";
            defenseText.text = "None";
            speedText.text = "None";
            accuracyText.text = "None";
            criticalRateText.text = "None";
        }
    }

    private void SpriteAttribution()
    {
        for (int i = 0; i < Team.main.members.Length; i++)
        {
            images[i].sprite = Team.main.members[i].sprite;
        }
        playerSprite.sprite = Team.main.members[0].sprite;
    }

    private void UpdateSelectedCharacterBackgroundPosition()
    {
        for (int i = 0; i < Team.main.members.Length; i++)
        {
            if (i == selectedCharacterIndex)
            {
                selectedCharacterBackground[i].gameObject.SetActive(true);
            }
            else
            {
                selectedCharacterBackground[i].gameObject.SetActive(false);
            }
        }
    }
}
