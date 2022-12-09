using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public static int coinAmount;
    public Text coinQuantity;

    public static void CoinAdd()
    {
        coinAmount += 1;
    }

    private void Start()
    {
        coinAmount = 0;
    }

    private void Update()
    {
        coinQuantity.text = coinAmount.ToString();
    }

    
}
