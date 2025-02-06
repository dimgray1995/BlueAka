using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 2f;
    public float hAxis;
    public float vAxis;
    public float yAxis;
    public float JumpPower = 1f;

    public float KneelX;
    public float KneelY;
    public float KneelZ;

    bool JDown;
    bool KDowm;

    bool IsJump;
    bool IsKneel;
    //int UserTypeNumber = 0;

    private Quaternion lastRotation;

    Vector3 MoveVec;

    Animator Anim;

    Rigidbody rigid;

    CapsuleCollider Cap;


    void Start()
    {
    
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        Anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        GetInput();
        Trun();
        Jump();
        //Kneel();

        if (!Input.GetKey(KeyCode.Z))
        {
            Move();
            Trun();
        }
        else
        {
            Trun();

            Kneel();
        }
        //Move();
        //UserType();
    }

    //void UserType()
    //{
    //    if (!Input.GetKey(KeyCode.Z))
    //    {
    //      Move();
    //      Trun();
    //    }

    //}

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        JDown = Input.GetButtonDown("Jump");
        KDowm = Input.GetButton("Kneel");

    }

    void Move()
    {
        MoveVec = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += MoveVec * Speed * Time.deltaTime;

        Anim.SetBool("IsWork", MoveVec != Vector3.zero);
        transform.rotation = Quaternion.Euler(hAxis, 0, vAxis);

    }

    void Trun()
    {
        transform.LookAt(transform.position + MoveVec);
    }

    void Kneel()
    {
        if (KDowm)
        {
            Anim.SetTrigger("IsKneel");
            //transform.localRotation = Quaternion.Euler(hAxis, 90, vAxis);
            transform.LookAt(transform.position);
            transform.localPosition = new Vector3(transform.position.x- KneelX, transform.position.y- KneelY, transform.position.z- KneelZ);
            //UserType();
            Cap = GetComponent<CapsuleCollider>();
            Cap.center = new Vector3(0, 0.0045f, 0);
            Cap.height = 0.009f;
        }
        else
        {
            Cap.center = new Vector3(0, 0.005f, 0);
            Cap.height = 0.01f;
        }
    }

    void Jump()
    {
        if (JDown && !IsJump)
        {
            rigid.AddForce(Vector3.up * JumpPower,ForceMode.Impulse);
            Anim.SetTrigger("DoJump");
            transform.localRotation = Quaternion.Euler(hAxis, 90, vAxis); // 로컬 회전 값 유지
            IsJump = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            IsJump = false;
            IsKneel = false;
        }
    }

}
