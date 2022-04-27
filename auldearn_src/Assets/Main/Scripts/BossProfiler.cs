using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

// Ref: https://youtu.be/UjkSFoLxesw
public class BossProfiler : MonoBehaviour
{
    private static int _idle, _walk, _run, _death, _leftA, _rightA;
    private static Animator _animator;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundMask, playerMask;

    // patrolling
    public Vector3 walkPoint;
    private bool _walkPointSet;
    public float walkPointRange;

    // attacking
    private bool _alreadyAttacked;

    // states
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
        print("Patrol");
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
        AnimationState(false, false, true, false, false, false);
        agent.SetDestination(player.position);
    }

    private void AttackMode()
    {
        print("Boss is in: AttackMode");
        // Boss does not move and looks at player.
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        AnimationState(true, false, false, false, false, false);

        if (!_alreadyAttacked)
        {
            var attackBool = Random.Range(0, 2);
            print("attackBool: " + attackBool);
            switch (attackBool)
            {
                // attack
                case 0:
                    print("Left punch...");
                    AnimationState(false, false, false, true, false, false);
                    StartCoroutine(AttackComplete());
                    break;
                case 1:
                    print("Right punch...");
                    AnimationState(false, false, false, false, true, false);
                    StartCoroutine(AttackComplete());
                    break;
            }

            print("Attack complete...");
        }
    }

    private IEnumerator AttackComplete()
    {
        yield return new WaitForSeconds(1.28f);
        _alreadyAttacked = true;
        StartCoroutine(ResetAttack());
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(2);
        _alreadyAttacked = false;
        print("Attack reset!");
    }

    public static void Death()
    {
        _animator.SetBool(_death, true);
    }
}