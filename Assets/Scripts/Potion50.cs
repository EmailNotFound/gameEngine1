using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion50 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int rep = 1;
        float potion50 = rep / 2;
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.Addhp(potion50);
            Destroy(gameObject);
        }
    }
}
