using Forest2D.Utils;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private const float BaseTime = 0f;
    [SerializeField] private State startingState;
    [SerializeField] private float wanderDistanceMax = 7f;
    [SerializeField] private float wanderDistanceMin = 3f;
    [SerializeField] private float wanderTimerMax = 2f;

    private float _currentTime;
    private NavMeshAgent _navMeshAgent;
    private Vector2 _startingPosition;
    private State _state;
    private Vector2 _wanderPosition;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        StartState();
    }

    private void Start()
    {
        _startingPosition = transform.position;
    }

    private void Update()
    {
        AiState();
    }

    private void AiState()
    {
        switch (_state)
        {
            default:
            case State.Idle:
                break;
            case State.Wandering:
                _currentTime -= Time.deltaTime;
                if (_currentTime < BaseTime)
                {
                    Wander();
                    _currentTime = wanderTimerMax;
                }

                break;
        }
    }

    private void Wander()
    {
        _wanderPosition = GetWanderPosition();
        _navMeshAgent.SetDestination(_wanderPosition);
    }

    private Vector2 GetWanderPosition()
    {
        return _startingPosition + ForestUtils.GetRandomDir() * Random.Range(wanderDistanceMin, wanderDistanceMax);
    }

    private void StartState()
    {
        _state = startingState;
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    private enum State
    {
        Idle,
        Wandering
    }
}