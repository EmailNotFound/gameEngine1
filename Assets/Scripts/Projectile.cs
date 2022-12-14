using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameObject player;
    private float speed = 2f;

    void Update()
    {
        StartCoroutine(ProjectileCoroutine());
        
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            player.Ondamage(1);
        }        
    }

    IEnumerator ProjectileCoroutine()
    {
        while (true)
        {
            Vector3 destination = player.transform.position;
            Vector3 source = transform.position;

            Vector3 direction = destination - source;
            direction.Normalize();
            transform.position += direction * Time.deltaTime * speed;


            transform.localScale = new Vector3(direction.x > 0 ? -1 : 1, 1, 1);
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }
    }
}
