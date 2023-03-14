using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScene : MonoBehaviour
{
    public List<Dialogue> dialogues = new List<Dialogue>();

    public Text dialogueText = null;

    public float startTiming = 8.0f;
    public float endTiming = 1.0f;

    private void Start()
    {
        StartCoroutine(PlayIntro());
    }

    private IEnumerator PlayIntro()
    {
        yield return new WaitForSeconds(startTiming);
        for (int i = 0; i < dialogues.Count; i++)
        {
            dialogueText.text = dialogues[i].line;
            yield return new WaitForSeconds(dialogues[i].timing);
        }
        yield return new WaitForSeconds(endTiming);
        SceneManager.LoadScene(1);
    }
}
