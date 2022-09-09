using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehaviour : MonoBehaviour
{
    private Animator anim;
    public float attackTime;
    public float startTimeAttack;

    public Transform attackLocation;
    public float attackRange;
    public LayerMask enemies;

    //Gets the animation references
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (attackTime <= 0)
        {
            if (Input.GetButton("Fire1"))    //----> Alternative"SPACEBAR" button
            {
                anim.SetBool("IsAttacking", true);
                Collider2D[] damage = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, enemies);

                for (int i = 0; i < damage.Length; i++)
                {
                    Destroy(damage[i].gameObject);
                }
            }
            attackTime = startTimeAttack;
        }
        else
        {
            attackTime -= Time.deltaTime;
            anim.SetBool("IsAttacking", false);
        }
    }
    // Debug by drawing a sphere gizmos within the area of attack.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }




}
