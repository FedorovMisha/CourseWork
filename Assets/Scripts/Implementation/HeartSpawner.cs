using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HeartSpawner : MonoBehaviour
{
    public static int Count { get; set; } = 0;
    [SerializeField] private List<Vector3> spawnPoints = new List<Vector3>();
    private int maxHearts = 1;
    [SerializeField]private List<GameObject> heartsMap = new List<GameObject>();
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private float duration = 1f;
    private int _current = 0;
    [SerializeField] private float delta = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        maxHearts = spawnPoints.Count == 1? 1: Mathf.FloorToInt(spawnPoints.Count / 2);
        Debug.Log(maxHearts);
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            heartsMap.Add(null);
        }

        StartCoroutine(Spawn());
    }
    
    IEnumerator Spawn()
    {
        while (true)
        {

            yield return new WaitForSeconds(duration);
            if (Count < maxHearts)
            {
                var spawnPoint = Random.Range(0, spawnPoints.Count);
                while (heartsMap[spawnPoint] != null)
                {
                    spawnPoint = Random.Range(0, spawnPoints.Count);
                }

                heartsMap[spawnPoint] = Instantiate(heartPrefab);

                heartsMap[spawnPoint].transform.position = spawnPoints[spawnPoint];
                Count++;
                yield return new WaitForSeconds(duration * 10f);
            }
        }

    }
}
