using System.Collections.Generic;
using UnityEngine;
using static SlabsAnim;

public class SlabsColorsSwitch : MonoBehaviour
{
    // Le script est attaché à GameMode_Infini
    public SlabsAnim[] AllSlabs;

    [SerializeField] private int greenNumber = 12;
    [SerializeField] private int yellowNumber = 3;
    [SerializeField] private int redNumber = 10;

    List<SlabsColors> colorList = new List<SlabsColors>();

    // OnEnable sert a dire quand l'une des var est activer et OnDisable fait l'inverse
    // Ici il serve a dire quand les timers commence ou se finisse
    void OnEnable()
    {
        SlabsTimer.CyanTimerStart += changeSlabsColors;
        SlabsTimer.ReturnToCyanTimerEnd += changeSlabsToCyan;
        SlabsTimer.CyanToTimerEnd += fixeColors;
    }

    void OnDisable()
    {
        SlabsTimer.CyanTimerStart -= changeSlabsColors;
        SlabsTimer.ReturnToCyanTimerEnd -= changeSlabsToCyan;
        SlabsTimer.CyanToTimerEnd -= fixeColors;
    }

    void changeSlabsColors()
    {
        // Clear va eviter que le list se répéte.
        colorList.Clear();

        for(int i = 0; i < greenNumber; i++)
        {
            colorList.Add(SlabsColors.Green);
        }

        for(int i = 0; i < yellowNumber; i++)
        {
            colorList.Add(SlabsColors.Yellow);
        }

        for(int i = 0; i < redNumber; i++)
        {
            colorList.Add(SlabsColors.Red);
        }

        if(colorList.Count != AllSlabs.Length) 
        {
            return;
        }

        // Mélange Fisher-Yates... i = eau et j = jus donc temp = vide... | se melange permet l'aleatoire des changement de couleur des dalles.
        for (int i = colorList.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            SlabsColors temp = colorList[i]; // temps recoit eau (colorList[i] a toujour l'eau)
            colorList[i] = colorList[j]; // eau recoit jus (colorList[i] a mtn du jus)
            colorList[j] = temp; // jus recoit temp (colorList[j] a mtn de l'eau)
        }

        // Logique du changement de couleurs aleatoire avec le resultas de Fisher-Yates
        for(int i = 0; i < AllSlabs.Length; i++)
        {
            AllSlabs[i].SetColor(colorList[i]);
        }
    }

    void changeSlabsToCyan()
    {
        // Permet le retour en Cyan car a la fin de returnToCyan passe ColorTurn a 0 pour toutes les dalles.
        foreach(SlabsAnim slab in AllSlabs)
        {
            slab.SetColor(SlabsColors.Cyan);
        }
    }

    void fixeColors()
    {
        // Fixe les couleurs quand cyanTo est fini
        foreach (SlabsAnim slab in AllSlabs)
        {
            slab.FixColor();
        }
    }
}
