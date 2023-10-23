using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    private readonly int _answerChoise = 5;

    private void Start()
    {
        Dialogue();
    }

    private void Dialogue()
    {
        switch (_answerChoise)
        {
            case 1:
                print("Ok, I know it!");
                break;
            case 2:
                print("Well well well, here are we go!");
                break;
            case 3:
                print("Ok, Now I can do it");
                break;
            case 4:
                print("Well done!");
                break;
            case 5:
                print("Not a good choice! Try again!");
                break;
            default:
                print("You can choose between 5 points, try again!");
                break;
        }
    }
}