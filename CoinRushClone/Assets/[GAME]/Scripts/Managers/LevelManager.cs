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
    public event Action OnLevelFinished; // i said here event Because of i dont want to call this Action by me distracted


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
        OnLevelFinishedAsFail += LevelFinished;
        OnLevelFinishedAsSucces += LevelFinished;
    }

    private void Start()
    {
        OnLevelStarted?.Invoke();
    }
    private void LevelFinished()
    {

        OnLevelFinished?.Invoke();

    }

    public void SetNewLevel()
    {
        OnLevelLoad?.Invoke();
        OnLevelStarted?.Invoke();

    }
   


}
