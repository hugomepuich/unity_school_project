using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody body;

    public float speed = 3;
    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        HandleInputs();
        Vector3 newRot = Camera.main.transform.rotation.eulerAngles;
        newRot.y = 0;
        //transform.rotation = Quaternion.Euler(newRot);
    }

    private void HandleInputs()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Move(Direction.Forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(Direction.Backward);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Move(Direction.Left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(Direction.Right);
        }
    }

    private void Move(Direction dir)
    {
        Vector3 direction = DirectionToVector3(dir);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        
    }
    
    private enum Direction 
    {
        Up, Down, Left, Right, Forward, Backward
    }

    private Vector3 DirectionToVector3(Direction dir)
    {
        return dir switch
        {
            Direction.Up => Vector3.up,
            Direction.Down => Vector3.down,
            Direction.Left => Vector3.left,
            Direction.Right => Vector3.right,
            Direction.Forward => Vector3.forward,
            Direction.Backward => Vector3.back,
            _ => Vector3.zero
        };
    }
}
