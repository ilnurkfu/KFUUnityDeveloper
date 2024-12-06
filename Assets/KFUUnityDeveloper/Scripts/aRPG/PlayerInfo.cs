using UnityEngine;

public class PlayerInfo : CharacterInfo
{
    public override void ShowHealth(int currentHealth, int maxHealth)
    {
        healthBar.fillAmount = (float)currentHealth / maxHealth;
        characterInfo.text = $"{currentHealth} / {maxHealth}";
    }
}
