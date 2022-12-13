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
    Animator animator;


    private void Start()
    {
        maxEnemyHp = EnemyHP;
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
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

        StartCoroutine(BossAttackCoroutine());

        if (EnemyHP <= maxEnemyHp / 2)
        {
            speed = 3;
            material.SetFloat("_Flash", 5f);
        }

        if (EnemyHP <= 0)
        {
            transform.position = source;
            StartCoroutine(BossDeathCoroutine());
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

    IEnumerator BossDeathCoroutine()
    {
        animator.ResetTrigger("IsAttacking");
        animator.SetBool("IsDead", true);
        yield return new WaitForSecondsRealtime(4f);
        Destroy(gameObject);
    }

    IEnumerator BossAttackCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            animator.SetTrigger("IsAttacking");
        }
    }

}
