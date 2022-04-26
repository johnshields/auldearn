using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

// Ref: https://youtu.be/UjkSFoLxesw
public class BossProfiler : MonoBehaviour
{
    private static int _idle, _walk, _run, _death;
    private static Animator _animator;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundMask, playerMask;

    //Patrolling
    public Vector3 walkPoint;
    private bool _walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool _alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Start()
    {
        player = GameObject.Find("Player/knight").transform;
        agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _idle = Animator.StringToHash("IdleActive");
        _walk = Animator.StringToHash("WalkActive");
        _run = Animator.StringToHash("RunActive");
        _death = Animator.StringToHash("Death");
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerMask);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackMode();
    }

    private void Patrolling()
    {
        print("Patrol");
        if (!_walkPointSet) SearchWalkPoint();

        if (_walkPointSet)
        {
            agent.SetDestination(walkPoint);
            _animator.SetBool(_idle, false);
            _animator.SetBool(_walk, true);
            _animator.SetBool(_run, false);
        }

        var distanceToWalkPoint = transform.position - walkPoint;

        //WalkPoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            _walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        print("Search");

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
        print("Chase");
        _animator.SetBool(_idle, false);
        _animator.SetBool(_walk, false);
        _animator.SetBool(_run, true);
        agent.SetDestination(player.position);
    }

    private void AttackMode()
    {
        print("Attack");
        // Boss does not move and looks at player.
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        _animator.SetBool(_idle, true);
        _animator.SetBool(_walk, false);
        _animator.SetBool(_run, false);
        
        if (!_alreadyAttacked)
        {
            // attack
            _alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        _alreadyAttacked = false;
    }

    public static void Death()
    {
        _animator.SetBool(_death, true);
    }
}