using UnityEngine;

public class Stairs : MonoBehaviour
{
    public Transform arrivingPoint = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entity entity = collision.GetComponent<Entity>();
        if(entity)
        {
            entity.transform.position = arrivingPoint.position;
            if(entity.GetType() == typeof(Player))
            {
                CameraMovement.instance.SetCameraOnPlayer();
            }
        }
    }
}
