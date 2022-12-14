using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Merman;
    [SerializeField] GameObject Zombie;
    [SerializeField] GameObject Patient;
    [SerializeField] GameObject Skeleton;
    [SerializeField] TMP_Text timerText;
    [SerializeField] GameObject background1;
    [SerializeField] GameObject background2;

    
    public Player CurrentPlayer;
    public Player player;
    private bool Levelchange;

    void Start()
    {
        IEnumerator co = SpawnEnemyCoroutine();
        StartCoroutine(co);
        Levelchange = true;
    }

    private static GameManager instance;
    public static GameManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }


    private void Update()
    {
        int seconds = (int)Time.time;
        int minutes = 00;
        while (seconds >= 60)
        {
            minutes++;
            seconds -= 60;
        }
        if (seconds <= 9)
        {
            timerText.text = "0" + minutes.ToString() + ":0" + seconds.ToString();
        }
        else
        {
            timerText.text = "0" + minutes.ToString() + ":" + seconds.ToString();
        }
        
        if (player == null)
        {
            SceneManager.LoadScene("Death");
        }

        if(minutes == 0 && seconds == 10 && Levelchange is true)
        {
            IEnumerator co = SpawnEnemyCoroutine();
            StopCoroutine(co);
            
            var objects = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject obj in objects)
            {
                Destroy(obj);
            }
            var objects2 = GameObject.FindGameObjectsWithTag("Drops");
            foreach (GameObject obj in objects2)
            {
                Destroy(obj);
            }
            var objects3 = GameObject.FindGameObjectsWithTag("Projectiles");
            foreach (GameObject obj in objects3)
            {
                Destroy(obj);
            }

            background1.SetActive(false);
            background2.SetActive(true);
            StartCoroutine(SpawnEnemyCoroutine2());
            Levelchange = false;
        }

    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        if (player != null)
        {
            while (true)
            {
                SpawnEnemy(Merman, 1);
                SpawnEnemy(Zombie, 1);
                SpawnEnemy(Patient, 1);
                yield return new WaitForSeconds(5f);
                SpawnEnemy(Merman, 2);
                SpawnEnemy(Zombie, 1);
                SpawnEnemy(Patient, 2);            
                SpawnEnemy(Skeleton, 1);
                yield return new WaitForSeconds(5f);
                SpawnEnemy(Merman, 2);
                SpawnEnemy(Zombie, 3);
                SpawnEnemy(Patient, 2);
                yield return new WaitForSeconds(10f);
                SpawnEnemy(Merman, 3);
                SpawnEnemy(Zombie, 3);
                SpawnEnemy(Patient, 3);
            }
        }
    }

    private IEnumerator SpawnEnemyCoroutine2()
    {
        if (player != null)
        {
            while (true)
            {
                SpawnEnemy(Merman, 2);
                SpawnEnemy(Zombie, 2);
                SpawnEnemy(Patient,2);
                yield return new WaitForSeconds(5f);
                SpawnEnemy(Merman, 2);
                SpawnEnemy(Zombie, 3);
                SpawnEnemy(Patient, 2);
                yield return new WaitForSeconds(10f);
                SpawnEnemy(Merman, 2);
                SpawnEnemy(Zombie, 1);
                SpawnEnemy(Patient, 2);
                SpawnEnemy(Skeleton, 1);
            }
        }
    }

    public void SpawnEnemy(GameObject enemyPrefab, int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 spawnPosition = Random.insideUnitCircle.normalized * 9;
            spawnPosition += player.transform.position;            

            if(enemyPrefab == Merman)
            {
                var enPrefab = PoolManager.GetInstance().Mermanpool.Get();
                enPrefab.transform.position = spawnPosition;
                enPrefab.transform.rotation = Quaternion.identity;
                enPrefab.SetActive(true);
            }
            else if(enemyPrefab == Zombie)
            {
                var enPrefab = PoolManager.GetInstance().Zombiepool.Get();
                enPrefab.transform.position = spawnPosition;
                enPrefab.transform.rotation = Quaternion.identity;
                enPrefab.SetActive(true);
            }
            else if(enemyPrefab == Patient)
            {
                var enPrefab = PoolManager.GetInstance().Patientpool.Get();
                enPrefab.transform.position = spawnPosition;
                enPrefab.transform.rotation = Quaternion.identity;
                enPrefab.SetActive(true);
            }
            else if(enemyPrefab == Skeleton)
            {
                var enPrefab = PoolManager.GetInstance().Bosspool.Get();
                enPrefab.transform.position = spawnPosition;
                enPrefab.transform.rotation = Quaternion.identity;
                enPrefab.SetActive(true);
            }
        }
    }
}
