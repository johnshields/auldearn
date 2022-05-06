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
    private int _rightAttack, _leftAttack, _dodge, _death;
    private GameObject _player;
    public AudioClip[] swordSFX;
    public GameObject playerFootsteps;

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
        _dodge = Animator.StringToHash("Dodge");
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
        _controls.Profiler.Dodge.started += Dodge;
        _controls.Profiler.AttackRight.started += RightAttack;
        _controls.Profiler.AttackLeft.started += LeftAttack;
        _controls.Profiler.Enable();
    }

    private void OnDisable()
    {
        _controls.Profiler.Dodge.started -= Dodge;
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

    private void Dodge(InputAction.CallbackContext obj)
    {
        _animator.SetTrigger(_dodge);
        transform.position += Vector3.back * Time.deltaTime * 2f;
    }

    private void SwordSFX()
    {
        _audio.PlayOneShot(swordSFX[Random.Range(0, swordSFX.Length)]);
    }
    
    private void Footsteps()
    {
        playerFootsteps.GetComponent<PlayerFootsteps>().FootstepSounds();
    }
}