using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log("Hello :)");
    }
}
