using UnityEngine;

public class PlayerProfiler : MonoBehaviour
{
    public float lowProfile, highProfile, rotationSpeed;
    private float _currentProfile;
    private int _idleActive, _walkActive, _runActive;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _idleActive = Animator.StringToHash("IdleActive");
        _walkActive = Animator.StringToHash("WalkActive");
        _runActive = Animator.StringToHash("RunActive");
    }

    private void FixedUpdate()
    {
        MainProfiles();
    }

    private void AnimationState(bool idle, bool walk, bool run, bool attack)
    {
        _animator.SetBool(_idleActive, idle);
        _animator.SetBool(_walkActive, walk);
        _animator.SetBool(_runActive, run);
    }

    private void MainProfiles()
    {
        // allow character to walk (using y axis keys).
        var z = Input.GetAxis("Vertical") * _currentProfile;
        transform.Translate(0, 0, z);
        // allow character to rotate (using y axis keys).
        var y = Input.GetAxis("Horizontal") * rotationSpeed;
        transform.Rotate(0, y, 0);

        var forwardPressed = Input.GetKey(KeyCode.W);
        var upArrow = Input.GetKey(KeyCode.UpArrow);
        var hpPressed = Input.GetKey(KeyCode.LeftShift);

        if (!hpPressed)
        {
            if (forwardPressed || upArrow)
                AnimationState(false, true, false, false); // walk
            else
                AnimationState(true, false, false, false); // idle

            _currentProfile = lowProfile;
        }
        else
        {
            if (forwardPressed || upArrow)
                AnimationState(false, false, true, false); // run
            else
                AnimationState(true, false, false, false); // idle

            _currentProfile = highProfile;
        }
    }
}