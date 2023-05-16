using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InputController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float _moveSpeed;
    public Vector2 DirectionOfView;
    public GameObject ArrowPrefab;
    private GameObject _instantiatedArrow;
    public float raycastDistance = 10f;
    private bool isFacingRight = true;
    public Vector2 _lastRaycastDirection;

    private void Start()
    {
        _instantiatedArrow = Instantiate(ArrowPrefab, DirectionOfView * raycastDistance, Quaternion.identity);
        _lastRaycastDirection = DirectionOfView;
    }
    

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(_joystick.Horizontal * _moveSpeed, _joystick.Vertical * _moveSpeed);
        if ((_joystick.Horizontal > 0 && !isFacingRight) || (_joystick.Horizontal < 0 && isFacingRight))
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, -180f, 0f);
        }
        
        float joystickX = _joystick.Horizontal;
        float joystickY = _joystick.Vertical;
        // Calculate raycast direction from joystick input
        Vector2 raycastDirection = new Vector2(joystickX, joystickY).normalized;
        DirectionOfView = raycastDirection;
        
        if (raycastDirection != Vector2.zero)
        {
            _lastRaycastDirection = raycastDirection;
        }
    }
    
    private void LateUpdate()
    {
        // Update the arrow position based on the hero's position and raycast direction
        Vector2 raycastOrigin = transform.position;
        _instantiatedArrow.transform.position = raycastOrigin + _lastRaycastDirection * raycastDistance;
        float angle = Mathf.Atan2(_lastRaycastDirection.y, _lastRaycastDirection.x) * Mathf.Rad2Deg + 180f;
        _instantiatedArrow.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
    private void OnDrawGizmos()
    {
        // Draw the raycast in the Scene view
        Vector2 raycastOrigin = transform.position;
        float joystickX = _joystick?.Horizontal ?? 0f;
        float joystickY = _joystick?.Vertical ?? 0f;
        Vector2 raycastDirection = new Vector2(joystickX, joystickY).normalized;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(raycastOrigin, raycastOrigin + raycastDirection * raycastDistance);
        
    }
}
