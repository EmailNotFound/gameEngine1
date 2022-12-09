using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lvlbar : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Image Lvlforeg;

    private void Update()
    {
        if (player != null)
        {
            float expRatio = (float)player.curExp / player.Exptolvl;
            Lvlforeg.transform.localScale = new Vector3(expRatio, 1, 1);
        }
    }
}
