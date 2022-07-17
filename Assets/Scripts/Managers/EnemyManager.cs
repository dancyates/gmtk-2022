using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemies;

    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        // Repeatedly spawn enemies
        InvokeRepeating(nameof(SpawnRandomEnemyInRandomPosition), 2f, 2f);
        // CancelInvoke(nameof(SpawnRandomFallerInRandomPosition));
    }

    private void SpawnRandomEnemyInRandomPosition()
    {
        // Spawn random enemy from list, in bounds
        var i = Random.Range(0, _enemies.Count - 1);
        var enemy = Instantiate(_enemies[i], RandomPositionInBounds(_boxCollider.bounds), Quaternion.identity);
        
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
}
