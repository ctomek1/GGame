using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody rb;
    private PlayerInput playerInput;
    private Vector3 mouseWorldPosition;


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    public void HandleMovement()
    {
        playerInput.ReadPlayerInput();
        RotatePlayerTowardsMouse();
        Move();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(playerInput.HorizontalMovement, 0.0f, playerInput.VerticalMovement);
        rb.AddForce(movement * moveSpeed, ForceMode.Acceleration);
    }   

    private void RotatePlayerTowardsMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            mouseWorldPosition = raycastHit.point;
            mouseWorldPosition.y = transform.position.y;
            Vector3 aimDirection = (mouseWorldPosition - transform.position).normalized;
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
    }
}
