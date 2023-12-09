using System;
using PlayerScripts;
using UnityEditor;
using UnityEngine;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private PlayerControllerBase playerControllerBase;
        [SerializeField] private PlayerBase playerBase;
        [SerializeField] private GameObject introPanel;
        [SerializeField] private GameObject finishPanel;
        [SerializeField] private GameObject blackout;
        
        private void Start()
        {
            playerControllerBase.SetCanMove(false);
        }

        private void Update()
        {
            if (Input.anyKeyDown && !playerBase.GameOver)
            {
                GameStartPanelControl();
            }
            
            if (playerBase.GameOver && !finishPanel.activeSelf)
            {
                GameOverPanelControl();
            }
            
            if (playerBase.GameOver && Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit(0);
                EditorApplication.ExitPlaymode();
            }
        }

        private void GameStartPanelControl()
        {
            blackout.SetActive(false);
            introPanel.SetActive(false);
        }

        private void GameOverPanelControl()
        {
            finishPanel.SetActive(true);
            playerControllerBase.SetCanMove(false);
        }
    }
}
