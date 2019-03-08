using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dampScript : MonoBehaviour
{
    float damp = 0.01f;
    Rigidbody2D rb;

    void Start() { rb = GetComponent<Rigidbody2D>(); }

    //void FixedUpdate() { rb.velocity.y *= (1 - damp); }
}
