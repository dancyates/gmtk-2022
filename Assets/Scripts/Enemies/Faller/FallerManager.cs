using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FallerManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _fallers;

    [SerializeField] private float minSpawnTime = 1f;
    [SerializeField] private float maxSpawnTime = 3f;
    
    private GameManager _gameManager;
    private BoxCollider _boxCollider;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        StartCoroutine(SpawnerCoroutine());
    }

    IEnumerator SpawnerCoroutine()
    {
        // Spawn fallers forever
        while (!_gameManager.isGameOver)
        {
            var timeToWait = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(timeToWait);

            SpawnRandomFallerInRandomPosition();
        }
    }

    private void SpawnRandomFallerInRandomPosition()
    {
        var i = Random.Range(0, _fallers.Count);
        Instantiate(_fallers[i], RandomPositionInBounds(_boxCollider.bounds), Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)));
    }

    private Vector3 RandomPositionInBounds(Bounds bounds)
    {
        // Get a random position, given a set of Bounds
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}
