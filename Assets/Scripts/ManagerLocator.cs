using UnityEngine;
using System.Collections;
using Player;
using MultiplayerSystem;
using System.Collections.Generic;
using GameSystem;

namespace Commons
{
    public class ManagerLocator : Singleton<ManagerLocator>
    {
        PlayerManager playerManager;
        [SerializeField] List<Material> playerMaterial = new List<Material>();
        [SerializeField]private MultiplayerManager multiplayerManager;
        GameManager gameManager;
        public PlayerScriptable playerSettings;
        // Use this for initialization
        void Start()
        {
            playerManager = new PlayerManager(playerSettings,playerMaterial);
            gameManager = new GameManager();
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