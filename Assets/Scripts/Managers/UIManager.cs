using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    public GameObject shrineCanvas = null;

    private void Awake()
    {
        instance = this;
    }

    public void SetShrineVisibility(bool newState)
    {
        shrineCanvas.SetActive(newState);
    }
}
