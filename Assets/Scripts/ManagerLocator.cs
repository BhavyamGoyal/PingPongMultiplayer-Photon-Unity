using UnityEngine;
using System.Collections;
using PlayerSystem;
using MultiplayerSystem;
using System.Collections.Generic;
using GameSystem;
using InpuSystem;

namespace Commons
{
    public class ManagerLocator : Singleton<ManagerLocator>
    {
        PlayerManager playerManager;
        [SerializeField] List<Material> playerMaterial = new List<Material>();
        [SerializeField]private MultiplayerManager multiplayerManager;
        GameManager gameManager;
        InputController inputController; 
        public PlayerScriptable playerSettings;
        // Use this for initialization
        void Start()
        {
            inputController = GameObject.FindObjectOfType<InputController>();
            gameManager = new GameManager();
            playerManager = new PlayerManager(playerSettings,playerMaterial);
            inputController.SetPlayerManager(playerManager);
            //multiplayerManager = GameObject.Instantiate()
        }
        public PlayerManager GetPlayerManager()
        {
            return playerManager;
        }
        public MultiplayerManager GetMultiplayerManager()
        {
            return multiplayerManager;
        }
        public GameManager GetGameManager()
        {
            return gameManager;
        }
    }
}