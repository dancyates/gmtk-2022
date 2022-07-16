using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FallerManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _fallers;

    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        // Repeatedly spawn enemies
        InvokeRepeating(nameof(SpawnRandomFallerInRandomPosition), 0f, 0.5f);
        // CancelInvoke(nameof(SpawnRandomFallerInRandomPosition));
    }

    private void SpawnRandomFallerInRandomPosition()
    {
        var i = Random.Range(0, _fallers.Count);
        Instantiate(_fallers[i], RandomPositionInBounds(_boxCollider.bounds), Quaternion.identity);
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
