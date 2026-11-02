using UnityEngine;

public class SlabsAnim : MonoBehaviour
{
    // Le script est attaché au prefab Slab
    private Animator animator;
    public SlabsColors CurrentColor;
    [SerializeField] private BoxCollider colorCollider;

    // Awake permet juste de lancer les instructions avant tous le reste.
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        colorCollider.enabled = false;
    }

    // Avec enum je peux remplacer mes integers par des strings (ce qui est plus lisible)
    public enum SlabsColors
    {
        // avec enum : 0 = Cyan | 1 = Green | 2 = Yellow | 3 = Red
        Cyan,
        Green,
        Yellow,
        Red
    }

    // SetColor permet de dire le couleur de la dalle
    public void SetColor(SlabsColors ColorIs)
    {
        animator.SetInteger("ColorTurn", (int)ColorIs);
        CurrentColor = ColorIs;
        animator.SetBool("ColorFixed", false);
        colorCollider.enabled = false;
    }

    // FixColor permet de fixer la couleur aprer cyanTo
    public void FixColor()
    {
        if (CurrentColor != SlabsColors.Cyan)
        {
            animator.SetBool("ColorFixed", true);
            colorCollider.enabled = true;
        }
    }
}
