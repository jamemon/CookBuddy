using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ChikenSpawner : MonoBehaviour
{
    public GameObject chicken;
    public Transform[] spawnPoints;

    [SerializeField] Clock clock;

    public float minDelay = .1f;
    public float maxDelay = 1f;
    private bool isSpawn = true;
    private bool isRunning = false;
    // Start is called before the first frame update

    private void Awake()
    {

        StartCoroutine(SpawnChicken());
       
    }
    public IEnumerator SpawnChicken()
    {
        while (!clock.getGameEnd())
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            GameObject chickenTemp = Instantiate(chicken, spawnPoint.position, spawnPoint.rotation);
            Destroy(chickenTemp,3f);

        }
         isRunning = false;
    }
}
