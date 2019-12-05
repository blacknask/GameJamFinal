using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    public float moveSpeed = 20.0f;
    private Vector3 pos;
    private Rigidbody rb;
    float x, y;
    [SerializeField] float velocidadeRotacao;
    [SerializeField] float velocidade;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        y = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, y);
    }
}
