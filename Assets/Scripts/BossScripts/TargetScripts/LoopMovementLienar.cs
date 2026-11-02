using UnityEngine;

public class LoopMovementLienar : MonoBehaviour
{
    // Les [] aprèes le Transform serve a dire de qu'elle type est le tableau. on peut le remplacer par bool, int, float...
    [SerializeField] private Transform[] spawnPointArray;
    [SerializeField] private float speed;
    [SerializeField] private float timer;
    private int originIndex = 0;
    private int endIndex = 1;
    private float actualDistance;
    private float maxDistance;
    private float distancePercentage;

    private void Start()
    {
        // La max distance est la distance entre la position 1 et 2.
        maxDistance = Vector3.Distance(spawnPointArray[0].position, spawnPointArray[1].position);
    }

    private void FixedUpdate()
    {
        // Caclule en mode Kilometre par heure.
        timer = timer + Time.fixedDeltaTime;
        actualDistance = actualDistance + timer * speed;
        distancePercentage = actualDistance / maxDistance;
        // Lerp = interpollation linère, Ce qui me permet de partire d'une position d'oringe jusqu'a l'autre.
        transform.position = Vector3.Lerp(spawnPointArray[originIndex].position, spawnPointArray[endIndex].position, distancePercentage);

        if (actualDistance >= maxDistance)
        {
            timer = 0;
            actualDistance = 0;
            if (originIndex == 0)
            {
                originIndex = 1;
                endIndex = 0;
            } else
            {
                originIndex = 0;
                endIndex = 1;
            }
        }

    }
}
