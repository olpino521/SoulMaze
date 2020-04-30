using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DebugStats : MonoBehaviour
{
    public PlayerStats playerStats;
    public TextMeshProUGUI playerHPText;
    public TextMeshProUGUI playerSoulShardsText;
    public TextMeshProUGUI fpsText;
    //Want to show fps
    public bool showFPS;
    public bool showPlayerStats;

    float deltaTime;

    // Update is called once per frame
    void Update()
    {
        SetAllTextBlank();
        if (showFPS)
        {
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
            float fps = 1.0f / deltaTime;
            fpsText.text = Mathf.Ceil(fps).ToString() + " FPS";
        }
        if (showPlayerStats)
        {
            playerHPText.text = "Player HP: " + playerStats.CurrentHealth + "/" + playerStats.maxHealth;
            playerSoulShardsText.text = "# Soul Shards: " + playerStats.soulShards;
        }
        
    }

    void SetAllTextBlank()
    {
        playerSoulShardsText.text = "";
        playerHPText.text = "";
        fpsText.text = "";
    }
}
