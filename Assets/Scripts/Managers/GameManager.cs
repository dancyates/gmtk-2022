using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int playerScore;
    public bool isGameOver = false;

    [SerializeField] private AudioSource addPointsAudioSource;
    [SerializeField] private AudioSource loseGameAudioSource;
    
    private UIManager _UIManager;

    private void Awake()
    {
        _UIManager = GameObject.FindObjectOfType<UIManager>();
        ResetScoreAndIsGameOverAndEnableControls();
    }

    private void Start()
    {
        _UIManager.ShowGameOverScreen(false);
        isGameOver = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoseGame();
        }

        var prop = other.gameObject.GetComponent<Prop>();
        if (prop)
        {
            AddScore(prop.points);
            addPointsAudioSource.Play();
            Destroy(other.gameObject, 2f);
        }
    }

    public void PlayGame()
    {
        _UIManager.ShowGameOverScreen(false);  // Hide game over UI
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  // Start next level
        ResetScoreAndIsGameOverAndEnableControls();
    }
    
    public void RestartGame()
    {
        _UIManager.ShowGameOverScreen(false);  // Hide game over UI
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Restart current level
        ResetScoreAndIsGameOverAndEnableControls();
    }

    public void LoseGame()
    {
        _UIManager.ShowGameOverScreen(true);
        loseGameAudioSource.Play();
        FindObjectOfType<PlayerController>().enabled = false;  // Disable player controls
        isGameOver = true;
    }

    // Score stuff
    private void ResetScoreAndIsGameOverAndEnableControls()
    {
        playerScore = 0;
        isGameOver = false;
        FindObjectOfType<PlayerController>().enabled = true;  // Enable player controls
    }

    private void AddScore(int amountToAdd)
    {
        playerScore += amountToAdd;
        _UIManager.UpdateScoreText();
    }
}
