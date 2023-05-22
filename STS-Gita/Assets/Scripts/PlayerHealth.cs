using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public Animator animator;

	public int health = 100;

	public GameObject deathEffect;

	public void TakeDamage(int damage)
	{
		health -= damage;

		// StartCoroutine(DamageAnimation());
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

	// IEnumerator DamageAnimation()
	void DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		// Play hurt animation
        animator.SetTrigger("Hurt");

		// for (int i = 0; i < 3; i++)
		// {
		// 	foreach (SpriteRenderer sr in srs)
		// 	{
		// 		Color c = sr.color;
		// 		c.a = 0;
		// 		sr.color = c;
		// 	}

		// 	yield return new WaitForSeconds(.1f);

		// 	foreach (SpriteRenderer sr in srs)
		// 	{
		// 		Color c = sr.color;
		// 		c.a = 1;
		// 		sr.color = c;
		// 	}

		// 	yield return new WaitForSeconds(.1f);
		// }
	}

}