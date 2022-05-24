using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float invFlashDelay = 0.2f;
    public float invFlashTime = 1f;

    public bool isInvincible = false;
    public SpriteRenderer graphics;


    public GameObject destroys;
    public HealthBar healthBar;



    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
        if (currentHealth <= 0)
        {
            Destroy(destroys);
        }
    }

    
    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public IEnumerator InvincibilityFlash()
    {
        
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invFlashDelay);

        }
       
    }
    
    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invFlashTime);
        isInvincible = false;
    }
}


