using UnityEngine;

public class AISpawner : MonoBehaviour
{
    public GameObject aiToSpawn = null;

    private GameObject spawnedAI = null;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        if(!spawnedAI && aiToSpawn)
        {
            spawnedAI = Instantiate(aiToSpawn, transform.position, Quaternion.identity);
        }
    }

    public void Respawn()
    {
        if (aiToSpawn)
        {
            spawnedAI = Instantiate(aiToSpawn, transform.position, Quaternion.identity);
        }
    }
}
