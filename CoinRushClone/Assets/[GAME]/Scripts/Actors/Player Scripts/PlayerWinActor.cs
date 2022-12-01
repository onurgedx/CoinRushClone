using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinActor : MonoBehaviour
{
    
    private void FinishLevelAsWin()
    {
        LevelManager.Instance.OnLevelFinishedAsSucces();
    }


}
