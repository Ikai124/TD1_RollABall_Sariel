using System;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    // Variables
    private Rigidbody rb;
    private float HorizontalVelocity = 0f;
    private float VerticalVelocity = 0f;
    [SerializeField] private float speed = 2f;

    // Recupère la variable au lancements
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // == Déplacement ===
    void Update()
    {

        // RIGHT + LEFT
        if (Input.GetKey(KeyCode.RightArrow))
        {
            HorizontalVelocity = 1f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            HorizontalVelocity = -1f;
        }
        else
        {
            HorizontalVelocity = 0f;
        }

        // UP + DOWN
        if (Input.GetKey(KeyCode.UpArrow))
        {
            VerticalVelocity = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            VerticalVelocity = -1f;
        }
        else
        {
            VerticalVelocity = 0f;
        }

        rb.linearVelocity = new Vector3(HorizontalVelocity * speed, rb.linearVelocity.y, VerticalVelocity * speed);
    }
}
