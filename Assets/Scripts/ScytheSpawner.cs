using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheSpawner : MonoBehaviour
{
    [SerializeField] GameObject Scythe;
    [SerializeField] ObjectPool Scythepool;
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
            var scythe = Scythepool.Get();
            scythe.transform.position = transform.position;
            scythe.transform.rotation = Quaternion.Euler(0, 0, angle);
            scythe.SetActive(true);

        }
    }
}
