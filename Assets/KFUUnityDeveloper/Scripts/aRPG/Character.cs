using aRPG;
using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected CharacterStats characterStats;

    [SerializeField] protected CharacterCharacteristics characterCharacteristics;

    [SerializeField] protected LevelBase levelBase;

    [SerializeField] protected CharacterInfo characterInfo;

    [SerializeField] protected Weapon weapon;

    [SerializeField] Character[] characters;

    private void Update()
    {
        characterStats.TimerForHealthRegeneration();
        characterStats.ManaRegeneration();
    }

    protected virtual void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
        characterCharacteristics = GetComponent<CharacterCharacteristics>();
        levelBase = GetComponent<LevelBase>();
        characterInfo = GetComponent<CharacterInfo>();
    }

    private void Start()
    {
        Initialized();
        characterStats.OnHealthChange += ChangeHealth;
        characterInfo.ShowHealth(characterStats.CurrentHealth, characterStats.MaxHealth);
    }

    private UnityAction ApplyDamage()
    {
        throw new NotImplementedException();
    }

    protected virtual void Initialized()
    {
        Debug.Log(name);
        characterStats.StatsInitialized(characterCharacteristics);
    }

    public void ApplyDamage(int damage)
    {
        characterStats.ApplyDamage(damage);
        if (characterStats.CurrentHealth == 0)
        {
            Died();
        }
    }

    protected void Died()
    {
        Debug.Log("Потрачено");
    }

    public void ChangeHealth()
    {
        characterInfo.ShowHealth(characterStats.CurrentHealth, characterStats.MaxHealth);
    }
}
