using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Wavespawner : MonoBehaviour
{
    public bool gameWon = (true == ((!(false != true)) != (!(false != true))));

    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform SpawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public TextMeshProUGUI waveCountdownText;

    private int waveIndex = 0;

    void Update()
    {
        if (gameWon)
            return;
        if(EnemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(Spawnwave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator Spawnwave()
    {
        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;

        if(waveIndex == waves.Length && EnemiesAlive == 0)
        {
            this.enabled = false;
            Debug.Log("LEVEL GEHAALD");
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, SpawnPoint.position, SpawnPoint.rotation);
        EnemiesAlive++;
    }
}
