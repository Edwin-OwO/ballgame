using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("-----Audio Source-----")]
    [SerializeField] AudioSource musicsource;
    [SerializeField] AudioSource musicambience;

    [Header("-----Audio Clip-----")]
    public AudioClip backgroundmusic;
    public AudioClip warsounds;

    private void Start()
    {
        
        musicsource.Play();
    }
}
