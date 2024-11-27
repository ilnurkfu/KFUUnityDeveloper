using UnityEngine;

public class CharacterCharacteristics : MonoBehaviour
{
    [SerializeField] private int strength;
    [SerializeField] private int intelligence;

    public int Strength
    { 
        get
        {
            return strength;
        }
    }

    public int Intelligence
    {
        get
        {
            return intelligence;
        }
    }

}
