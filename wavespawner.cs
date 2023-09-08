using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wavespawner : MonoBehaviour
{
    public Transform enemyPrefab;//敵人欲置檔
    public Transform spawnPoint;//敵人生成位置
    public float timeBetweenWave = 5f;//波數間隔
    public Text waveCountdown;//波次到計時
    private float countdown = 2f;//到計時
    private int waveNumber = 0;
    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown=timeBetweenWave;
        }
        countdown -= Time.deltaTime;

        waveCountdown.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        for(int i=0;i<waveNumber;i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
