using UnityEngine;

public class DEBUGTELEPORTER : MonoBehaviour
{
    private void Update()
    {
        Player.instance.transform.position = transform.position;

        Destroy(gameObject);
    }
}
