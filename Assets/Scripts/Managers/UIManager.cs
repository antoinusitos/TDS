using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance = null;

    public GameObject shrineCanvas = null;

    public Text dialogueText = null;
    public GameObject dialogueCanvas = null;

    public GameObject loadScreenCanvas = null;

    public Text deathText = null;
    public Image deathImage = null;

    private readonly float deathImageMaxValue = 225.0f;

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

    public void ShowLoadScreen(bool newState)
    {
        loadScreenCanvas.SetActive(newState);
    }

    public void ShowDeathScreen()
    {
        StartCoroutine(ShowDeath());
    }

    private IEnumerator ShowDeath()
    {
        Color white = Color.white;
        white.a = 0;
        deathText.color = white;
        Color black = Color.black;
        black.a = 0;
        deathImage.color = black;
        float timer = 0;
        while(timer < 1)
        {
            white.a = Mathf.Lerp(0, 1, timer);
            deathText.color = white;
            black.a = Mathf.Lerp(0, deathImageMaxValue / 255.0f, timer);
            deathImage.color = black;
            timer += Time.deltaTime;
            yield return null;
        }
        white.a = 1;
        deathText.color = white;
        black.a = deathImageMaxValue / 255.0f;
        deathImage.color = black;

        yield return new WaitForSeconds(2);
        ShowLoadScreen(true);
        Player.instance.HandlePlayerDeath();
        yield return new WaitForSeconds(1);
        white.a = 0;
        deathText.color = white;
        black.a = 0;
        deathImage.color = black;
        ShowLoadScreen(false);
        yield return new WaitForSeconds(0.5f);
        LevelScript.instance.ShowLocation();
    }
}
