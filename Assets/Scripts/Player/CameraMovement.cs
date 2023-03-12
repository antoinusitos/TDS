using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	private Transform localTransform = null;

	public Transform player = null;
	
	[SerializeField]
	private float cameraSpeed = 2.0f;

	public static CameraMovement instance = null;

    private void Awake()
    {
		instance = this;
    }

    private void Start()
	{
		localTransform = transform;
	}

    private void Update()
    {
        localTransform.position = Vector3.Lerp(localTransform.position, player.position + Vector3.forward * -10.0f, Time.deltaTime * cameraSpeed);
    }

	public void SetCameraOnPlayer()
    {
		localTransform.position = player.position + Vector3.forward * -10.0f;
	}
}
