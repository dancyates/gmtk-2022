using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float waitTimeBeforeStarting;

    [SerializeField] private List<GameObject> _enemies;
    [SerializeField] private float minFrequency;
    [SerializeField] private float maxFrequency;
    
    [SerializeField] private GameObject armSwipe;
    [SerializeField] private float armSwipeMinFrequency;
    [SerializeField] private float armSwipeMaxFrequency;
    [SerializeField] private List<Transform> armSwipeSpawnPoints;

    private GameManager _gameManager;
    private BoxCollider _boxCollider;
    private int numberSpawned;
    

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        StartCoroutine(SpawnerCoroutine());
        StartCoroutine(SpawnArmSwipeCoroutine());
    }

    IEnumerator SpawnerCoroutine()
    {
        // Wait for x seconds initially before kicking off the madness
        yield return new WaitForSeconds(waitTimeBeforeStarting);
        
        // Spawn enemies forever
        while (!_gameManager.isGameOver)
        {
            numberSpawned++;

            var amountToSubtract = (numberSpawned / 5f) * 0.1f;

            var timeToWait = Random.Range(minFrequency - amountToSubtract, maxFrequency - amountToSubtract);
            var clampedTimeToWait = Math.Clamp(timeToWait, 0.2f, 5f);

            SpawnRandomEnemyInRandomPosition();
            yield return new WaitForSeconds(clampedTimeToWait);
        }
    }

    private void SpawnRandomEnemyInRandomPosition()
    {
        // Spawn random enemy from list, in bounds
        var i = Random.Range(0, _enemies.Count - 1);
        var rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);
        var enemy = Instantiate(_enemies[i], RandomPositionInBounds(_boxCollider.bounds), rotation);
        
        // Destroy enemy after animation is complete
        Destroy(enemy, enemy.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length);
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

    IEnumerator SpawnArmSwipeCoroutine()
    {
        // Wait for x seconds initially before kicking off the madness
        yield return new WaitForSeconds(waitTimeBeforeStarting);

        while (!_gameManager.isGameOver)
        {
            // Wait random amount of time before spawning arm swipe
            yield return new WaitForSeconds(Random.Range(armSwipeMinFrequency, armSwipeMaxFrequency));
        
            // Get random spawn point
            var i = Random.Range(0, armSwipeSpawnPoints.Count - 1);
            var spawnPoint = armSwipeSpawnPoints[i];
            var arm = Instantiate(armSwipe, spawnPoint);   
        }
    }
}
