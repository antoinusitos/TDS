using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameInput inputActions = null;

    public static InputManager instance = null;

    private void Awake()
    {
        instance = this;
        inputActions = new GameInput();
        inputActions.PlayerInput.Enable();
    }
}
