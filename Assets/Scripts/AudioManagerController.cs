using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class AudioManagerController : MonoBehaviour
{
    public static AudioManagerController Instance { get; private set; }
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private AudioSource sfxAudioSource;
    [SerializeField] private Slider musicConfiguration;
    [SerializeField] private Slider masterConfiguration;
    [SerializeField] private Slider sfxConfiguration;
    [SerializeField] private AudioClip[] musicClips;
    [SerializeField] private AudioClip[] sfxClips;
    [SerializeField] private AudioSettings audioSettings;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public AudioSource MusicAudioSource
    {
        get
        {
            return musicAudioSource;
        }
    }
    public AudioSource SfxAudioSource
    {
        get
        {
            return sfxAudioSource;
        }
    }
    public AudioClip[] SfxClips
    {
        get
        {
            return sfxClips;
        }
    }
    public void SaveAudioSettings()
    {
        audioSettings.musicVolume = musicConfiguration.value;
        audioSettings.sfxVolume = sfxConfiguration.value;
        audioSettings.masterVolume = masterConfiguration.value;
    }
    public void LoadAudioSettings()
    {
        musicConfiguration.value = audioSettings.musicVolume;

        sfxConfiguration.value = audioSettings.sfxVolume;
        masterConfiguration.value = audioSettings.masterVolume;
        SetVolumeOfMusic();
        SetVolumeOfSfx();
        SetVolumeOfMaster();
    }
    public void SetVolumeOfMusic()
    {
        audioMixer.SetFloat("music", Mathf.Log10(musicConfiguration.value) * 20f);
    }
    public void SetVolumeOfSfx()
    {
        audioMixer.SetFloat("sfx", Mathf.Log10(sfxConfiguration.value) * 20f);
    }
    public void SetVolumeOfMaster()
    {
        audioMixer.SetFloat("master", Mathf.Log10(masterConfiguration.value) * 20f);
    }
    public void PlayMusic(int index)
    {
        musicAudioSource.Stop();
        musicAudioSource.clip = musicClips[index];
        musicAudioSource.Play();
    }
    public void PlaySfx(int index)
    {
        sfxAudioSource.PlayOneShot(sfxClips[index]);
    }
}
