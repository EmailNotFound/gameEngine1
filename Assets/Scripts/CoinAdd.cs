using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAdd : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            Coin.CoinAdd();
            Destroy(gameObject);
            TitleManager.saveData.goldCoins++;
        }
    }
}
