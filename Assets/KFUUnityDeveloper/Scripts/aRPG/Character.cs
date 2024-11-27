using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected CharacterStats characterStats;

    [SerializeField] protected CharacterCharacteristics characterCharacteristics;

    [SerializeField] protected LevelBase levelBase;

    [SerializeField] protected Weapon weapon;

    private void Update()
    {
        characterStats.HealthRegeneration();
        characterStats.ManaRegeneration();
    }

    protected virtual void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
        characterCharacteristics = GetComponent<CharacterCharacteristics>();
        levelBase = GetComponent<LevelBase>();
    }

    protected virtual void Initialized()
    {
        characterStats.StatsInitialized(characterCharacteristics);
    }

    public void ApplyDamage(int damage)
    {
        int health = characterStats.CurremtHealth;
        health -= damage;
        if(health <= 0)
        {
            health = 0;
            characterStats.SetHealth(health);
            Died();
        }
    }

    protected void Died()
    {
        Debug.Log("Потрачено");
    }
}
