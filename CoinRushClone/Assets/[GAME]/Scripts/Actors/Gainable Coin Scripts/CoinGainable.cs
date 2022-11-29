using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGainable : MonoBehaviour, IGainable
{
    public void BeGained()
    {
        gameObject.SetActive(false);
    }
}
