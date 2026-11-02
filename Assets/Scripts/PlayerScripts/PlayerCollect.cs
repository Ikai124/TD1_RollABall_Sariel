using UnityEngine;
using static SlabsAnim;

public class PlayerCollect : MonoBehaviour
{
    // Le script est attaché à Player dans la Hierchy... logique...

    [SerializeField] private ScoreDatas scoreData;
    [SerializeField] private UIController uiControler;
    [SerializeField] private SpawnController spawnController;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private int greenValue = 10;
    [SerializeField] private int yellowValue = 50;
    [SerializeField] private int redValue = 1;


    // Quand le joueur touche rentre dans la collision ALORS l'objet ce detruit.
    private void OnTriggerEnter(Collider other)
    {        
        SlabsAnim slabTarget = other.GetComponentInParent<SlabsAnim>();

        if (slabTarget)
        {
            // Donne au score la valeur de la couleur toucher grasse a switch qui empecher les 3 valeurs de se donner en meme temps.
            // Fonctionnement de Switch : Case = Valeur1: / instruction; / break;
            switch (slabTarget.CurrentColor)
            {
                case SlabsColors.Green:
                    scoreData.Score = scoreData.Score + greenValue;
                break;

                case SlabsColors.Yellow:
                    scoreData.Score = scoreData.Score + yellowValue;
                break;

                case SlabsColors.Red:
                    playerHealth.onRed(redValue);
                break;
            }

            slabTarget.SetColor(SlabsColors.Cyan);

            uiControler.UpdateScoreText(scoreData.Score);
            //GetComponent<AudioSource>().clip = honkSound; <- changer l'audio et remetre le [SerializeField] pour qu'il se lise.
        }
    }
}