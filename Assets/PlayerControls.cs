using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 10.0f;
    public float boundY = 2.7f;
    private Rigidbody2D rigidBody2D;


    // Use this for initialization
    void Start () {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {

        // Get paddle velocity from the RigidBody
        var paddleVelocity = rigidBody2D.velocity;

        // If we press UP, set velocity to positive speed
        if (Input.GetKey(moveUp))
        {
            paddleVelocity.y = speed;
        }
        // If we press DOWN, set velocity to negative speed
        else if (Input.GetKey(moveDown))
        {
            paddleVelocity.y = -speed;
        }
        // Otherwise don't move at all
        else
        {
            paddleVelocity.y = 0;
        }

        // Set the rigidbody velocity
        rigidBody2D.velocity = paddleVelocity;

        // Get the paddle's position
        var pos = transform.position;

        // Limit the paddle to the bounds of the screen
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }

        // Set the paddle's position
        transform.position = pos;
    }
}
