using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [Header("Damage Settings")]
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private float enemyKnockbackForce = 8f;

    [Header("Animation Settings")]
    [SerializeField] private Animator animator;
    [SerializeField] private string attackTriggerName = "Attack";

    private EnemyAI enemyAI;

    private void Awake()
    {
        enemyAI = GetComponent<EnemyAI>();
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            Vector2 hitSource = transform.position;
            playerHealth.TakeDamage(damageAmount, hitSource);

            if (enemyAI != null)
            {
                animator.SetTrigger(attackTriggerName);

                Vector2 knockbackDir = (transform.position - collision.transform.position).normalized;
                enemyAI.ApplyKnockback(knockbackDir, enemyKnockbackForce);
            }
        }
    }
}
