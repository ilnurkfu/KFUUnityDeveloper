using UnityEngine;

public class LevelBase : MonoBehaviour
{
    [SerializeField] protected int currentLevel;

    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
    }
}
