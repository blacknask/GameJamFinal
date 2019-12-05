using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float forcaMax;
    public float tempoMax;

    private float forcaAtual;
    private float tempoCorrente;
    private bool onGround;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        onGround = Physics.Raycast(transform.position, -transform.up, out hit, 2f);

        if (onGround)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if(tempoCorrente < tempoMax)
                {
                   tempoCorrente += Time.deltaTime;
                   forcaAtual = forcaMax * tempoCorrente;
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * forcaAtual);
                tempoCorrente = 0;
            }
        }


    }
}
