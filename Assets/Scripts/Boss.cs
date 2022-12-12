using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] float speed = 0.2f;
    [SerializeField] int EnemyHP = 10;
    [SerializeField] bool isBoss;
    [SerializeField] SpriteRenderer spriteRenderer;
    GameObject player;
    int maxEnemyHp;
    Material material;


    private void Start()
    {
        maxEnemyHp = EnemyHP;
        player = GameObject.FindGameObjectWithTag("Player");
        material = spriteRenderer.material;
        if (isBoss)
        {
            StartCoroutine(BossCameraCoroutine());
        }
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

        if (EnemyHP <= maxEnemyHp/2)
        {
            speed = 3;
            material.SetFloat("_Flash", 5f);
        }
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
            player.Ondamage(3);
        }

        if (EnemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator BossCameraCoroutine()
    {
        Time.timeScale = 0;
        Camera.main.GetComponent<PlayerCamera>().target = gameObject;
        yield return new WaitForSecondsRealtime(2f);
        Camera.main.orthographicSize = 2;
        yield return new WaitForSecondsRealtime(1f);
        Camera.main.GetComponent<PlayerCamera>().target = player.gameObject;        
        Camera.main.orthographicSize = 5;
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1;
    }
}
