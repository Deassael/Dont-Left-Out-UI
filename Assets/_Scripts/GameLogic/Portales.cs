using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portales : MonoBehaviour
{
    [SerializeField] private bool teleportOnX;
    [SerializeField] private bool teleportOnZ;
    [SerializeField, Range(2,10)] private float teleportOffset;
    
    [SerializeField] private GameObject otherPortal;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportBoat(other);
        }
        
    }

    private void TeleportBoat(Collider boat)
    {
        Vector3 playerFromPortal = transform.InverseTransformPoint(boat.transform.position);
        if (playerFromPortal.z <= 0.02)
        {
            if (teleportOnZ && !teleportOnX)
            {
                boat.transform.position = new Vector3(boat.transform.position.x, boat.transform.position.y,
                    otherPortal.transform.position.z + (boat.transform.position.normalized.z * teleportOffset));
            }
            if (teleportOnX && !teleportOnZ)
            {
                boat.transform.position = new Vector3(otherPortal.transform.position.x + (boat.transform.position.normalized.x * teleportOffset), boat.transform.position.y,
                    boat.transform.position.z);
            }
        }
    }
}
