using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

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

    void Start()
    {
        TextAttribution();
        SpriteAttribution();
        selectedCharacterBackground[0].gameObject.SetActive(true);
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
    }

    private void TextAttribution()
    {
        if (selectedCharacterIndex < Team.main.members.Length)
        {
            characterName.text = Team.main.members[selectedCharacterIndex].name;
            healthText.text = "Health: " + Team.main.members[selectedCharacterIndex].baseStats.health;
            manaText.text = "Mana: " + Team.main.members[selectedCharacterIndex].baseStats.mana;
            attackText.text = "Attack: " + Team.main.members[selectedCharacterIndex].baseStats.attack;
            defenseText.text = "Defense: " + Team.main.members[selectedCharacterIndex].baseStats.defense;
            speedText.text = "Speed: " + Team.main.members[selectedCharacterIndex].baseStats.speed;
            accuracyText.text = "Accuracy: " + Team.main.members[selectedCharacterIndex].baseStats.accuracy;
            criticalRateText.text = "Crit. Rate: " + Team.main.members[selectedCharacterIndex].baseStats.criticalRate;
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
    }

    private void UpdateSelectedCharacterBackgroundPosition()
    {
        if (selectedCharacterIndex == 0)
        {
            selectedCharacterBackground[0].gameObject.SetActive(true);
            selectedCharacterBackground[1].gameObject.SetActive(false);
            selectedCharacterBackground[2].gameObject.SetActive(false);
        }
        else if (selectedCharacterIndex == 1)
        {
            selectedCharacterBackground[0].gameObject.SetActive(false);
            selectedCharacterBackground[1].gameObject.SetActive(true);
            selectedCharacterBackground[2].gameObject.SetActive(false);
        }
        else if (selectedCharacterIndex == 2)
        {
            selectedCharacterBackground[0].gameObject.SetActive(false);
            selectedCharacterBackground[1].gameObject.SetActive(false);
            selectedCharacterBackground[2].gameObject.SetActive(true);
        }
    }
}
