using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // reference to player Rigidbody
    public Rigidbody player;
    // Variable for player speed
    public float speed = 2000f;
    public int health = 5;
    // Variable for player score
    private int score = 0;
    // Variable for score text
    public Text scoreText;
    // Variable for player health text
    public Text healthText;
    public Image winLoseBG;
    public Text winLoseText;

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

    // Method for updated score display on screen
    void SetScoreText()
    {
        scoreText.text = $"Score: {score}";
    }

    // Method for updating Health display
    void SetHealthText()
    {
        healthText.text = $"Health: {health}";
    }

    // Method for winning
    void Win()
    {
        winLoseText.text = "You Win!";
        winLoseText.color = Color.black;
        winLoseBG.color = Color.green;
        winLoseBG.gameObject.SetActive(true);
        StartCoroutine(LoadScene(3));
    }

    // Method for losing
    void Lose()
    {
        winLoseText.text = "Game Over!";
        winLoseText.color = Color.white;
        winLoseBG.color = Color.red;
        winLoseBG.gameObject.SetActive(true);
        StartCoroutine(LoadScene(3));
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Method for collecting coin objects
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            Destroy(other.gameObject);
            score++;
            SetScoreText();
            // Debug.Log($"Score: {score}");
        }
        if (other.tag == "Trap")
        {
            health--;
            SetHealthText();
            // Debug.Log($"Health: {health}");
        }
        if (other.tag == "Goal")
        {
            Win();
            // Debug.Log("You win!");
        }
    }
    void Update()
    {
        if (health == 0)
        {
            Lose();
            //Debug.Log("Game Over!");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
