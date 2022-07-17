using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private LayerMask _layerMask;

    [Header("Speed")] 
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float velocityReductionOnHitScalar;
    [SerializeField] private float velocityBeforeBeingAbleToShootAgain = 0.03f;

    private Camera _camera;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();
        _lineRenderer.enabled = false;
    }

    private void Update()
    {
        if (_rigidbody.velocity.magnitude > velocityBeforeBeingAbleToShootAgain) return;  // return if currently moving

        if (Input.GetMouseButton(0))
        {
            // Show the line renderer
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(0, GroundedVector(transform.position));  // Shouldn't do this every frame but eh
            
            // Set the end of the line renderer to be where the mouse cursor is
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, _layerMask))
            {
                _lineRenderer.SetPosition(1, GroundedVector(raycastHit.point));
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Setup vectors for shooting direction
            var end = _lineRenderer.GetPosition(1);
            var start = GroundedVector(transform.position);
            var direction = end - start;

            // Shoot self in direction at speed, clamped between min and max
            var speed = Math.Clamp(direction.magnitude * speedMultiplier, minSpeed, maxSpeed);
            _rigidbody.AddForce(direction.normalized * -1f * speed);

            // Hide the line renderer
            _lineRenderer.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Prop>())
        {
            _rigidbody.velocity /= velocityReductionOnHitScalar;
        }
    }

    private Vector3 GroundedVector(Vector3 v)
    {
        // Set vector to ground by zeroing (ish) the Y axis (player grounded position)
        return new Vector3(v.x, transform.position.y, v.z);
    }
}
