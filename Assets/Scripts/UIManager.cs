using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public int score = 0;
    public Text scoreText;
    public int health=10;
    public Text healthText;

    public Text deathText;
    public GameObject player;
    void Start()
    {
        Instance = this;
    }

    public void AddScore(int score)
    {
        this.score += score;
        scoreText.text = this.score.ToString();
    }

    public void AddHealth(int health)
    {
        this.health += health;
        if (this.health <= 0) 
        {
            this.health = 0;
            SetDeath();
        }
        healthText.text = this.health.ToString();
    }

    public void SetDeath()
    {
        deathText.gameObject.SetActive(true);
        Destroy(player.GetComponent<Rigidbody2D>());
        Destroy(player.GetComponent<Collider2D>());
    }
}
