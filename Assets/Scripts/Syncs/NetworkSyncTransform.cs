using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkSyncTransform : NetworkBehaviour
{
    #region Variables
    public float lerpRate = 15;
    public float positionThreshold = 0.5f;
    public float rotationThreshold = 0.5f;

    [SyncVar] private Vector3 syncPosition;
    [SyncVar] private Quaternion syncRotaion;
    private Vector3 lastPosition;
    private Quaternion lastrotation;
    #endregion
    
    // Use this for initialization
    #region Manual Function
    void LerpPosition()
    {
        transform.position = Vector3.Lerp(transform.position, syncPosition, Time.deltaTime * lerpRate);
    }

    void LerpRotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, syncRotaion, Time.deltaTime * lerpRate);
    }
    [Command]
    void CmdSendPositiontoServer(Vector3 _position)
    {
        syncPosition = _position;
    }
    [Command]
    void CmdSendRotationToServer(Quaternion _rotation)
    {
        syncRotaion = _rotation;
    }
    [ClientCallback]
    void TransmitPosition()
    {
        if (Vector3.Distance(transform.position, lastPosition) > positionThreshold)
        {
            CmdSendPositiontoServer(transform.position);
            lastPosition = transform.position;
        }
    }
    [ClientCallback]
    void TransmitRotation()
    {
        if (Quaternion.Angle(transform.rotation, lastrotation) > rotationThreshold)
        {
            CmdSendRotationToServer(transform.rotation);
            lastrotation = transform.rotation;
        }
    }

    #endregion
       
    void FixedUpdate()
    {
        TransmitPosition();
        LerpPosition();
        TransmitRotation();
        LerpRotation();
    }
}
