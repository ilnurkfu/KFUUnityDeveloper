using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class CharacterInfo : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI characterInfo;

    [SerializeField] protected Image healthBar;

    public abstract void ShowHealth(int currentHealth, int maxHealth);
}
