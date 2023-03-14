using UnityEngine;

public class RainEffect : MonoBehaviour
{
    public GameObject rainPrefab = null;

    public float rainSpeed = 0.02f;
    private float currentRainSpeed = 0.0f;
    public int rainDensity = 20;

    private readonly float rainMinSize = 0.05f;
    private readonly float rainMaxSize = 0.15f;

    private GameObject[] rains = null;
    private int index = 0;

    private BoxCollider2D space2D = null;

    private void Awake()
    {
        rains = new GameObject[rainDensity];
        space2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        currentRainSpeed += Time.deltaTime;
        if(currentRainSpeed >= rainSpeed)
        {
            if(rains[index] != null)
            {
                Destroy(rains[index]);
            }
            currentRainSpeed = 0;
            rains[index] = Instantiate(rainPrefab, transform.position + new Vector3(Random.Range(-space2D.bounds.size.x / 2.0f, space2D.bounds.size.x / 2.0f), Random.Range(-space2D.bounds.size.y / 2.0f, space2D.bounds.size.y / 2.0f), 0.0f), Quaternion.identity);
            float size = Random.Range(rainMinSize, rainMaxSize);
            rains[index].transform.localScale = Vector3.one * size;
            rains[index].transform.parent = transform;
            index++;
            if(index >= rainDensity)
            {
                index = 0;
            }
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        PlayerAction pa = other.GetComponent<PlayerAction>();
        if (!pa)
        {
            return;
        }

        SoundManager.instance.PlaySound("rain");
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        PlayerAction pa = other.GetComponent<PlayerAction>();
        if (!pa)
        {
            return;
        }

        SoundManager.instance.StopSound("rain");
    }
}
