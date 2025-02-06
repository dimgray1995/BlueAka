using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetC : MonoBehaviour
{
    public float Speed;
    public float HaloX;
    public float HaloY;
    public float HaloZ;
    public Transform target;

    void Start()
    {
        
    }

    void Update()
    {
        //transform.position = new Vector3(target.position.x, target.position.y+Hi, target.position.z);
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * Speed);
        transform.position = new Vector3(target.position.x+ HaloX, target.position.y + HaloY, target.position.z+ HaloZ);

    }
}
