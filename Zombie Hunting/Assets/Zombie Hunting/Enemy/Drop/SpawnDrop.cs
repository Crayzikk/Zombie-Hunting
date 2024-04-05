using UnityEngine;

public class SpawnDrop : MonoBehaviour
{
    [SerializeField] private GameObject prefabCoin;
    [SerializeField] private int numberOfSpawns;

    private float sphereRange = 2f;

    public void SpawnsDrop()
    {
        for (int drop = 0; drop < numberOfSpawns; drop++)
        {
            Vector3 endSpawnPosition = transform.position + Random.insideUnitSphere * sphereRange;

            GameObject coin = Instantiate(prefabCoin, transform.position, Quaternion.identity);

            coin.GetComponent<DropMovement>().targetPositionDeathDrop = endSpawnPosition;
        }
    }
}
