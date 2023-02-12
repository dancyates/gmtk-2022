using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faller : MonoBehaviour
{
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        var playerController = other.gameObject.GetComponent<PlayerController>();
        if (playerController)
        {
            _gameManager.LoseGame();
            playerController.enabled = false;
        }
        
        Destroy(transform.gameObject, 0.1f);
    }
}
