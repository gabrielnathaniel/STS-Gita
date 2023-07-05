using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public Animator animator;
	public SceneFader sceneFader;
	public string sceneToLoad;
	public int maxHealth = 100;
	public int currentHealth;

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

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		sceneFader.FadeTo(sceneToLoad);
	}

	void DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		// Play hurt animation
        animator.SetTrigger("Hurt");
	}

}