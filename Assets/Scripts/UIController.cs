using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //Attach Player Controller
    PlayerController playerController;

    //XP
    [SerializeField] Image xp;
    public int currentLevel;
    float maxXpSize = 100;

    //Level
    [SerializeField] TextMeshProUGUI levelText;
    void Start()
    {
        currentLevel = 1;
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        xp.fillAmount = playerController.playerXp / maxXpSize;

        if (playerController.playerXp >= 100)
        {
            playerController.playerXp = 0;
            currentLevel++;
        }

        levelText.text = currentLevel.ToString();
    }
}
