using System;
using UnityEngine;

public class LevelPlayerSystem : LevelBase
{
    [SerializeField] private int currentExpirience;
    //[SerializeField] private int newRequiredExpirience;
    //[SerializeField] private int expirienceMultiplaer;

    [SerializeField] private int[] requiredExpirience;

    public event Action OnLevelUp;

    public void AddExpirience(int newExpirience)
    {
        currentExpirience += newExpirience;

        if(currentExpirience >= requiredExpirience[currentLevel - 1])
        {
            LevelUp();
        }
    }

    //public void AddNewExpirience(int newExpirience)
    //{
    //    currentExpirience += newExpirience;

    //    if (currentExpirience >= newRequiredExpirience)
    //    {
    //        NewLevelUp();
    //    }
    //}

    private void LevelUp()
    {
        currentExpirience -= requiredExpirience[currentLevel - 1];
        currentLevel++;
        OnLevelUp?.Invoke();
    }

    //private void NewLevelUp()
    //{
    //    currentExpirience -= newRequiredExpirience;
    //    currentLevel++;
    //    newRequiredExpirience *= expirienceMultiplaer;
    //    OnLevelUp?.Invoke();
    //}
}
