using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// References the singleton to create instance
public class GameManager : Singleton<GameManager>
{
    public GameObject playerPrefab;

    //Creates instance via singleton
    protected override void Awake()
    {
        base.Awake();
    }

}