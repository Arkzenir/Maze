using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private Transform _lastCheckpoint;

    public void SetCheckpoint(Transform c)
    {
        _lastCheckpoint = c;
    }

    private void ResetPlayerToCheckpoint()
    {
        transform.position = _lastCheckpoint.position;
        transform.rotation = _lastCheckpoint.rotation;
    }
    
    private void OnCollisionStay(Collision other)
    {
        if (other != null && other.gameObject.CompareTag("Obstacle"))
        {
            ResetPlayerToCheckpoint();
        }
    }
}
