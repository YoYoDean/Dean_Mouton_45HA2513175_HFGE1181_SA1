using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

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
    public GameObject checkInArea;
    private bool inArea;
    private bool buttonClicked = false;
    

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
    inArea = checkInArea.GetComponent<InArea>().inArea;
    
    if (isDestroyed)
    {  // Debug.Log(inArea);
        if (Keyboard.current.eKey.wasPressedThisFrame || buttonClicked && inArea)
        {
            FixWindow();
            buttonClicked = false;
           // Debug.Log("Fix click");
        }
        return; 
    }

    
    float damagePerSecond = maxHealth / timeToDestroy;
    currentHealth -= damagePerSecond * Time.deltaTime;

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
            GetComponent<BoxCollider2D>().enabled = false;
        }

        AudioManager.Instance.Play("BreakWindow");

        Debug.Log("Window destroyed! Enabling spawn point...");

        if (enemySpawnPoint != null)
        {
            enemySpawnPoint.SetActive(true);
        }
    }

    private void FixWindow()
{
    isDestroyed = false;
    currentHealth = maxHealth;

    if (animator != null)
    {
        animator.SetTrigger("Fix");
        GetComponent<BoxCollider2D>().enabled = true;
    }

    if (enemySpawnPoint != null)
    {
        enemySpawnPoint.SetActive(false);
    }

    Debug.Log("Window Fixed!");
}
        public void OnFixButtonClicked()
            {
                buttonClicked = true;
            }
}
