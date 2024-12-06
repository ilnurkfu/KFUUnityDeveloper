using UnityEngine;

public class EnemySpawner : BaseSpawner
{
    [SerializeField] private float timer;
    [SerializeField] private float duration;

    private void Start()
    {
        timer = duration + Time.time;
    }

    private void Update()
    {
        if(timer < Time.time)
        {
            Spawn();
            timer += duration;
        }
    }

    public override void Spawn()
    {
        Instantiate(spawnObject, transform.position, transform.rotation);
    }
}