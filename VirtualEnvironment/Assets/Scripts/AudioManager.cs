using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    AudioSource Source;

    [SerializeField]
    AudioClip keyCollection;

    void Start()
    {
        Instance = this;
        Source = GetComponent<AudioSource>();
    }

    public void PlayKeyCollect()
    {
        Source.PlayOneShot(keyCollection);
    }

}