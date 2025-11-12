using UnityEngine;

public class Window : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float timeToDestroy = 1f;

    [Header("Enemy Spawn")]
    [SerializeField] private GameObject enemySpawnPoint;

    private Animator animator;

    private float currentHealth;
    private bool isDestroyed = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        if (enemySpawnPoint != null)
        {
            enemySpawnPoint.SetActive(false);
        }
    }

    private void Update()
    {
        if (isDestroyed) return;

        float damagePerSecond = maxHealth / timeToDestroy;
        currentHealth -= damagePerSecond * Time.deltaTime;

        Debug.Log($"Window Health: {currentHealth:F2}");

        if (currentHealth <= 0f)
        {
            BreakWindow();
        }
    }

    private void BreakWindow()
    {
        isDestroyed = true;
        currentHealth = 0f;

        if (animator != null)
        {
            animator.SetTrigger("Break");
        }

        AudioManager.Instance.Play("BreakWindow");

        Debug.Log("Window destroyed! Enabling spawn point...");

        if (enemySpawnPoint != null)
        {
            enemySpawnPoint.SetActive(true);
        }
    }
}
