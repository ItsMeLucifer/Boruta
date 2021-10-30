using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip lockedSound, drawerSound, cabinetSound, doorOpen, doorClose;
    static AudioSource audioSource,musicSource;
    [SerializeField] private Slider _musicVolumeSlider, _sfxVolumeSlider;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        musicSource = transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        lockedSound = Resources.Load<AudioClip>("locked_sound");
        drawerSound = Resources.Load<AudioClip>("drawer_sound");
        cabinetSound = Resources.Load<AudioClip>("cabinet_sound");
        doorOpen = Resources.Load<AudioClip>("door_open");
        doorClose = Resources.Load<AudioClip>("door_close");
        _musicVolumeSlider.onValueChanged.AddListener((v) =>
        {
            musicSource.volume = v;
        });
        _sfxVolumeSlider.onValueChanged.AddListener((v) =>
        {
            audioSource.volume = v;
        });
    }
    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "locked":
                audioSource.PlayOneShot(lockedSound);
                break;
            case "drawer":
                audioSource.PlayOneShot(drawerSound);
                break;
            case "cabinet":
                audioSource.PlayOneShot(cabinetSound);
                break;
            case "door_open":
                audioSource.PlayOneShot(doorOpen);
                break;
            case "door_close":
                audioSource.PlayOneShot(doorClose);
                break;
        }
    }
}
