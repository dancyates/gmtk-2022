using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Animator scoreTextAnimator;
    [SerializeField] private GameObject tutorialScreen1;
    [SerializeField] private GameObject tutorialScreen2;

    private GameManager _gameManager;
    private readonly int PlayBounceTrigger = Animator.StringToHash("PlayBounceTrigger");

    // Unity
    private void Awake()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        UpdateScoreText();
    }

    // Buttons
    public void ButtonRestartLevel()
    {
        _gameManager.RestartGame();
    }

    public void ButtonMainMenuPlayGame()
    {
        tutorialScreen1.SetActive(false);
        tutorialScreen2.SetActive(false);
        _gameManager.PlayGame();
    }

    public void ButtonMainMenuTutorial()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ButtonMainMenuQuitGame()
    {
        // Note: doesn't work in-editor but does when built
        Application.Quit();
    }

    // Helpers
    public void ShowGameOverScreen(bool shouldShowScreen)
    {
        gameOverScreen.SetActive(shouldShowScreen);
    }
    
    public void UpdateScoreText()
    {
        if (scoreTextAnimator.gameObject.activeSelf)
        {
            scoreTextAnimator.SetTrigger(PlayBounceTrigger);
        }
        scoreText.text = _gameManager.playerScore.ToString();
    }

    public void ButtonNextTutorialScreen1()
    {
        tutorialScreen1.SetActive(false);
        tutorialScreen2.SetActive(true);
    }
}
