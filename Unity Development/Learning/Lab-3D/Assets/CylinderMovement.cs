using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CylinderMovement : MonoBehaviour
{
    private const int StartPoint = 0;
    [SerializeField] private float speed = 10f;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        switch (_rigidbody.velocity.x)
        {
            case < StartPoint:
                Debug.LogWarning("You are GOING LEFT");
                break;
            case > StartPoint:
                Debug.LogWarning("You are GOING RIGHT!!!!!");
                break;
        }
    }

    private void OnRestartGame()
    {
        RestartScene();
    }

    private void OnMove(InputValue inputValue)
    {
        _rigidbody.velocity = inputValue.Get<Vector3>() * speed;
    }

    private static void RestartScene()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }
}