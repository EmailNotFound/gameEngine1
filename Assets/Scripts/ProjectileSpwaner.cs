using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpwaner : MonoBehaviour
{
    [SerializeField] GameObject Projectile;

    void Start()
    {
        StartCoroutine(ProjectileSpawnerCoroutine());
    }

    IEnumerator ProjectileSpawnerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            float angle = Random.Range(0, 360);
            Instantiate(Projectile, transform.position, Quaternion.Euler(0, 0, angle));

        }
    }
}
