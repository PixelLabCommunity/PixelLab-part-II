using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        var movement = transform;
        Vector2 position = movement.position;
        position.x = position.x + 0.0001f;
        movement.position = position;
    }
}
