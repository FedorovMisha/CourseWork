using System.Collections;
using UnityEditorInternal;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private int maxBombCount = 10;

    [SerializeField] private float minX = -10f;

    [SerializeField] private float maxX = -10f;

    [SerializeField] private float duration = 1f;

    [SerializeField] private GameObject prefab;

    [SerializeField] private float yPosition = 10f;
    public static int BombsCount { get; set; }

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SpawnBomb());
    }


    private IEnumerator SpawnBomb()
    {
        while (true)
        {
            yield return new WaitForSeconds(duration);
            if (BombsCount < maxBombCount)
            {
                BombsCount++;
                var bomb = Instantiate(prefab);
                bomb.transform.position = new Vector3(Random.Range(minX, maxX), yPosition, 2f);
            }
        }
    }
}