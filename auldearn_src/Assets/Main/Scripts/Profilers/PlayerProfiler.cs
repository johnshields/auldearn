using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerProfiler : MonoBehaviour
{
    public AudioClip[] swordSFX;
    private Animator _animator;
    private AudioSource _audio;
    private GameObject _player;
    private int _idleActive, _walkActive, _runActive, _left, _right, _back;
    private int _rightAttack, _leftAttack, _dodge, _death;

    private void Start()
    {
        _player = GameObject.Find("Player/knight");
        _audio = GetComponent<AudioSource>();
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
        _death = Animator.StringToHash("Die");
    }

    private void FixedUpdate()
    {
        MainProfiles();
        CombatProfile();
        RotateRound();
    }

    private bool IsBetween(double testValue, double bound1, double bound2)
    {
        if (bound1 > bound2)
            return testValue >= bound2 && testValue <= bound1;
        return testValue >= bound1 && testValue <= bound2;
    }

    private void AnimationState(bool idle, bool walk, bool run,
        bool left, bool right, bool back, bool leftA, bool rightA, bool dodge, bool death)
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
        _animator.SetBool(_death, death);
    }

    private void MainProfiles()
    {
        var tr = _player.transform.rotation;

        if (Gamepad.all.Count <= 0) return;
        if (Gamepad.all[0].leftStick.up.isPressed)
        {
            AnimationState(false, true, false, false, false, false, false, false, false, false); // forward
            _player.transform.position += IsBetween(tr.y, 0.7f, 1f) || IsBetween(tr.y, -0.7f, -1f)
                ? Vector3.back * Time.deltaTime * 3f
                : Vector3.forward * Time.deltaTime * 3f;
        }
        else if (Gamepad.all[0].leftStick.down.isPressed)
        {
            AnimationState(false, false, false, false, false, true, false, false, false, false); // back
            _player.transform.position += IsBetween(tr.y, 0.7f, 1f) || IsBetween(tr.y, -0.7f, -1f)
                ? Vector3.forward * Time.deltaTime * 2f
                : Vector3.back * Time.deltaTime * 2f;
        }
        else if (Gamepad.all[0].leftStick.left.isPressed)
        {
            AnimationState(false, false, false, true, false, false, false, false, false, false); // left
            _player.transform.position += IsBetween(tr.y, 0.7f, 1f) || IsBetween(tr.y, -0.7f, -1f)
                ? Vector3.right * Time.deltaTime * 3f
                : Vector3.left * Time.deltaTime * 3f;
        }
        else if (Gamepad.all[0].leftStick.right.isPressed)
        {
            AnimationState(false, false, false, false, true, false, false, false, false, false); // right
            _player.transform.position += IsBetween(tr.y, 0.7f, 1f) || IsBetween(tr.y, -0.7f, -1f)
                ? Vector3.left * Time.deltaTime * 3f
                : Vector3.right * Time.deltaTime * 3f;
        }
        else if (Gamepad.all[0].rightShoulder.isPressed)
        {
            AnimationState(false, false, true, false, false, false, false, false, false, false); // run
            _player.transform.position += IsBetween(tr.y, 0.7f, 1f) || IsBetween(tr.y, -0.7f, -1f)
                ? Vector3.back * Time.deltaTime * 6f
                : Vector3.forward * Time.deltaTime * 6f;
        }
        else
        {
            AnimationState(true, false, false, false, false, false, false, false, false, false); // idle
        }
    }

    private void RotateRound()
    {
        if (Gamepad.all[0].rightStick.right.isPressed)
            transform.Rotate(new Vector3(0f, 2.5f, 0f));
        else if (Gamepad.all[0].rightStick.left.isPressed)
            transform.Rotate(new Vector3(0f, -2.5f, 0f));
    }

    private void CombatProfile()
    {
        var tr = _player.transform.rotation;

        if (Gamepad.all.Count <= 0) return;
        if (Gamepad.all[0].leftTrigger.isPressed)
            AnimationState(false, false, false, false, false, false, true, false, false, false); // left
        else if (Gamepad.all[0].rightTrigger.isPressed)
            AnimationState(false, false, false, false, false, false, false, true, false, false); // right
        else if (Gamepad.all[0].xButton.isPressed)
        {
            AnimationState(false, false, false, false, false, false, false, false, true, false); // dodge
            _player.transform.position += IsBetween(tr.y, 0.7f, 1f) || IsBetween(tr.y, -0.7f, -1f)
                ? Vector3.forward * Time.deltaTime * 2f
                : Vector3.back * Time.deltaTime * 2f;
        }

        if (CombatManager.playerDead)
        {
            // to transition to death...
            AnimationState(true, false, false, false, false, false, false, false, false, false);
            StartCoroutine(Wait());
        }
    }

    private void SwordSFX()
    {
        _audio.PlayOneShot(swordSFX[Random.Range(0, swordSFX.Length)]);
    }

    private IEnumerator Wait()
    {
        // kill player and disable Profiler.
        yield return new WaitForSeconds(0.05f);
        AnimationState(false, false, false, false, false, false, false, false, false, true);
        yield return new WaitForSeconds(0.2f);
        _player.GetComponent<PlayerProfiler>().enabled = false;
    }
}