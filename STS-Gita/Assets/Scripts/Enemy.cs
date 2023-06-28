using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;

    public bool isFlipped = false;

    public Animator animator;

    public int maxHealth = 100;
    private int currentHealth;

    public bool isBoss = false;
    public SceneFader sceneFader;
    public string sceneToLoad = "Chapter 6 - Candy Land7";
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Play hurt animation
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        // Play die animation
        animator.SetBool("IsDead", true);

        // Disable the enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        StartCoroutine(Disappear());

        if(isBoss)
        {
            sceneFader.FadeTo(sceneToLoad);
        }
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
