using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UIManager _UIManager;
    public int playerScore;

    private void Awake()
    {
        _UIManager = GameObject.FindObjectOfType<UIManager>();
        ResetScore();
    }

    private void Start()
    {
        _UIManager.ShowGameOverScreen(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _UIManager.ShowGameOverScreen(true);
        }

        var prop = other.gameObject.GetComponent<Prop>();
        if (prop)
        {
            AddScore(prop.points);
            Destroy(other.gameObject, 2f);
        }
    }

    public void RestartGame()
    {
        _UIManager.ShowGameOverScreen(false);  // Hide game over UI
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Restart current level
        ResetScore();
    }

    // Score stuff
    private void ResetScore()
    {
        playerScore = 0;
    }

    private void AddScore(int amountToAdd)
    {
        playerScore += amountToAdd;
        _UIManager.UpdateScoreText();
    }
}
