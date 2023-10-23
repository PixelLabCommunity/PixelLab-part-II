using UnityEngine;

public class Directions : MonoBehaviour
{
    private void Start()
    {
        BaseDirections myDirections;
        myDirections = BaseDirections.East;
    }

    private void Update()
    {
        Debug.Log($"Now I can move to {BaseDirections.North}");
    }

    private BaseDirections SetDirections(BaseDirections dir)
    {
        if (dir == BaseDirections.North)
            dir = BaseDirections.South;
        else if (dir == BaseDirections.South)
            dir = BaseDirections.North;
        else if (dir == BaseDirections.West)
            dir = BaseDirections.East;
        else if (dir == BaseDirections.East) dir = BaseDirections.West;

        return dir;
    }

    private enum BaseDirections
    {
        North = 0,
        South = 1,
        East = 2,
        West = 3
    }
}