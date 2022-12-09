using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSword : MonoBehaviour
{
    [SerializeField] Transform rotationCenter;
    [SerializeField] float rotationRadius = 5f;
    [SerializeField] float rotationSpeed = 2f;

    float posX, posY, angle = 0f;

    private void Update()
    {
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
        transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * rotationSpeed;

        gameObject.transform.Rotate(0f, 0f, 10f * Time.deltaTime * 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.Damage(2);
        }
        Boss boss = collision.gameObject.GetComponent<Boss>();
        if (boss)
        {
            boss.Damage(4);
        }
    }

}
