using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExGameManager : MonoBehaviour
{
    public ExGameData gameDate;

    private void Start()
    {
        Debug.Log("Game Name : " + gameDate.gameName);
        Debug.Log("Game Score : " + gameDate.gameScore);
        Debug.Log("Is Game Active : " + gameDate.isGameActive);
    }

}
