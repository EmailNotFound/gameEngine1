using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheSpawner : MonoBehaviour
{
    [SerializeField] GameObject Scythe;
    void Start()
    {
        StartCoroutine(ScytheSpawnerCoroutine());
    }

    IEnumerator ScytheSpawnerCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            float angle = Random.Range(0, 360);
            Instantiate(Scythe, transform.position, Quaternion.Euler(0, 0, angle));

        }
    }
}
