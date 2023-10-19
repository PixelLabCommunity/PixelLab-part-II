using UnityEngine;

public class PlayersSetUp : MonoBehaviour
{
    [SerializeField] private GameObject[] players;

    private void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        for (var i = 0; i < players.Length; i++) Debug.Log($"Player number {i} is the name : {players[i].name}");
    }
}