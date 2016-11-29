using UnityEngine;
using System.Collections;

public class ProximityTrigger : MonoBehaviour
{
    AudioSource audioSource;
    bool fadeAudioIn = false;
    readonly float endTime = 0.7f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.0f;
        audioSource.Stop();
        foreach (Transform childXform in transform)
        {
            childXform.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            StartCoroutine(FadeInAudio());
            foreach (Transform childXform in transform)
            {
                childXform.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            StartCoroutine(FadeOutAudio());
            foreach (Transform childXform in transform)
            {
                childXform.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator FadeInAudio()
    {
        audioSource.Play();
        fadeAudioIn = true;
        float time = 0;

        while (time < endTime && fadeAudioIn)
        {
            audioSource.volume = Mathf.Lerp(0, 0.05f, time / endTime);
            time += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator FadeOutAudio()
    {
        fadeAudioIn = false;
        float time = 0;

        while (time < endTime && !fadeAudioIn)
        {
            audioSource.volume = Mathf.Lerp(0.05f, 0f, time / endTime);
            time += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        audioSource.Stop();
    }
}