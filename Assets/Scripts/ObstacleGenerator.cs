using System.Collections;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Arreglo de prefabs de obstáculos
    public float[] spawnTimes; // Arreglo de tiempos de generación
    public bool[] spawnPointsToggle; // Arreglo de booleanos para elegir el punto de generación
    public Transform spawnPoint1; // Primer punto de generación
    public Transform spawnPoint2; // Segundo punto de generación

    void Start()
    {
        for (int i = 0; i < obstaclePrefabs.Length; i++)
        {
            StartCoroutine(SpawnObstacle(i));
        }
    }

    IEnumerator SpawnObstacle(int index)
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTimes[index]);
            Transform spawnPoint = spawnPointsToggle[index] ? spawnPoint1 : spawnPoint2;
            GameObject obstacle = Instantiate(obstaclePrefabs[index], spawnPoint.position, Quaternion.identity);
            Obstacle obstacleScript = obstacle.GetComponent<Obstacle>();
            if (obstacleScript != null)
            {
                obstacleScript.moveUp = spawnPointsToggle[index];
            }
        }
    }
}
