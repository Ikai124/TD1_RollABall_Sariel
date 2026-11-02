using Unity.VisualScripting;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{

    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawnPosition;


    public void SpawnNewWall()
    {
        Debug.Log("Try spawn");
        Instantiate(prefab, spawnPosition);
        Debug.Log("Ok");
    }
}
