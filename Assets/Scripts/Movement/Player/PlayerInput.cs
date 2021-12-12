using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
        private float horizontalMovement, verticalMovement;
        private bool sprinting;

        public float HorizontalMovement { get => horizontalMovement; set => horizontalMovement = value; }
        public float VerticalMovement { get => verticalMovement; set => verticalMovement = value; }
        public bool Sprinting { get => sprinting; set => sprinting = value; }

        public void ReadPlayerInput()
        {
            HorizontalMovement = Input.GetAxisRaw("Horizontal");
            VerticalMovement = Input.GetAxisRaw("Vertical");
            Sprinting = Input.GetButton("Sprint");
        }
 
}
