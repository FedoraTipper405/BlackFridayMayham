using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioList;
    [SerializeField] private AudioSource SFXSource;
    public static AudioManager Instance;

    public void Awake()
    {
        Instance = this;
    }

    public static void PlaySoundEffect(int sound)
    {
        Instance.SFXSource.PlayOneShot(Instance.audioList[sound]);
    }
}
