using System;
using UnityEngine;

public class SlabsTimer : MonoBehaviour
{
    // Le script est attaché à GameMode_Infini dans la hierarchy
    // FLOAT pas INT sinon le deltatime ne se lis pas 
    [SerializeField] private float cyanTo = 4;
    [SerializeField] private float returnToCyan = 6;
    [SerializeField] private float cyanToTimer = 4;
    [SerializeField] private float returnToCyanTimer = 6;
    [SerializeField] private int round = 1;
    [SerializeField] private int roundBoss = 5;
    private bool canInvokeCyanToEnd = true;
    private bool roundStart = false;
    private bool gameStart = false;
    private bool invokeSwitch = true;

    public static event Action ReadyTimerEnd;

    public delegate void CyanToStart();
    public static event CyanToStart CyanTimerStart;

    public delegate void ReturnToCyanEnd();
    public static event ReturnToCyanEnd ReturnToCyanTimerEnd;

    public delegate void CyanToEnd();
    public static event CyanToEnd CyanToTimerEnd;

    private void OnEnable()
    {
        ReadyTimer.ReadyTimerEnd += GameStart;
    }
    private void OnDisable()
    {
        ReadyTimer.ReadyTimerEnd -= GameStart;
    }

    public void GameStart()
    {
        gameStart = true;
    }

    private void Update()
    {
        if (gameStart)
        {
            // SI round inferieur a 5 alors lance CyanToPlay
            if (roundStart)
            {
                if (round < roundBoss)
                {

                    // SI cyanToTimer et superieur a 0 ALORS lance cyanToTimer
                    if (cyanToTimer > 0)
                    {
                        cyanToTimer -= Time.deltaTime;

                        if (invokeSwitch)
                        {
                            CyanTimerStart?.Invoke();
                            invokeSwitch = false;
                        }
                    }

                    // SI cyanToTimer est fini ALORS lance returnToCyanTimer
                    if (cyanToTimer <= 0)
                    {
                        returnToCyanTimer -= Time.deltaTime;

                        // SI canInvokeCyanEnd est vrais alors envois a SlabsColorsSwitch.cs l'information que CyanToTimer est fini
                        if (canInvokeCyanToEnd == true)
                        {
                            CyanToTimerEnd?.Invoke();
                            canInvokeCyanToEnd = false;
                        }

                        // SI returnToCyan est fini ALORS reset la manche et rajoute un round
                        if (returnToCyanTimer <= 0)
                        {
                            ReturnToCyanTimerEnd?.Invoke();
                            roundStart = false;
                            invokeSwitch = true; // tu la déplacer ici
                            canInvokeCyanToEnd = true;
                            round += 1;
                        }
                    }
                }

                // Pas eu le temps de rajouter le boss :/
                if (round == roundBoss)
                {
                    //roundStart = false;
                    round = 0; // temps que le boss n'est pas la le jeu ne se termine pas !
                }
            }

            // SI il n'est pas encore l'heure du boss ALORS rejoue un tour
            if (round < roundBoss)
            {
                if (roundStart == false)
                {
                    cyanToTimer = cyanTo;
                    returnToCyanTimer = returnToCyan;
                    roundStart = true;
                }
            }
        }       
    }
}

