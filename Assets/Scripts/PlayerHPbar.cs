using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPbar : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image foreground;

    private void Update()
    {
        if (player != null)
        {
            transform.position = player.transform.position + new Vector3(0, 0.7f, 0);

            float hpRatio = (float)player.playerHP / player.maxplayerHP;
            foreground.transform.localScale = new Vector3(hpRatio, 1, 1);            
        }
    }
}
