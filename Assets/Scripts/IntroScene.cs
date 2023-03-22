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

    public AudioClip[] audioClips = null;

    private AudioSource audioSource = null;
    public AudioSource musicAudioSource = null;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayIntro());
    }

    private IEnumerator PlayIntro()
    {
        yield return new WaitForSeconds(startTiming);
        for (int i = 0; i < dialogues.Count; i++)
        {
            audioSource.clip = audioClips[i];
            audioSource.Play(0);
            transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
            dialogueText.text = dialogues[i].line;
            yield return new WaitForSeconds(audioClips[i].length + 1f);
            transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
        }
        float timer = 0;
        float startingVolume = musicAudioSource.volume;
        while (timer < endTiming)
        {
            musicAudioSource.volume = Mathf.Lerp(startingVolume, 0, timer);
            timer += Time.deltaTime;
            yield return null;
        }
        musicAudioSource.volume = 0;
        SceneManager.LoadScene(1);
    }
}
