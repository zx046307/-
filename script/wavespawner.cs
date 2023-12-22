using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wavespawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;//怪物存活數
    public static int WaveCount;
    public Transform[] enemyPrefab;//敵人預置檔
    public Transform spawnPoint;//敵人生成位置
    public float timeBetweenWave = 5f;//波數間隔
    public Text waveCountdown;//波次到計時
    public Text waveNumberCount;//波次累加
    public int enemyTest;
    private float countdown = 2f;//到計時
    private int waveNumber = 0;//波數
    int reset=0;//初始重製
    void Update()
    {
        WaveCount=waveNumber;
        if (EnemiesAlive>0)//還有怪物存活
        {
            return;
        }
        if(reset==0)//初始重製血量
        {
            enemyPrefab[0].GetComponent<Enemy>().reset(100);
            enemyPrefab[1].GetComponent<Enemy>().reset(200);
            reset=1;
        }
        if(countdown <= 0f)//到計時生怪
        {
            StartCoroutine(SpawnWave());
            countdown=timeBetweenWave;
        }
        countdown -= Time.deltaTime;

        waveCountdown.text = Mathf.Round(countdown).ToString();
        waveNumberCount.text = waveNumber.ToString();
    }

    IEnumerator SpawnWave()//生怪機制
    {
        waveNumber++;
        int count=0;
        count=waveNumber/3;
        int n=5;
        n+=count;
        EnemiesAlive=n;
        for(int i=0;i<n;i++)
        {
            int enemy = i%5;
            SpawnEnemy(i,enemy);
            yield return new WaitForSeconds(1f);
        }
        enemyPrefab[0].GetComponent<Enemy>().nextWave();
        enemyPrefab[1].GetComponent<Enemy>().nextWave();
    }
    void SpawnEnemy(int index,int enemy)//怪物生成和生成位置
    {
        Instantiate(enemyPrefab[enemy], spawnPoint.position, spawnPoint.rotation);
    }
}
