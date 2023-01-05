using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    private Transform player_transform;
    private Rigidbody my_body;
    
    // Start is called before the first frame update
    void Start()
    {
        player_transform = this.transform;
        my_body = this.transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInputs();
    }

    void HandleInputs()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Move(Direction.FORWARD);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(Direction.BACKWARD);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Move(Direction.LEFT);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(Direction.RIGHT);
        }
    }

    void Move(Direction direction)
    {
        transform.position += DirectionToVector(direction) * 10 * Time.deltaTime;
        //my_body.AddForce(DirectionToVector(direction) * Time.deltaTime, ForceMode.Impulse);
    }

    Vector3 DirectionToVector(Direction dir)
    {
        switch (dir)
        {
            case(Direction.LEFT):
                return Vector3.left;
            case(Direction.RIGHT):
                return Vector3.right;
            case(Direction.FORWARD):
                return Vector3.forward;
            case(Direction.BACKWARD):
                return Vector3.back;
            default:
                return Vector3.zero;
        }
    }

    enum Direction
    {
        FORWARD, BACKWARD, LEFT, RIGHT
    }
}
