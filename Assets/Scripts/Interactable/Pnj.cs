using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string line = "";
    public float timing = 0.0f;
}

public class Pnj : Interactable
{
    public List<Dialogue> dialoguesLines = new List<Dialogue>();

    private bool isSpeaking = false;

    private Coroutine dialogueCoroutine = null;

    public override void Execute(PlayerAction playerAction)
    {
        if(isSpeaking)
        {
            return;
        }

        isSpeaking = true;
        dialogueCoroutine = StartCoroutine(Dialogue());
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);

        if (!isSpeaking)
        {
            return;
        }

        StopCoroutine(dialogueCoroutine);
        UIManager.instance.ShowDialogueCanvas(false);
        isSpeaking = false;
    }

    private IEnumerator Dialogue()
    {
        SoundManager.instance.PlaySound("voice");
        UIManager.instance.ShowDialogueCanvas(true);
        for (int i = 0; i < dialoguesLines.Count; i++)
        {
            UIManager.instance.SetDialogueText(dialoguesLines[i].line);
            yield return new WaitForSeconds(dialoguesLines[i].timing);
        }

        UIManager.instance.ShowDialogueCanvas(false);
        isSpeaking = false;
    }
}
