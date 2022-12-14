using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    public float maxplayerHP = 10;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] PlayerCamera playerCamera;

    Animator animator;
    Material material;


    public float playerHP;
    bool isInvincible;

    internal int curExp;
    internal int Exptolvl = 5;
    internal int curlvl;

    private void Start()
    {
        
        playerHP = maxplayerHP;
        animator = GetComponent<Animator>();
        material = spriteRenderer.material;
    }

    public bool Ondamage(int damage)
    {
        if (!isInvincible)
        {
            playerHP -= damage;                       
            StartCoroutine(InvisibleCoroutine());
            
            return true;
        }
        return false;
    }

    IEnumerator InvisibleCoroutine()
    {
        isInvincible = true;
        //spriteRenderer.color = Color.red;
        material.SetFloat("_Flash", 0.5f);
        yield return new WaitForSeconds(1f);
        //spriteRenderer.color = Color.white;
        material.SetFloat("_Flash", 0);
        isInvincible = false;

    }


    public void Addexp()
    {
        curExp += 1;
        if (curExp >= Exptolvl)
        {
            curExp = 0;
            curlvl++;
            Exptolvl += 3;
            maxplayerHP += 2;
            playerHP += 3;
        }
    }


    public void Addhp(float percentage)
    {
        playerHP += percentage * maxplayerHP;        
    }

    public float GetHpRatio()
    {
        return (float)playerHP / maxplayerHP;
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        transform.position += new Vector3(inputX, inputY) * speed * Time.deltaTime;


        if (inputX != 0)
        {
            transform.localScale = new Vector3(inputX > 0 ? -1 : 1, 1, 1);
        }

        animator.SetBool("IsRunning", inputX != 0 || inputY != 0);
    }

    internal void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerHP <= 0)
        {
            Destroy(gameObject);
            TitleManager.saveData.deathCount++;            
        }
    }
}
