using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float speed = 1f;
    [SerializeField] int EnemyHP = 1;    
    [SerializeField] GameObject crystal;
    [SerializeField] GameObject potion25;
    [SerializeField] GameObject potion50;
    [SerializeField] GameObject gold;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        Vector3 destination = player.transform.position;
        Vector3 source = transform.position;

        Vector3 direction = destination - source;
        direction.Normalize();
        transform.position += direction * Time.deltaTime * speed;


        transform.localScale = new Vector3(direction.x > 0 ? -1 : 1, 1, 1);
    }

    public void Damage(int damage)
    {
        EnemyHP -= damage;
    }


    internal void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        
        if (player)
        {
            player.Ondamage(1);
            Destroy(gameObject);
        }

        if (EnemyHP <= 0)
        {
            Destroy(gameObject);
            int drop = Random.Range(1, 100);
            if (drop > 95)
            {
                Instantiate(potion50, transform.position, Quaternion.identity);
            }
            else if (drop > 50 && drop < 60)
            {
                Instantiate(potion25, transform.position, Quaternion.identity);
            }
            else if(drop%2 == 0)
            {
                Instantiate(crystal, transform.position, Quaternion.identity);
            }
            var coinPrefab = PoolManager.GetInstance().Coinspool.Get();
            coinPrefab.transform.position = transform.position;
            coinPrefab.transform.rotation = Quaternion.identity;
            coinPrefab.SetActive(true);
            TitleManager.saveData.goldCoins++;
        }
    }

}
