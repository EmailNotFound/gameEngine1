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
    int spawnCounter = 1;

    public Player CurrentPlayer;
    public Player player;

    void Start()
    {
        StartCoroutine(SpawnEnemyCoroutine());
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
                //yield return new WaitForSeconds(10f);
                //SpawnEnemy(Merman, 3);
                //SpawnEnemy(Zombie, 3);
                //SpawnEnemy(Patient, 4);
                //yield return new WaitForSeconds(15f);
                //SpawnEnemy(Merman, 4);
                //SpawnEnemy(Zombie, 3);
                //SpawnEnemy(Patient, 4);
                //yield return new WaitForSeconds(20f);
                //SpawnEnemy(Merman, 2);
                //SpawnEnemy(Zombie, 2);
                //SpawnEnemy(Patient, 3);
                //SpawnEnemy(Skeleton, 1);
                //yield return new WaitForSeconds(5f);
            }
        }
    }

    private void SpawnEnemy(GameObject enemyPrefab, int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 spawnPosition = Random.insideUnitCircle.normalized * 9;
            spawnPosition += player.transform.position;

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
