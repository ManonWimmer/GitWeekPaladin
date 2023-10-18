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

    // Anim :
    //[SerializeField] Animator anim;

    private bool _isFacingRight;
    private Vector2 _movement;

    // Mouse :
    private Vector2 _mousePosition;

    // Dash :
    [SerializeField] float _dashSpeed = 10f;
    [SerializeField] float _dashMinDuration = 0.1f;
    [SerializeField] float _dashMaxDuration = 1f;
    [SerializeField] float _dashCooldown = 5f;

    [SerializeField] private LineRenderer _lineRendererDashLine;


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
        _lineRendererDashLine.enabled = false;
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

    private void CheckMovementDirection()
    {
        if (_isFacingRight && _movement.x < 0) // Face à la droite mais va à gauche
        {
            Flip();
        }
        else if (!_isFacingRight && _movement.x > 0) // Face à la gauche mais va à droite
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);  
    }

    private void UpdateAnimations()
    {
        /*
        anim.SetFloat("xVelocity", _movement.x); // -1 gauche 0 statique 1 droite
        anim.SetFloat("yVelocity", _movement.y); // -1 bas 0 statique 1 haut
        anim.SetBool("isDashing", _isDashing);
        */
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


        CheckMovementDirection();
        UpdateAnimations();

        // Mouse position :
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        // Dash :
        if (Input.GetKeyDown(KeyCode.Mouse0) && _canDash)
        {
            _lineRendererDashLine.enabled = true;
            _isChargingDash = true;
            StartCoroutine(ChargeDash());
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
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

        while (Input.GetKey(KeyCode.Mouse0) && _isChargingDash)
        {
            Vector2 futureDashPosition = CalculateFutureDashPosition();
            _lineRendererDashLine.SetPosition(0, _rb.position);
            _lineRendererDashLine.SetPosition(1, futureDashPosition);


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
        _lineRendererDashLine.enabled = false;
    }
}
