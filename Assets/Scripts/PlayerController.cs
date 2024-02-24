using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed=5;
    [SerializeField] private float _turnSpeed = 360;
    private Vector3 _input;
    void Update(){
        GatherInput();
        Look();
    }
    void FixedUpdate(){
        Move();
    }
    void GatherInput(){
    _input = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
    }
    void Look(){
        if(_input != Vector3.zero){
        var relative = (transform.position + _input.ToIso()) - transform.position;
        var rotation = Quaternion.LookRotation(relative,Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,rotation, _turnSpeed * Time.deltaTime);
        }      
    }
    void Move(){
        _rb.MovePosition(transform.position+(transform.forward*_input.magnitude)*_speed*Time.deltaTime);
    }
}   
