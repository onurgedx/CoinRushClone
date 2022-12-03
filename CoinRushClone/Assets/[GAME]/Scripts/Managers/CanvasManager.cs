using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasManager : MonoSingleton<CanvasManager>
{

    [SerializeField] private Text _coinCountText;


    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;



    private void Start()
    {
        CoinEntityManager.Instance.OnCoinCountChange += ChangeCoinCountText;

        LevelManager.Instance.OnLevelFinishedAsFail += ActivateLosePanel;
        LevelManager.Instance.OnLevelFinishedAsSucces += ActivateWinPanel;

        LevelManager.Instance.OnLevelLoad += DeactivateLosePanel ;
        LevelManager.Instance.OnLevelLoad += DeactivateWinPanel;


    }
    private void ChangeCoinCountText(int coincount)
    {

        _coinCountText.text = "Coin Count :  " + coincount.ToString() + "  ";

    }


    private void ActivateWinPanel()
    {
        _winPanel.SetActive(true);

    }

    private void DeactivateWinPanel()
    {
        _winPanel.SetActive(false);
    }


    private void ActivateLosePanel()
    {
        _losePanel.SetActive(true);
    }

    private void DeactivateLosePanel()
    {
        _losePanel.SetActive(false);
    }


}
