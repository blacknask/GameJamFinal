using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    GameObject cameraFPS;
    Quaternion rotacaoOriginalCamera;
    Vector3 moveDirection = Vector3.zero;
    CharacterController controller;
    public float vel;
    float rotacaoX = 0.0f, rotacaoY = 0.0f;
    public AudioSource somPulo;
    private bool onGround;
    private float jumpPressure;
    private float minJump;
    private float maxJumpPressure;
    private Rigidbody rb2d;
    private Transform transf;
    




    void Start()
    {
        transf = GetComponent<Transform>();
        somPulo = GetComponent<AudioSource>();
        transform.tag = "Player";
        cameraFPS = GetComponentInChildren(typeof(Camera)).transform.gameObject;
        rotacaoOriginalCamera = cameraFPS.transform.localRotation;
        controller = GetComponent<CharacterController>();
        onGround = true;
        jumpPressure = 0f;
        minJump = 2f;
        maxJumpPressure = 10f;
        rb2d = GetComponent<Rigidbody>();
        vel = 2f;
        
    
    }

    void Update()
    {
        /*
        if (onGround)
        {
            if (Input.GetButton("Jump"))
            {
                if(jumpPressure < maxJumpPressure)
                {
                    jumpPressure += Time.deltaTime * 10f;
                }
                else
                {
                    jumpPressure = maxJumpPressure;
                }
            }
            else
            {
                if(jumpPressure > 0f)
                {
                    jumpPressure = jumpPressure + minJump;
                    rb2d.velocity = new Vector3(jumpPressure / 10f, jumpPressure, 0f);
                    jumpPressure = 0f;
                    onGround = false;
                }
            }
        }
        */


        Vector3 direcaoFrente = new Vector3(cameraFPS.transform.forward.x, 0, cameraFPS.transform.forward.z);
        Vector3 direcaoLado = new Vector3(cameraFPS.transform.right.x, 0, cameraFPS.transform.right.z);

        direcaoFrente.Normalize();
        direcaoLado.Normalize();

        direcaoFrente = direcaoFrente * Input.GetAxis("Vertical");
        direcaoLado = direcaoLado * Input.GetAxis("Horizontal");

        Vector3 direcFinal = direcaoFrente + direcaoLado;
        if (direcFinal.sqrMagnitude > 1)
        {
            direcFinal.Normalize();
        }
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(direcFinal.x, 0, direcFinal.z);
            moveDirection *= 2.0f;
            
            if (Input.GetButton("Jump"))
            {
                somPulo.Play();
                moveDirection.y = 9.5f;
            }
            
        }
        moveDirection.y -= 20.0f * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        CameraPrimeiraPessoa();

        if(Input.GetKey(KeyCode.LeftShift) && moveDirection.x < 3.0f)
        {
            vel += 1f;
        }
        else
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                vel = 2f;
            }
        }

    }


    void CameraPrimeiraPessoa()
    {
        float velocidadeTimeScale = 1.0f / Time.timeScale;
        rotacaoX += Input.GetAxis("Mouse X") * 2.0f;
        rotacaoY += Input.GetAxis("Mouse Y") * 2.0f;
        rotacaoX = ClampAngleFPS(rotacaoX, -360, 360);
        rotacaoY = ClampAngleFPS(rotacaoY, -80, 80);
        Quaternion xQuaternion = Quaternion.AngleAxis(rotacaoX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotacaoY, -Vector3.right);
        Quaternion rotacFinal = rotacaoOriginalCamera * xQuaternion * yQuaternion;
        cameraFPS.transform.localRotation = Quaternion.Lerp(cameraFPS.transform.localRotation, rotacFinal, Time.deltaTime * 10.0f * velocidadeTimeScale);
    }

    float ClampAngleFPS(float angulo, float min, float max)
    {
        if (angulo < -360F) { angulo += 360F; }
        if (angulo > 360F) { angulo -= 360F; }
        return Mathf.Clamp(angulo, min, max);
    }


    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            onGround = true;
        }
    }
    */



}
