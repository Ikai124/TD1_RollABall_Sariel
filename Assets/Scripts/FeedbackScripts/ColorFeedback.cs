using System.Collections;
using UnityEngine;

public class ColorFeedback : MonoBehaviour
{
    [SerializeField] private Material newMaterial;
    //private float timer;
    //private bool isHighlight;
    private Material baseMaterial;
    [SerializeField] private float duration;

    private void Start()
    {
        baseMaterial = GetComponent<MeshRenderer>().material;
    }

    // == Remplacer par la Coroutine  car moin long ==

    //private void FixedUpdate()
    //{
        // Quand isHighLight ALORS change le material
        //if (isHighlight)
        //{
            //timer = timer + Time.fixedDeltaTime;

            //if (timer >= duration)
            //{
                //timer = 0;
                //isHighlight = false;
                //ChangeMaterial(baseMaterial);
            //}
        //}
    //}

    // Coroutine = delay | 
    IEnumerator TempoCoroutine()
    {
        ChangeMaterial(newMaterial);
        // blabla dans les (durer prevus)
        yield return new WaitForSeconds(duration);
        ChangeMaterial(baseMaterial);
    }

    public void ChangeMaterial(Material newMat)
    {
        GetComponent<MeshRenderer>().material = newMat;
    }

    public void StarHighLight()
    {
        StartCoroutine(TempoCoroutine());
        //ChangeMaterial (newMaterial)
        //isHighlight = true
    }
}
