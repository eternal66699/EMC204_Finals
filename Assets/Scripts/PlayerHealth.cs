using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int lives = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            TakeDamage();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard)"))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        lives--;
        if (lives <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Eliminated!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
