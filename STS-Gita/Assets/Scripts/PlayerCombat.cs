using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 2f;
    // float nextAttackTime = 0f;

    public static PlayerCombat instance;
    public bool isAttacking;
    // public bool canReceiveInput;
    // public bool inputReceived;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        // if(Time.time >= nextAttackTime)
        // {
        //     if(Input.GetKeyDown(KeyCode.Space))
        //     {
        //         Attack();
        //         nextAttackTime = Time.time + 1f / attackRate;
        //     }
        // }
    }

    void Attack()
    {
        // // Play an attack animation
        // animator.SetTrigger("Attack");

        // // Detect enemies in range of attack
        // Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // // Damage them
        // foreach(Collider2D enemy in hitEnemies)
        // {
        //     enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        // }
        if(Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            isAttacking = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
