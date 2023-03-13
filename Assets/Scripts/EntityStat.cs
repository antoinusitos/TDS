using UnityEngine;

public class EntityStat : MonoBehaviour
{
    /// <summary>
    /// LIFE
    /// </summary>
    public bool lifeValueDirty = false;

    public float currentLife { get { return _currentLife; } set { _currentLife = value; } }

    [SerializeField]
    private float _currentLife = 100.0f;

    public float maxLife { get { return _maxLife; } set { _maxLife = value; } }

    [SerializeField]
    private float _maxLife = 100.0f;

    public void UpdateLifeStat(float value)
    {
        currentLife += value;
        currentLife = Mathf.Clamp(currentLife, 0, maxLife);
        lifeValueDirty = true;
    }

    public void UpdateMaxLifeStat(float value)
    {
        maxLife += value;
        lifeValueDirty = true;
    }

    /// <summary>
    /// STAMINA
    /// </summary>

    public bool staminaValueDirty = false;

    public float currentStamina { get { return _currentStamina; } set { _currentStamina = value; } }

    [SerializeField]
    private float _currentStamina = 100.0f;

    public float maxStamina { get { return _maxStamina; } set { _maxStamina = value; } }

    [SerializeField]
    private float _maxStamina = 100.0f;

    public void UpdateStaminaStat(float value)
    {
        currentStamina += value;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        staminaValueDirty = true;
    }

    public void UpdateMaxStaminaStat(float value)
    {
        maxStamina += value;
        staminaValueDirty = true;
    }

    /// <summary>
    /// DAMAGE
    /// </summary>
    public float currentDamage { get { return _currentDamage; } set { _currentDamage = value; } }

    [SerializeField]
    private float _currentDamage = 100.0f;

    public float maxDamage { get { return _maxDamage; } set { _maxDamage = value; } }

    [SerializeField]
    private float _maxDamage = 100.0f;

    /// <summary>
    /// XP
    /// </summary>
    public bool XPValueDirty = false;

    public float currentXP { get { return _currentXP; } set { _currentLife = value; XPValueDirty = true; } }

    [SerializeField]
    private float _currentXP = 100.0f;


    public void UpdateXPStat(float value)
    {
        _currentXP += value;
    }
}
