using UnityEngine;

public class CombatMusic : MonoBehaviour
{
    public AudioClip[] tracks;
    private AudioSource _audio;
    private bool _played;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _audio.clip = tracks[0];
        _audio.Play();
    }

    private void Update()
    {
        if (BossProfiler.combat && !_played)
        {
            _played = true;
            _audio.clip = tracks[1];
            _audio.Play();
        }
    }
}
