using UnityEngine;

public class AIManager : MonoBehaviour
{
    public static AIManager instance = null;

    private AISpawner[] spawners = null;

    private void Awake()
    {
        instance = this;
        spawners = FindObjectsOfType<AISpawner>();
    }

    public void WipeAllEnemies()
    {
        AI[] ais = FindObjectsOfType<AI>();
        for(int i = 0; i < ais.Length; i++)
        {
            Destroy(ais[i].gameObject);
        }
    }

    public void SpawnAllEnemies()
    {
        for(int i = 0; i < spawners.Length; i++)
        {
            spawners[i].Respawn();
        }
    }
}
