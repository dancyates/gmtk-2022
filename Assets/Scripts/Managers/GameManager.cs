using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UIManager _UIManager;

    private void Awake()
    {
        _UIManager = GameObject.FindObjectOfType<UIManager>();
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
    }

    public void RestartGame()
    {
        _UIManager.ShowGameOverScreen(false);  // Hide game over UI
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Restart current level
    }
}
