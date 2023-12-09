using System;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerBase : MonoBehaviour
    {
        private Transform _lastCheckpoint;
        public bool GameOver { get; private set; }
        public void SetCheckpoint(Transform c)
        {
            _lastCheckpoint = c;
        }

        private void ResetPlayerToCheckpoint()
        {
            ResetPlayerPosition();
        }

        private void ResetPlayerPosition()
        {
            transform.position = _lastCheckpoint.position;
            transform.rotation = _lastCheckpoint.rotation;
        }
    
        private void OnTriggerEnter(Collider other)
        {
            if (other != null)
            {
                if (other.gameObject.CompareTag("Obstacle"))
                {
                    ResetPlayerToCheckpoint();
                    return;
                }
                if (other.gameObject.CompareTag("Finish"))
                {
                    GameOver = true;
                }
            }
        }
    }
}
