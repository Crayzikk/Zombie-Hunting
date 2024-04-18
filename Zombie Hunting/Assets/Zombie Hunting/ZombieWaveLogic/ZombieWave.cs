using UnityEngine;

public class ZombieWave : MonoCache
{
    [SerializeField] private Transform[] pointSpawn;
    [SerializeField] private GameObject prefabBaseZombie;
    [SerializeField] private GameObject prefabRunnerZombie;
    [SerializeField] private GameObject prefabStoneZombie;
    [SerializeField] private GameObject prefabShooterZombie;

    private Timer timer;
    private int numberOfPointSpawn;
    private int[] numberOfSpawnEnemy;
    private bool flagCounter = false;

    private int countInWaveBaseZombie;
    private int countInWaveRunnerZombie;
    private int countInWaveStoneZombie;
    private int countInWaveShooterZombie;

    public static bool startWave = false;
    public static bool waveActive = false;
    public static int numberOfEnemy = 6;
    public static int currentWave = 0;
    
    private void Start() 
    {
        timer = new Timer(4f, true);
        numberOfPointSpawn = pointSpawn.Length;
        numberOfSpawnEnemy = new int[] {numberOfEnemy, 0, 0, 0};
    }

    public override void OnTick()
    {
        if(waveActive)
        {
            if(startWave)
            {
                countInWaveBaseZombie = numberOfSpawnEnemy[0];
                countInWaveRunnerZombie = numberOfSpawnEnemy[1];
                countInWaveStoneZombie = numberOfSpawnEnemy[2];
                countInWaveShooterZombie = numberOfSpawnEnemy[3];

                startWave = false;
            }

            if(!flagCounter)
            {
                currentWave++;
                flagCounter = true;
            }

            timer.RunTimer(SpawnZombie);
        }
    }

    private void SpawnZombie()
    {    
        if(numberOfEnemy > 0)
        {
            SpawnZombieInScene(prefabBaseZombie, ref countInWaveBaseZombie);
            SpawnZombieInScene(prefabRunnerZombie, ref countInWaveRunnerZombie);
            SpawnZombieInScene(prefabStoneZombie, ref countInWaveStoneZombie);
            SpawnZombieInScene(prefabShooterZombie, ref countInWaveShooterZombie);
        }
        else
        {
            flagCounter = false;
            waveActive = false;
            ZombieWaveUp();
            EndPlayWave.endWave = true;
        }
    }

    private void SpawnZombieInScene(GameObject prefab, ref int spawnCount)
    {
        if(spawnCount > 0)
        {
            int pointIndex = Random.Range(0, numberOfPointSpawn - 1);
            GameObject zombie = Instantiate(prefab, pointSpawn[pointIndex].position, Quaternion.identity);    
            spawnCount--;        
        }
    }

    private void ZombieWaveUp()
    {
        if(currentWave < 2)
        {
            numberOfSpawnEnemy[1]++;
        }
        else if(currentWave >= 2 && currentWave < 3)
        {
            numberOfSpawnEnemy[2]++;
        }
        else
        {
            for (int index = 0; index < numberOfSpawnEnemy.Length; index++)
            {
                numberOfSpawnEnemy[index]++;
            }
        }

        for (int index = 0; index < numberOfSpawnEnemy.Length; index++)
        {
            numberOfEnemy += numberOfSpawnEnemy[index];
        }
    }

}
