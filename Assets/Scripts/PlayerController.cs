using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // reference to player Rigidbody
    public Rigidbody player;
    // Variable for player speed
    public float speed = 2000f;
    public int health = 5;
    // Variable for player score
    private int score = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Forward
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            player.AddForce(0, 0, speed * Time.deltaTime);
        }
        // Backward
        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            player.AddForce(0, 0, -speed * Time.deltaTime);
        }
        // Left
        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            player.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        // Right
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            player.AddForce(speed * Time.deltaTime, 0, 0);
        }
    }
    // Method for collecting coin objects
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            Destroy(other.gameObject);
            score++;
            Debug.Log($"Score: {score}");
        }
        if (other.tag == "Trap")
        {
            health--;
            Debug.Log($"Health: {health}");
        }
        if (other.tag == "Goal")
        {
            Debug.Log("You win!");
        }
    }
    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
