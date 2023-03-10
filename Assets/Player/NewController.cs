using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewController : MonoBehaviour
{
    public float base_speed = 15f;
    public float moveSpeed = 100;
    public float jumpForce = 3.0f;

    public bool isGrounded = false;
    public LayerMask groundLayers;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(transform.position, 0.5f, groundLayers);

        
        
        // Handle movement input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = transform.TransformDirection(movement);
        movement *= moveSpeed * Time.deltaTime; 
        rb.MovePosition(rb.position + movement);
        //rb.AddForce(rb.position + movement, ForceMode.Impulse);

        /*if (transform.parent)
        {
            transform.localPosition = rb.position;
        }*/

        // Handle jumping input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
    }
}
