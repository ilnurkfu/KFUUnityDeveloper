using System;
using UnityEngine;
using UnityEngine.Events;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private bool canHealthRegeneration;
    [SerializeField] private bool canManaRegeneration;

    [SerializeField] private int currentHealth;
    [SerializeField] private int currentMana;

    [Header("strength parametr")]
    [SerializeField] private int maxHealth;
    [SerializeField] private int scaleMaxHealth;
    [SerializeField] private int healthRecovery;
    [SerializeField] private int scaleHealthRecovery;

    [Header("Intelligence parametr")]
    [SerializeField] private int maxMana;
    [SerializeField] private int scaleMaxMana;
    [SerializeField] private int manaRecovery;
    [SerializeField] private int scaleManaRecovery;

    [Header("RecoveryTimers")]
    [SerializeField] private float healthRecoveryTimer;
    [SerializeField] private float healthRecoveryCooldown;
    [SerializeField] private float manaRecoveryTimer;
    [SerializeField] private float manaRecoveryCooldown;

    public event Action OnHealthChange;

    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }
    }

    public int CurrentMana
    {
        get
        {
            return currentMana;
        }
    }

    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
    }

    public void TimerForHealthRegeneration()
    {
        if (canHealthRegeneration)
        {
            if (healthRecoveryTimer > 0)
            {
                healthRecoveryTimer -= Time.deltaTime;
            }
            else
            {
                healthRecoveryTimer = healthRecoveryCooldown;
                HealthRegeneration(healthRecovery);
            }
        }
    }

    public void HealthRegeneration(int addedHealthPoints)
    {
        currentHealth = (int)MathF.Min(currentHealth + addedHealthPoints, maxHealth);
        OnHealthChange?.Invoke();
        CheckHealthRegeneration();
    }

    public void ManaRegeneration()
    {
        if (canManaRegeneration)
        {
            if (manaRecoveryTimer > 0)
            {
                manaRecoveryTimer -= Time.deltaTime;
            }
            else
            {
                manaRecoveryTimer = manaRecoveryCooldown;
                if (currentMana < maxMana)
                {
                    currentMana = (int)MathF.Min(currentMana + manaRecovery, maxMana);
                }
            }
        }
        else
        {
           manaRecoveryTimer = manaRecoveryCooldown;
        }
    }

    public void FullHealthRecovery()
    {
        currentHealth = maxHealth;
    }

    public void FullManaRecovery()
    {
        currentMana = maxMana;
    }

    public void CalculatedMaxHealth(int newStrength)
    {
        maxHealth = scaleMaxHealth * newStrength;
    }

    public void CalculatedHealthRecovery(int newStrength)
    {
        healthRecovery = scaleHealthRecovery * newStrength;
    }

    public void CalculatedMaxMana(int newIntelligence)
    {
        maxMana = scaleMaxMana * newIntelligence;
    }

    public void CalculatedManaRecovery(int newIntelligence)
    {
        manaRecovery = scaleManaRecovery * newIntelligence;
    }

    public void SetHealth(int newHealth)
    {
        currentHealth = newHealth;
        CheckHealthRegeneration();
    }

    public void StatsInitialized(CharacterCharacteristics characterCharacteristics)
    {
        CalculatedMaxHealth(characterCharacteristics.Strength);
        CalculatedHealthRecovery(characterCharacteristics.Strength);
        CalculatedMaxMana(characterCharacteristics.Intelligence);
        CalculatedManaRecovery(characterCharacteristics.Intelligence);
        FullHealthRecovery();
        FullManaRecovery();
    }

    public void ApplyDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
        OnHealthChange?.Invoke();
        CheckHealthRegeneration();
    }

    private void CheckHealthRegeneration()
    {
        if (currentHealth == maxHealth)
        {
            canHealthRegeneration = false;
            healthRecoveryTimer = healthRecoveryCooldown;
        }
        else
        {
            canHealthRegeneration = true;
        }
    }
}
