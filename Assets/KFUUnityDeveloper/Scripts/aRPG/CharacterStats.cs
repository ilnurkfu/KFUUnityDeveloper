using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
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

    public int CurremtHealth
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

    public void HealthRegeneration()
    {
        if(healthRecoveryTimer > 0)
        {
            healthRecoveryTimer -= Time.deltaTime;
        }
        else
        {
            healthRecoveryTimer = healthRecoveryCooldown;
            if (currentHealth < maxHealth)
            {
                currentHealth = (int)MathF.Min(currentHealth + healthRecovery, maxHealth);
            }
        }
    }

    public void ManaRegeneration()
    {
        if(manaRecoveryTimer > 0)
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
}
