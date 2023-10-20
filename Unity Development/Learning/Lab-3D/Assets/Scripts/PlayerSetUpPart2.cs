using UnityEngine;

public class PlayerSetUpPart2 : MonoBehaviour
{
    [SerializeField] private GameObject[] playersArray;

    private void Start()
    {
        for (var i = 0; i < playersArray.Length; i++)
            Debug.Log($"Players numbers is: {i} for players names is: {playersArray[i].name}");
    }
}