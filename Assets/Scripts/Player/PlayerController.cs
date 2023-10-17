using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ----- FIELDS ----- //
    // Movement :
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _moveSpeed;
    [SerializeField] Camera _camera;

    private Vector2 _movement;

    // Mouse :
    private Vector2 _mousePosition;

    // Dash :
    [SerializeField] float _dashSpeed = 10f;
    [SerializeField] float _dashMinDuration = 0.1f;
    [SerializeField] float _dashMaxDuration = 1f;
    [SerializeField] float _dashCooldown = 5f;

    private bool _isDashing = false;
    private bool _canDash = true;
    private float _currentChargeTime = 0f;
    private float _lastDashTime = 0f;
    private bool _isChargingDash = false;

    // Collider / Trigger:
    [SerializeField] Collider2D _collider;
    [SerializeField] Collider2D _trigger;

    // ----- FIELDS ----- //

    private void Start()
    {
        EnableCollider();
    }

    private void EnableCollider()
    {
        _collider.enabled = true;
        _trigger.enabled = false;
    }

    private void EnableTrigger()
    {
        _collider.enabled = false;
        _trigger.enabled = true;
    }

    private void Update()
    {
        if (_isDashing)
        {
            return; // Dashing -> Can't move
        }

        if (!_canDash && Time.time - _lastDashTime >= _dashCooldown)
        {
            _canDash = true;
        }

        // Movement inputs :
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        // Mouse position :
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        //Debug.DrawLine(transform.position, _mousePosition);

        Vector2 futureDashPosition = CalculateFutureDashPosition();

        // Draw a line from the player to the future dash position while charging the dash.
        if (_isChargingDash)
        {
            Debug.DrawLine(_rb.position, futureDashPosition, Color.red);
        }

        // Dash :
        if (Input.GetKeyDown(KeyCode.Space) && _canDash)
        {
            _isChargingDash = true;
            StartCoroutine(ChargeDash());
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isChargingDash = false;
        }
    }

    private Vector2 CalculateFutureDashPosition()
    {
        float chargePercentage = Mathf.Clamp01(_currentChargeTime / (_dashMaxDuration * 5));
        float dashDuration = Mathf.Lerp(_dashMinDuration, _dashMaxDuration, chargePercentage);

        Vector2 direction = (_mousePosition - _rb.position).normalized;
        Vector2 dashVelocity = direction * _dashSpeed;

        return _rb.position + dashVelocity * dashDuration;
    }

    private IEnumerator ChargeDash()
    {
        //Debug.Log("charge dash");
        _currentChargeTime = 0.0f;

        while (Input.GetKey(KeyCode.Space) && _isChargingDash)
        {
            if (_currentChargeTime >= (_dashMaxDuration * 5)) // Max charge
            {
                _currentChargeTime = (_dashMaxDuration * 5);
            }
            else // Increase charge time
            {
                _currentChargeTime += Time.deltaTime;
            }
            
            yield return null;
        }

        //Debug.Log(_currentChargeTime);
        StartCoroutine(Dash()); // Dash with currentChargeTime
    }


    private void FixedUpdate()
    {
        if (_isDashing)
        {
            return; // Dashing -> Can't move
        }

        // Change player position :
        _rb.MovePosition(_rb.position + _movement * _moveSpeed * Time.fixedDeltaTime);
    }

    private IEnumerator Dash()
    {
        if (_isDashing)
        {
            yield break; // Dashing -> Can't dash anymore
        }

        Vector2 lookDirection = _mousePosition - _rb.position;

        // Percentage of dash :
        float chargePercentage = Mathf.Clamp01(_currentChargeTime / (_dashMaxDuration * 5));
        //Debug.Log("percentage : " + chargePercentage);

        // Final duration of dash :
        float dashDuration = Mathf.Lerp(_dashMinDuration, _dashMaxDuration, chargePercentage);
        //Debug.Log("distance : " + dashDuration);

        _isDashing = true;

        // Dash :
        EnableTrigger();
        _rb.velocity = lookDirection.normalized * _dashSpeed;
        yield return new WaitForSeconds(dashDuration);

        // Values back to normal :
        _isDashing = false;
        _canDash = false;
        _lastDashTime = Time.time; // For cooldown

        EnableCollider();
    }


}
