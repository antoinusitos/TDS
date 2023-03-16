using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Vector2 direction = Vector2.zero;

    public EntityStat entityStatLinked = null;

    public float speed = 5.0f;

    private Rigidbody2D rigidBody2D = null;

    public Transform sprite = null;

    public List<Transform> sender = null;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidBody2D.MovePosition(rigidBody2D.position + speed * Time.fixedDeltaTime * direction);
        float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        sprite.localRotation = Quaternion.Euler(0, 0, Angle - 90);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(sender.Contains(collision.transform))
        {
            return;
        }

        Entity entity = collision.GetComponent<Entity>();
        if(entity)
        {
            entity.GetEntityStat().UpdateLifeStat(-entityStatLinked.currentDamage);
        }

        Debug.Log("hit " + collision.transform.name);

        Destroy(gameObject);
    }
}
