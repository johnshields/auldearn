using UnityEngine;

public class Fader : MonoBehaviour
{
    private static int _fadeIn, _fadeOut;
    private static Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _fadeIn = Animator.StringToHash("FadeIn");
        _fadeOut = Animator.StringToHash("FadeOut");

        FadeScene(true, false);
    }

    public static void FadeScene(bool fadeIn, bool fadeOut)
    {
        _animator.SetBool(_fadeIn, fadeIn);
        _animator.SetBool(_fadeOut, fadeOut);
    }
}
