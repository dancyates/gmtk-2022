using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    
    public void ShowGameOverScreen(bool shouldShowScreen)
    {
        gameOverScreen.SetActive(shouldShowScreen);
    }

    public void ButtonRestartLevel()
    {
        _gameManager.RestartGame();
    }
}
