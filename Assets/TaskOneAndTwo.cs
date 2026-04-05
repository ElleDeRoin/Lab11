using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TaskOneAndTwo : MonoBehaviour
{
    // Task 1 and 2 variables and helper functions
    
    // TASK 1
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

    public bool QueueIsEmpty()
    {
        return loginQueue.Count == 0;
    }


    // TASK 2
    public string[] randomPlayerNames = new string[15];
    public HashSet<string> seen = new HashSet<string>();
    public HashSet<string> duplicates = new HashSet<string>();
    public void GetRandomFirstNames()
    {
        for(int i = 0; i<randomPlayerNames.Length; i++)
        {
            randomPlayerNames[i] = firstNames[GetRandomNum()];
        }
        string playerNames = "Created the name array: ";
        foreach (var name in randomPlayerNames)
        {
            playerNames += $"{name}, ";
        }
        playerNames = playerNames.TrimEnd(',', ' ');
        Debug.Log(playerNames);
    }



    // Start is called before the first frame update
    void Start()
    {
        // enqueue 4-6 players to the login queue
        for (int i = 0; i<UnityEngine.Random.Range(4, 7); i++)
        {
            loginQueue.Enqueue(GetRandomPlayerName());
        }
        

        // Start the tasks
        StartCoroutine(TaskManager());
    }



    IEnumerator TaskManager()
    {
        Debug.Log("TASK 1:");
        var playerListQuery = from name in loginQueue
                              select name;
        List<string> playerList = playerListQuery.ToList();

        // print initial state
        string initialState = $"Initial login queue created. There are {playerList.Count} players in the queue: ";
        foreach (var name in playerList)
        {
            // if time come back to remove last comma and space
            initialState += $"{name}., ";
        }
        initialState = initialState.TrimEnd(',', ' ');
        Debug.Log(initialState);

        Coroutine addPlayer = StartCoroutine(AddPlayer());
        Coroutine loginPlayer = StartCoroutine(LoginPlayer());
        yield return addPlayer;
        yield return loginPlayer;


        Debug.Log("TASK 2:");
        DetectDuplicateNames();
        yield return null;
    }

    // TASK 1
    IEnumerator AddPlayer()
    {
        while(!QueueIsEmpty())
        {
            yield return new WaitForSeconds(4);
            if(QueueIsEmpty())
            {
                yield break; // Exit the coroutine if the queue is empty
            }
            string newPlayer = GetRandomPlayerName();
            loginQueue.Enqueue(newPlayer);
            Debug.Log($"{newPlayer}. is trying to login and added to the login queue.");
        }
        yield return null;
    }

    IEnumerator LoginPlayer()
    {
        while (!QueueIsEmpty())
        {
            yield return new WaitForSeconds(3);
            if (QueueIsEmpty())
            {
                yield break; // Exit the coroutine if the queue is empty
            }
            string playerLoggingIn = loginQueue.Dequeue();
            Debug.Log($"{playerLoggingIn}. is now inside the game.");
        }
        Debug.Log("Login server is idle. No players are waiting.");
        yield return null;
    }


    // TASK 2
    public void DetectDuplicateNames()
    {
        // create list of names and search for duplicates
        GetRandomFirstNames();
        for (int i = 0; i < randomPlayerNames.Length; i++)
        {
            if (!seen.Add(randomPlayerNames[i]))
            {
                duplicates.Add(randomPlayerNames[i]);
            }
        }

        // print duplicate names
        if(duplicates.Count() > 0)
        {
            string duplicateNames = string.Join(", ", duplicates);
            string result = "The array has duplicate names: " + duplicateNames;
            Debug.Log(result);

        }
        else
        {
            Debug.Log("The array has no duplicate names.");
        }
    }
}
