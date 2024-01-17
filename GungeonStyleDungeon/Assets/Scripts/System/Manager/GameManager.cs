using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGen = false;
    static GameManager gm_Instance;
    public static GameManager Instance
    {
        get
        {
            // if instance is NULL create instance
            if (!gm_Instance)
            {
                gm_Instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (gm_Instance == null)
                    Debug.Log("instance is NULL_GameManager");
            }
            return gm_Instance;
        }
    }



    ResourceManager _resource = new ResourceManager();
    public static ResourceManager Resource { get { return gm_Instance._resource; } }

    MapGen _mapGen = new MapGen();
    public static MapGen MapGen { get { return gm_Instance._mapGen; } }

    RandomEncounter _randomEncounter = new RandomEncounter();
    public static RandomEncounter Random { get { return gm_Instance._randomEncounter; } }

    StageController _stageController = new StageController();
    public static StageController StageC { get { return gm_Instance._stageController; } }

    public GameObject persistentObject;
    // == this

    private bool isPaused = false;
    // 시스템 변수

    

    private void Awake()
    {
        // Find System Components
        DontDestroyOnLoad(persistentObject);
        gm_Instance = this;
        bool isFirstRun = PlayerPrefs.GetInt("isFirstRun", 1) == 1;
        if (isFirstRun)
        {
            // is first
        }
        else
        {
            // else
        }

        Application.targetFrameRate = 60;

        init();
    }

    // Initialize System Components
    public void init()
    {
        Debug.Log("GameManager Awake Init");
        Random.init("");
        MapGen.init();
        StageC.init();
    }

    public static void addroom()
    {
        if (isGen)
        {
            StageC.AddRoom();
        }
    }
    

    public static void mapgen()
    {
        clear();
        StageC.gameStart();
        isGen = true;
    }

    public static void clear()
    {
        StageC.clear();
        MapGen.clear();
    }

}
