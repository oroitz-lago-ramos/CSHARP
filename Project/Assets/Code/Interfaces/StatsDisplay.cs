using UnityEngine;
using TMPro;
using System;

public class StatsDisplay : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI defenseText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI accuracyText;
    public TextMeshProUGUI criticalRateText;

    private void Start()
    {
        if (Team.main == null)
        {
            Debug.Log("Team.main is not initialized! Make sure the Team object is in the scene.");
            return; // Stop further execution if Team.main is null
        }

        if (Team.main.members.Length > 0 && Team.main.members[0].currentStats != null)
        {
            Debug.Log("Ok");
            for (int i = 0; i < Team.main.members.Length; i++)
            {
                Debug.Log(Team.main.members[i].name);
            }
        }
        else
        {
            Debug.Log("No members found or currentStats is null in Team.main.");
        }
    }
    public void Update()
    {
        healthText.text = "Health: " + Team.main.members[0].baseStats.health;
        manaText.text = "Mana: " + Team.main.members[0].baseStats.mana;
        attackText.text = "Attack: " + Team.main.members[0].baseStats.attack;
        defenseText.text = "Defense: " + Team.main.members[0].baseStats.defense;
        speedText.text = "Speed: " + Team.main.members[0].baseStats.speed;
        accuracyText.text = "Accuracy: " + Team.main.members[0].baseStats.accuracy;
        criticalRateText.text = "Critical Rate: " + Team.main.members[0].baseStats.criticalRate;
    }
}
