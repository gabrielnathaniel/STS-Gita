using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public Animator animator;

	public int maxHealth = 100;
	public int currentHealth;

	public GameObject deathEffect;

	public HealthBar healthBar;

	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);

		DamageAnimation();

		// if (health <= 0)
		// {
		// 	Die();
		// }
	}

	// void Die()
	// {
	// 	SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	// }

	void DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		// Play hurt animation
        animator.SetTrigger("Hurt");
	}

}