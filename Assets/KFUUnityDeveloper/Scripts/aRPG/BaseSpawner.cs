using UnityEngine;

public abstract class BaseSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] protected GameObject spawnObject;
    public abstract void Spawn();
}
