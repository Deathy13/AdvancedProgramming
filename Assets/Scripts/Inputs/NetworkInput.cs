using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkInput : NetworkBehaviour
{
    public Player controller;
    public Orbit cam;
    // Use this for initialization

    private void Start()
    {
        if(!isLocalPlayer)
        {
            cam.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            cam.Look(mouseX, mouseY);
            float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");
            bool isJumping = Input.GetButton("Jump");
            controller.Move(inputH, inputV, isJumping);
        }
        
    }
}
