using UnityEngine;

public class BallControl : MonoBehaviour {

    private Rigidbody2D rb2d;

    // Speed multiplier for the ball
    public float ballSpeed = 1.0f;

    // How much the ball speeds up by each hit
    public float speedIncreaseAmount = 1.05f;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        // If the ball collides with a paddle
        if (coll.collider.CompareTag("Player"))
        {
            // Increase the speed by a small amount
            rb2d.velocity = rb2d.velocity * speedIncreaseAmount;
        }
    }

    void GoBall()
    {
        // Pick a random player to shoot the ball towards
        float rand = Random.Range(0, 2);

        // Add velocity towards player 1
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(20, -15) * ballSpeed);
        }
        // Add velocity towards player 2
        else
        {
            rb2d.AddForce(new Vector2(-20, -15) * ballSpeed);
        }
    }
    
    // Reset the ball to zero
    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    // Restart the game
    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }
}
