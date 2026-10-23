using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private float attackCD = 1f;

    private float nextAttackTime;

    public void TryAttack(Transform target)
    {
        if (target == null)
        {
            return;
        }
        if (Time.time < nextAttackTime)
        {
            return;
        }
        if (!target.gameObject.TryGetComponent<PlayerHealth>(out var playerHealth))
        {
            return;
        }
        playerHealth.TakeDamage(attackDamage);
        nextAttackTime = Time.time + attackCD;
    }
}
