using System.Collections.Generic;

using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private List<Target> targets;
    [SerializeField] private List<WallSpawner> wallSpawners;
    [SerializeField] private LevelManager levelManager;
    private int actualIndex = 0;

    // Cette fonction appel les elements Target qui on etait Destroy
    public void OnTargetDestroyed(Target targetDestroyed)
    {
        if (targets.Contains(targetDestroyed))
        {
            targets.Remove(targetDestroyed);
            if (targets.Count <= 0)
            {
                // VICTOIRE
                levelManager.LoadNewScene();
            } else if (actualIndex < wallSpawners.Count)
            {
                // spawn new wall
                wallSpawners[actualIndex].SpawnNewWall();
            }
        }
    }
}
