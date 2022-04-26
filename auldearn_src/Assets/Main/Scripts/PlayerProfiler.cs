using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerProfiler : MonoBehaviour
{
    private int _idleActive, _walkActive, _runActive;
    private GameObject _player;
    private Animator _animator;

    private void Start()
    {
        foreach (var t in Gamepad.all) 
            Debug.Log(t.name);
        
        _player = GameObject.Find("Player/knight");
        _animator = GetComponent<Animator>();
        _idleActive = Animator.StringToHash("IdleActive");
        _walkActive = Animator.StringToHash("WalkActive");
        _runActive = Animator.StringToHash("RunActive");
    }

    private void FixedUpdate()
    {
        MainProfiles();
    }

    private void AnimationState(bool idle, bool walk, bool run)
    {
        _animator.SetBool(_idleActive, idle);
        _animator.SetBool(_walkActive, walk);
        _animator.SetBool(_runActive, run);
    }

    private void MainProfiles()
    {
        if (Gamepad.all.Count > 0)
        {
            if (Gamepad.all[0].leftStick.up.isPressed)
            {
                AnimationState(false, true, false); // walk
                _player.transform.position += Vector3.forward * Time.deltaTime * 3f;
            }
            else if (Gamepad.all[0].leftStick.down.isPressed)
            {
                AnimationState(false, true, false); // walk
                _player.transform.position += Vector3.back * Time.deltaTime * 3f;
            }
            else if (Gamepad.all[0].leftStick.left.isPressed)
            {
                AnimationState(false, true, false); // walk
                _player.transform.position += Vector3.left * Time.deltaTime * 3f;
            }
            else if (Gamepad.all[0].leftStick.right.isPressed)
            {
                AnimationState(false, true, false); // walk
                _player.transform.position += Vector3.right * Time.deltaTime * 3f;
            }
            else if (Gamepad.all[0].aButton.isPressed)
            {
                AnimationState(false, false, true); // run
                _player.transform.position += Vector3.forward * Time.deltaTime * 6f;
            }
            else
            {
                AnimationState(true, false, false); // idle
            }
        }
    }
}