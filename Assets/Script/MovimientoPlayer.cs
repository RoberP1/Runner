using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private float horizontalInput;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        //movimiento personaje
        rb.AddRelativeForce(new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime);
    }
}
