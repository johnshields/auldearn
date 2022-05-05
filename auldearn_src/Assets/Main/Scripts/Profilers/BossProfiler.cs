using System.Collections;
using UnityEngine;
using UnityEngine.AI;

// Ref: https://youtu.be/UjkSFoLxesw
public class BossProfiler : MonoBehaviour
{
    private static Animator _animator;
    public AudioClip[] gollemSFX;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundMask, playerMask;
    public GameObject bossFootsteps;

    // patrolling
    public Vector3 walkPoint;
    public float walkPointRange;

    // states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    // attacking
    private bool _alreadyAttacked;
    private AudioSource _audio;
    private int _idle, _walk, _run, _death, _leftA, _rightA;
    private bool _walkPointSet;
    public static bool combat;

    private void Awake()
    {
        combat = false;
        _audio = GetComponent<AudioSource>();
        player = GameObject.Find("Player/knight").transform;
        agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _idle = Animator.StringToHash("IdleActive");
        _walk = Animator.StringToHash("WalkActive");
        _run = Animator.StringToHash("RunActive");
        _death = Animator.StringToHash("Death");
        _leftA = Animator.StringToHash("LeftP");
        _rightA = Animator.StringToHash("RightP");
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackMode();
    }

    private void AnimationState(bool idle, bool walk, bool run, bool leftP, bool rightP, bool death)
    {
        _animator.SetBool(_idle, idle);
        _animator.SetBool(_walk, walk);
        _animator.SetBool(_run, run);
        _animator.SetBool(_leftA, leftP);
        _animator.SetBool(_rightA, rightP);
        _animator.SetBool(_death, death);
    }

    private void Patrolling()
    {
        if (!_walkPointSet) SearchWalkPoint();

        if (_walkPointSet)
        {
            agent.SetDestination(walkPoint);
            AnimationState(false, true, false, false, false, false);
        }

        var distanceToWalkPoint = transform.position - walkPoint;

        //WalkPoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            _walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        var randomZ = Random.Range(-walkPointRange, walkPointRange);
        var randomX = Random.Range(-walkPointRange, walkPointRange);

        // check if point is on ground
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundMask))
            _walkPointSet = true;
    }

    private void ChasePlayer()
    {
        AnimationState(false, false, true, false, false, false);
        agent.SetDestination(player.position);
        combat = true;
    }

    private void AttackMode()
    {
        // Boss does not move and looks at player.
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        AnimationState(true, false, false, false, false, false);

        if (!_alreadyAttacked && CombatManager.playerHealth >= 0)
        {
            var attackBool = Random.Range(0, 2);
            switch (attackBool)
            {
                // attack
                case 0:
                    AnimationState(false, false, false, true, false, false);
                    StartCoroutine(AttackComplete());
                    break;
                case 1:
                    AnimationState(false, false, false, false, true, false);
                    StartCoroutine(AttackComplete());
                    break;
            }
        }

        if (CombatManager.bossDead)
        {
            AnimationState(true, false, false, false, false, false);
            StartCoroutine(Death());
        }
    }

    private void GollemSFX()
    {
        _audio.PlayOneShot(gollemSFX[Random.Range(0, gollemSFX.Length)]);
    }
    
    private void Footsteps()
    {
        bossFootsteps.GetComponent<BossFootsteps>().FootstepSounds();
    }


    private IEnumerator AttackComplete()
    {
        yield return new WaitForSeconds(1.28f);
        _alreadyAttacked = true;
        StartCoroutine(ResetAttack());
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(1f);
        _alreadyAttacked = false;
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(0.1f);
        AnimationState(false, false, false, false, false, true);
    }
}