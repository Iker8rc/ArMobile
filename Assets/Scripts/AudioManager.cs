using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField]
    private GameObject SFXPrefab;
    private float sfxVolume = 1;
    private AudioSource musicSource;
    private float musicVolume = 0.09f;
    private AudioSource ambientSource;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        ambientSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();
    }
    public void PlayMusic(AudioClip _music)
    {
        musicSource.clip = _music;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }
    public void PlayAmbientSound(AudioClip _ambient)
    {
        ambientSource.clip = _ambient;
        ambientSource.volume = sfxVolume;
        ambientSource.Play();
    }
    public void SetMusicVolume(float _volume)
    {
        musicSource.volume = _volume;
    }
    public void PlaySFX(AudioClip _sfx, Vector3 _position)
    {
        GameObject SFXClone = Instantiate(SFXPrefab, _position, Quaternion.identity);
        SFXClone.GetComponent<AudioSource>().clip = _sfx;
        SFXClone.GetComponent<AudioSource>().volume = sfxVolume;
        SFXClone.GetComponent<AudioSource>().Play();
        Destroy(SFXClone, _sfx.length);
    }
    public void StopAmbientSound()
    {
        ambientSource.Stop();
    }
}
