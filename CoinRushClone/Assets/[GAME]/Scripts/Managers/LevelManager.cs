using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{

    public Action OnLevelLoad;
    public Action OnLevelFinishedAsFail;
    public Action OnLevelFinishedAsSucces;
    public Action OnLevelStarted;
    

    private int _levelNumber;
    public int LevelNumber
    {

        get
        {

            return _levelNumber;

        }
        set
        {

            _levelNumber = value;

            PlayerPrefs.SetInt(GlobalStrings.LevelNumber, _levelNumber);

        }

    }


    private void Awake()
    {
        LevelNumber = PlayerPrefs.GetInt(GlobalStrings.LevelNumber);
    }





}
