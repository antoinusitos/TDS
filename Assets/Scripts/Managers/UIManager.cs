using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    public GameObject shrineCanvas = null;

    public Text dialogueText = null;
    public GameObject dialogueCanvas = null;

    private void Awake()
    {
        instance = this;
    }

    public void SetShrineVisibility(bool newState)
    {
        shrineCanvas.SetActive(newState);
    }

    public void ShowDialogueCanvas(bool newState)
    {
        dialogueCanvas.SetActive(newState);
    }

    public void SetDialogueText(string newText)
    {
        dialogueText.text = newText;
    }
}
