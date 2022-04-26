using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerProfiler : MonoBehaviour
{
    private int _idleActive, _walkActive, _runActive, _left, _right, _back;
    private int _rightAttack, _leftAttack, _dodge;
    private GameObject _player;
    private Animator _animator;
    private Vector2 _aim;

    private void Start()
    {
        foreach (var t in Gamepad.all)
            Debug.Log(t.name);

        _player = GameObject.Find("Player/knight");
        _animator = GetComponent<Animator>();
        _idleActive = Animator.StringToHash("IdleActive");
        _walkActive = Animator.StringToHash("WalkActive");
        _runActive = Animator.StringToHash("RunActive");
        _left = Animator.StringToHash("Left");
        _right = Animator.StringToHash("Right");
        _back = Animator.StringToHash("Back");
        _leftAttack = Animator.StringToHash("LeftAttack");
        _rightAttack = Animator.StringToHash("RightAttack");
        _dodge = Animator.StringToHash("Dodge");
    }

    private void FixedUpdate()
    {
        MainProfiles();
        CombatProfile();
    }

    private void AnimationState(bool idle, bool walk, bool run, 
        bool left, bool right, bool back, bool leftA, bool rightA, bool dodge)
    {
        _animator.SetBool(_idleActive, idle);
        _animator.SetBool(_walkActive, walk);
        _animator.SetBool(_runActive, run);
        _animator.SetBool(_left, left);
        _animator.SetBool(_right, right);
        _animator.SetBool(_back, back);
        _animator.SetBool(_leftAttack, leftA);
        _animator.SetBool(_rightAttack, rightA);
        _animator.SetBool(_dodge, dodge);
    }

    private void MainProfiles()
    {
        if (Gamepad.all.Count <= 0) return;
        if (Gamepad.all[0].leftStick.up.isPressed)
        {
            AnimationState(false, true, false, false, false, false, false, false, false); // forward
            _player.transform.position += Vector3.forward * Time.deltaTime * 3f;
        }
        else if (Gamepad.all[0].leftStick.down.isPressed)
        {
            AnimationState(false, false, false, false, false, true, false, false, false); // back
            _player.transform.position += Vector3.back * Time.deltaTime * 2f;
        }
        else if (Gamepad.all[0].leftStick.left.isPressed)
        {
            AnimationState(false, false, false, true, false, false, false, false, false); // left
            _player.transform.position += Vector3.left * Time.deltaTime * 3f;
        }
        else if (Gamepad.all[0].leftStick.right.isPressed)
        {
            AnimationState(false, false, false, false, true, false, false, false, false); // right
            _player.transform.position += Vector3.right * Time.deltaTime * 3f;
        }
        else if (Gamepad.all[0].aButton.isPressed)
        {
            AnimationState(false, false, true, false, false, false, false, false, false); // run
            _player.transform.position += Vector3.forward * Time.deltaTime * 6f;
        }
        else
        {
            AnimationState(true, false, false, false, false, false, false, false, false); // idle
        }
    }

    private void CombatProfile()
    {
        if (Gamepad.all[0].leftTrigger.isPressed)
        {
            AnimationState(false, false, false, false, false, false, true, false, false); // left
            print("Left swing...");
        }
        else if (Gamepad.all[0].rightTrigger.isPressed)
        {
            AnimationState(false, false, false, false, false, false, false, true, false); // right
            print("Right swing...");
        }
        else if (Gamepad.all[0].xButton.isPressed)
        {
            AnimationState(false, false, false, false, false, false, false, false, true); // dodge
            _player.transform.position += Vector3.back * Time.deltaTime * 2f;
        }
    }
}