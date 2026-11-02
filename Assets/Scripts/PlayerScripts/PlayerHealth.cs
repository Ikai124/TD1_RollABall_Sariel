using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private bool fall = false;
    private int currentHealth;
    public event Action OnGameOver;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void onRed(int redValue)
    {
        // Pourquoi cette ligne? C’est un garde-fou, sans sa si mon joueur touche une autre dalle avant sa mort le calcule repartirais.
        // En gros, il evite que le GAME OVER se joue plus d'une fois.
        if (fall) return;
        
        // Calcule pour connaitre le vie de mon joueur quand il ce recoit un degats
        // Mathf.Max sers a ne pas descendre en dessous de 0, donc le calcule ne peut pas donner -1
        currentHealth = Mathf.Max(0, currentHealth - redValue);

        // Faire ui des la vie <- A FAIRE
        // Animation de quand il perds l'équilibre <- A FAIRE

        if (currentHealth <= 0)
        {
            fall = true;
            //joue animation de la chute et lance le game over <- A FAIRE
            OnGameOver?.Invoke();
            Debug.Log("FIN DU SPECTACLE");
        }
    }
}
