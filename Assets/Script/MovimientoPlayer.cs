using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float fowardspeed;
    private float horizontalInput;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        //movimiento personaje
        Vector3 fowardmove = transform.forward *fowardspeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position +fowardmove);
        rb.AddRelativeForce(new Vector3(horizontalInput, 0, 0) * speed * Time.deltaTime);
    }
    public void Finish()
    {
        speed = fowardspeed = 0;
    }
}
