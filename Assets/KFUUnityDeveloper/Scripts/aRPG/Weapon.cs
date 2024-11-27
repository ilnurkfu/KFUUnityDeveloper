using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Scriptable Objects/Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] private string weaponName;

    [SerializeField] private int weaponDamage;

    [SerializeField] private int weaponAtackSpeed;

    [SerializeField] private int UpgradeRate;

    public void Upgrade()
    {
        UpgradeRate++;
        weaponDamage *= UpgradeRate;
    }
}
