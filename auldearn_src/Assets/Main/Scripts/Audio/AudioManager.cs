using UnityEngine;

/*
 * AudioManager
 * To control Audio throughout all scenes depending on the Audio Options from the Menus.
 * Plus Music FadeIn/FadeOut.
 */
public class AudioManager : MonoBehaviour
{
    private static int _fadeIn, _fadeOut;
    private static Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _fadeIn = Animator.StringToHash("FadeIn");
        _fadeOut = Animator.StringToHash("FadeOut");

        FadeMusic(true, false);
    }

    public static void FadeMusic(bool fadeIn, bool fadeOut)
    {
        _animator.SetBool(_fadeIn, fadeIn);
        _animator.SetBool(_fadeOut, fadeOut);
    }
    
    public static void MuteActive()
    {
        if (Bools.muteActive)
            AudioListener.volume = 0f;
        else if (!Bools.muteActive)
            AudioListener.volume = 1f;
        else
            Debug.LogWarning("No audio in scene.");
    }
}