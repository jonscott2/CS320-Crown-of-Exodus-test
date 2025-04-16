using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movespeed = 5f;
    public InputAction playerControlls;
    public Vector2 moveDirection = Vector2.zero;
    Animator animator;

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
            UnityEngine.Debug.LogWarning("Rigidbody2D was not set, trying to auto-assign.");
        }
    }

    private void OnEnable()
    {
        if (playerControlls != null)
        {
            playerControlls.Enable();
            playerControlls.performed += OnMove;
            playerControlls.canceled += OnMove; // Reset when released
        }
    }

    private void OnDisable()
    {
        if (playerControlls != null)
        {
            playerControlls.Disable();
            playerControlls.performed -= OnMove;
            playerControlls.canceled -= OnMove;
        }
    }

    void Update()
    {
        FlipSprite();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * movespeed, moveDirection.y * movespeed);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    void FlipSprite()
    {
        float horizontalinput = moveDirection.x;
        if (horizontalinput > 0f || horizontalinput < 0f)
        {
            bool isFacingRight = transform.localScale.x > 0f;
            if ((isFacingRight && horizontalinput < 0f) || (!isFacingRight && horizontalinput > 0f))
            {
                Vector3 ls = transform.localScale;
                ls.x *= -1f;
                transform.localScale = ls;
            }
        }
    }
}
