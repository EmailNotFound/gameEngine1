using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion25 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int rep = 1;
        float potion25 = rep / 4;
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.Addhp(potion25);
            Destroy(gameObject);
        }
    }
}
