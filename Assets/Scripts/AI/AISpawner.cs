using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    public GameObject aiToSpawn = null;

    private GameObject spawnedAI = null;

    public List<ItemBackend> specialItems = new List<ItemBackend>();

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        if(!spawnedAI && aiToSpawn)
        {
            SpawnAI();
        }
    }

    public void Respawn()
    {
        if (aiToSpawn)
        {
            SpawnAI();
        }
    }

    private void SpawnAI()
    {
        spawnedAI = Instantiate(aiToSpawn, transform.position, Quaternion.identity);
        Inventory inventory = spawnedAI.GetComponent<Inventory>();
        if (inventory)
        {
            for(int i = 0; i < specialItems.Count; i++)
            {
                inventory.AddItem(specialItems[i].ID, specialItems[i].quantity);
            }
        }
    }
}
