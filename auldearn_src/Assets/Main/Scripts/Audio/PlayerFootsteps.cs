using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioClip[] footsteps;
    private AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void FootstepSounds()
    {
        _audio.PlayOneShot(footsteps[Random.Range(0, footsteps.Length)], 0.1f);
    }
}