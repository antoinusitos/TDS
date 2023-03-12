using UnityEngine;

public class Entity : MonoBehaviour
{
    protected EntityStat entityStat = null;

    protected virtual void Awake()
    {
        entityStat = GetComponent<EntityStat>();
    }

    public EntityStat GetEntityStat()
    {
        return entityStat;
    }
}
