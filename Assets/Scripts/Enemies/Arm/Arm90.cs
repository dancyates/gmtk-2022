using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm90 : MonoBehaviour
{
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerController = other.gameObject.GetComponent<PlayerController>();
        if (playerController)
        {
            _gameManager.LoseGame();
        }
    }
}
