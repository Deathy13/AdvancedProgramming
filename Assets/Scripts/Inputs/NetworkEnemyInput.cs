using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkEnemyInput : NetworkBehaviour
{
    public Enemy enemy;
    
    // Use this for initialization
    void Start()
    {
        //Declaration|<------Definition--------->|
        enemy = GetComponent<Enemy>();

        enemy.onAlert.AddListener(SendAlert);
    }

    // Update is called once per frame
    void Update()
    {
        if (isClient)
        {
            enemy.Move();
        }
    }
    
    [Command]
    void CmdTransmitAlert()
    {
        enemy.ActivateAlert();
    }
    
    [ClientCallback]
    void SendAlert()
    {
        CmdTransmitAlert();
    }
}
