using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField]
    private Transform attackPoint;
    [SerializeField]
    private float attackRange = 1f;
    [SerializeField]
    private int attackDamage = 20;
    [SerializeField]
    private float attackCD = .5f;
    [SerializeField]
    private LayerMask enemyLayer;
    [SerializeField]
    private LineRenderer attackCircle;
    [SerializeField]
    private int circleSegments = 60;

    private float nextAttackTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackCD;
        }
        DrawAttackCircle();
    }

    private void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D item in hits)
        {
            EnemyHealth enemy = item.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(attackDamage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void DrawAttackCircle()
    {
        if (attackCircle == null)
            return;

        attackCircle.useWorldSpace = false;
        attackCircle.loop = true;
        attackCircle.positionCount = circleSegments;
        attackCircle.startWidth = 0.03f;
        attackCircle.endWidth = 0.03f;
        
        for (int i = 0; i < circleSegments; i++)
        {
            float angle = i * Mathf.PI * 2f / circleSegments;

            float x = Mathf.Cos(angle) * attackRange;
            float y = Mathf.Sin(angle) * attackRange;

            attackCircle.SetPosition(
            i,
            new Vector3(x, y, 0)
            );
        }
    }
}
