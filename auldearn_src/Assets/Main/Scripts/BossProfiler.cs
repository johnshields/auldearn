using UnityEngine;

public class BossProfiler : MonoBehaviour
{
    private static int _death;
    private static Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _death = Animator.StringToHash("Death");
    }

    public static void Death()
    {
        _animator.SetBool(_death, true);
    }
}