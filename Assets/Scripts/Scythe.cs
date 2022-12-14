using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : MonoBehaviour
{
    void Update()
    {
        transform.position += transform.up * 4 * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.Damage(1);
            Destroy(gameObject);
        }
        Boss boss = collision.gameObject.GetComponent<Boss>();
        if (boss)
        {
            boss.Damage(1);
            Destroy(gameObject);
        }
    }

}
