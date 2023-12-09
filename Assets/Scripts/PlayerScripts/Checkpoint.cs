using System;
using UnityEngine;

namespace PlayerScripts
{
    public class Checkpoint : MonoBehaviour
    {
        [SerializeField] private Transform checkpointTransform;

        private void OnTriggerEnter(Collider other)
        {
            if (other != null && other.gameObject.CompareTag("Player"))
            {
                var p = other.gameObject.GetComponent<PlayerBase>();
                p.SetCheckpoint(checkpointTransform);
            }
        }
    }
}
