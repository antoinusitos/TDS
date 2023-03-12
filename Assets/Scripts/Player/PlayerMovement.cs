using UnityEngine;
using UnityEngine.InputSystem;

public enum LockState
{
    FREE,
    TARGET
}

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody2D = null;

    private readonly float speed = 10.0f;

	public Transform playerSprite = null;

    private Player player = null;

    private LockState lockState = LockState.FREE;

    private Vector2 Movement = Vector2.zero;

    private AI target = null;

    private void Start()
    {
        player = GetComponent<Player>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        InputManager.instance.inputActions.PlayerInput.Target.performed += OnTarget;
    }

    public void SetTarget(AI newTarget)
    {
        target = newTarget;
    }

    private void FixedUpdate()
    {
        if(player.playerState != PlayerState.GAME)
        {
            return;
        }

		Movement = Vector2.zero;

        Movement += Vector2.up * InputManager.instance.inputActions.PlayerInput.Forward.ReadValue<float>();
        Movement += Vector2.right * InputManager.instance.inputActions.PlayerInput.Right.ReadValue<float>();

        Movement.Normalize();

        rigidBody2D.MovePosition(rigidBody2D.position + speed * Time.fixedDeltaTime * Movement);

        if(Movement.x == 0 && Movement.y == 0)
        {
            return;
        }

    }

    private void Update()
    {
        if (Movement.x == 0 && Movement.y == 0 && lockState == LockState.FREE)
        {
            return;
        }
        HandleRotation();
    }

    private void HandleRotation()
    {
        switch(lockState)
        {
            case LockState.FREE:
                {
                    Vector3 BaseVector = Vector3.right;
                    Vector3 NewVector = new Vector3(Movement.x, Movement.y, 0.0f);
                    NewVector.Normalize();
                    float Angle = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(BaseVector, NewVector)) - 90;
                    if (Movement.y < 0)
                    {
                        Angle *= -1;
                        Angle += 180.0f;
                    }

                    playerSprite.localRotation = Quaternion.Euler(0, 0, Angle);
                    break;
                }
            case LockState.TARGET:
                {
                    if (target)
                    {
                        Vector3 NewVector = target.transform.position - transform.position;
                        NewVector.Normalize();
                        float Angle = Mathf.Atan2(NewVector.y, NewVector.x) * Mathf.Rad2Deg;

                        playerSprite.localRotation = Quaternion.Euler(0, 0, Angle - 90);
                    }
                    else
                    {
                        lockState = LockState.FREE;
                    }
                    break;
                }
        }
        
    }

    private void OnTarget(InputAction.CallbackContext obj)
    {
        if(lockState == LockState.TARGET)
        {
            lockState = LockState.FREE;
        }
        else if(target)
        {
            lockState = LockState.TARGET;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AI ai = collision.GetComponent<AI>();
        if(ai)
        {
            SetTarget(ai);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        AI ai = collision.GetComponent<AI>();
        if (ai && ai == target)
        {
            SetTarget(null);
            lockState = LockState.FREE;
        }
    }
}
