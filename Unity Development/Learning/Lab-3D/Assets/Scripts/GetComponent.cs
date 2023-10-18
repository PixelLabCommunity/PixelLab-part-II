using UnityEngine;

public class GetComponent : MonoBehaviour
{
    private HeroesNames _heroesNames;
    private ScoreScript _scoreScripts;

    private void Awake()
    {
        _scoreScripts = GetComponent<ScoreScript>();
        _heroesNames = GetComponent<HeroesNames>();
    }

    private void Start()
    {
        Debug.Log($"Score Result is: {_scoreScripts.scoreResult} for the {_heroesNames.firstPlayer}");
        Debug.Log($"Score Result for Loser is: {_scoreScripts.scoreResultFail} for the" +
                  $" {_heroesNames.secondPlayer}");
        Debug.Log($"YES!! GRATZZZZ {_heroesNames.firstPlayer} !!!!");
    }
}