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

    private readonly Vector3 _changeRotation = new(0, -180, 0);
    private readonly Vector3 _stateRotation = new(0, 0, 0);

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

    private void Update()
    {
        AiState();
    }

    private void AiState()
    {
        switch (_state)
        {
            default:
            case State.Wandering:
                _currentTime -= Time.deltaTime;
                if (_currentTime < BaseTime)
                {
                    Wandering();
                    _currentTime = wanderTimerMax;
                }

                break;
        }
    }

    private void Wandering()
    {
        _startingPosition = transform.position;
        _wanderPosition = GetWanderPosition();
        ChangeFacingDirection(_startingPosition, _wanderPosition);
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

    private void ChangeFacingDirection(Vector2 sourcePosition, Vector2 targetPosition)
    {
        transform.rotation = sourcePosition.x > targetPosition.x
            ? Quaternion.Euler(_changeRotation)
            : Quaternion.Euler(_stateRotation);
    }

    private enum State
    {
        Wandering
    }
}