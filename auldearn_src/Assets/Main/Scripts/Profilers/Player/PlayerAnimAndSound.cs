using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimAndSound : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _bodyPhysics;
    private KnightControls _controls;
    private AudioSource _audio;
    private readonly float _maxSpeed = 5f;
    private int _profile;
    private int _rightAttack, _leftAttack, _dodgeR, _dodgeL, _death;
    private GameObject _player;
    public AudioClip[] swordSFX;
    public GameObject playerFootsteps;
    public static bool dodgeActive;

    private void Awake()
    {
        _bodyPhysics = GetComponent<Rigidbody>();
        _controls = new KnightControls();
    }
    
    private void Start()
    {
        _player = GameObject.Find("Player/knight");
        _audio = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _rightAttack = Animator.StringToHash("RightAttack");
        _leftAttack = Animator.StringToHash("LeftAttack");
        _dodgeR = Animator.StringToHash("DodgeRight");
        _dodgeL = Animator.StringToHash("DodgeLeft");
        _death = Animator.StringToHash("Death");
        _profile = Animator.StringToHash("Profile");
    }

    private void Update()
    {
        _animator.SetFloat(_profile, _bodyPhysics.velocity.magnitude / _maxSpeed);

        if (!CombatManager.playerDead) return;
        _animator.SetTrigger(_death);
        _player.GetComponent<PlayerProfiler>().enabled = false;
    }


    private void OnEnable()
    {
        _controls.Profiler.DodgeRight.started += DodgeRight;
        _controls.Profiler.DodgeLeft.started += DodgeLeft;
        _controls.Profiler.AttackRight.started += RightAttack;
        _controls.Profiler.AttackLeft.started += LeftAttack;
        _controls.Profiler.Enable();
    }
    
    private void OnDisable()
    {
        _controls.Profiler.DodgeRight.started -= DodgeRight;
        _controls.Profiler.DodgeLeft.started -= DodgeLeft;
        _controls.Profiler.AttackRight.started -= RightAttack;
        _controls.Profiler.AttackLeft.started -= LeftAttack;
        _controls.Profiler.Disable();
    }

    private void RightAttack(InputAction.CallbackContext obj)
    {
        _animator.SetTrigger(_rightAttack);
    }

    private void LeftAttack(InputAction.CallbackContext obj)
    {
        _animator.SetTrigger(_leftAttack);
    }

    private void DodgeRight(InputAction.CallbackContext obj)
    {
        _animator.SetTrigger(_dodgeR);
        dodgeActive = true;
        StartCoroutine(DodgeActive());
    }
    
    private void DodgeLeft(InputAction.CallbackContext obj)
    {
        _animator.SetTrigger(_dodgeL);
        dodgeActive = true;
        StartCoroutine(DodgeActive());
    }


    private void SwordSFX()
    {
        _audio.PlayOneShot(swordSFX[Random.Range(0, swordSFX.Length)]);
    }
    
    private void Footsteps()
    {
        playerFootsteps.GetComponent<PlayerFootsteps>().FootstepSounds();
    }

    private IEnumerator DodgeActive()
    {
        yield return new WaitForSeconds(1f);
        dodgeActive = false;
    }
}