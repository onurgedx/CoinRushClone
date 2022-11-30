using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasManager : MonoSingleton<CanvasManager>
{

    [SerializeField] private Text _coinCountText;

    private void Start()
    {
        CoinEntityManager.Instance.OnCoinCountChange += ChangeCoinCountText;

    }
    private void ChangeCoinCountText(int coincount)
    {

        _coinCountText.text = "Coin Count :  " + coincount.ToString() + "  ";

    }






}
