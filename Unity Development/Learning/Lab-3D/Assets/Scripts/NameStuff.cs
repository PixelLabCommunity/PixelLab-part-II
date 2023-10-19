using UnityEngine;

public class NameStuff : MonoBehaviour
{
    public string nameOne;
    public string nameTwo;
    public string nameThree;

    public NameStuff(string name1, string name2, string name3)
    {
        nameOne = name1;
        nameTwo = name2;
        nameThree = name3;
    }

    public NameStuff()
    {
        nameOne = "Anny";
        nameTwo = "Bob";
        nameThree = "Carl";
    }
}