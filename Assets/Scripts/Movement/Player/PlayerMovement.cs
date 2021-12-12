using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private float maxSpeed = 10;
    private PlayerInput playerInput;
    private Rigidbody rb;
    private Vector3 mouseWorldPosition;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        playerInput.AssignPlayerInput();
        RotatePlayerTowardsMouse();
        Move();
    }

    public void Move()
    {
        Vector3 movement = new Vector3(playerInput.HorizontalMovement, 0.0f, playerInput.VerticalMovement);
        rb.AddForce(movement * moveSpeed, ForceMode.Acceleration);
    }   

    public void RotatePlayerTowardsMouse()
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
