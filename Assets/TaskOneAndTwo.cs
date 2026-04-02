using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TaskOneAndTwo : MonoBehaviour
{

    public static string[] firstNames =
    {
        "Chandler",
        "Summer",
        "Elle",
        "Cami",
        "Lauren",
        "Chase",
        "Sercan",
        "Mars",
        "Brady",
        "Julia",
        "Rebecca",
        "Ryan",
        "Jay",
        "Thanh",
        "Melody",
        "Luc",
        "Maria",
        "Salma",
        "Alessandra",
        "Yousef",
        "Catalina",
    };

    public static string[] lastInitials = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    public Queue<string> loginQueue = new Queue<string>();


    public int GetRandomNum()
    {
        return UnityEngine.Random.Range(0, 21);
    }

    public string GetRandomPlayerName()
    {
        string randomName = firstNames[GetRandomNum()] + " " + lastInitials[GetRandomNum()]; // are the names supposed to have periods at the end?

        //Debug.Log(randomName);

        return randomName;
    }


    // Start is called before the first frame update
    void Start()
    {
        //GetRandomPlayerName();
        for(int i = 0; i<6; i++)
        {
            loginQueue.Enqueue(GetRandomPlayerName());
        }
        var playerListQuery = from name in loginQueue
                              select name;
        List<string> playerList = playerListQuery.ToList();
        foreach(var name in playerList)
        {
            //Debug.LogFormat(""
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
