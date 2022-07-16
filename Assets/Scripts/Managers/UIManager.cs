using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text scoreText;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void ShowGameOverScreen(bool shouldShowScreen)
    {
        gameOverScreen.SetActive(shouldShowScreen);
    }

    public void ButtonRestartLevel()
    {
        _gameManager.RestartGame();
    }

    public void UpdateScoreText()
    {
        scoreText.text = _gameManager.playerScore.ToString();
    }
}
