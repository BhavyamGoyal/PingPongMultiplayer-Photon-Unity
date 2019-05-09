using Commons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PlayerSystem
{
   
    public class PlayerManager
    {
        private PlayerScriptable playerSettings;
        private string localPlayerID=null;
        List<Material> playerMaterial;
        public List<PlayerController> players = new List<PlayerController>();
        public List<Transform> spawnPoints=new List<Transform>();
        public PlayerManager(PlayerScriptable playerSettings,List<Material> playerMaterial)
        {
            this.playerMaterial = playerMaterial;
            this.playerSettings = playerSettings;
            spawnPoints.Add(GameObject.FindGameObjectWithTag("spawn1").GetComponent<Transform>());
            spawnPoints.Add(GameObject.FindGameObjectWithTag("spawn2").GetComponent<Transform>());
            ManagerLocator.Instance.GetMultiplayerManager().OnPlayerJoinedRoom += InitializePlayer;
            //ManagerLocator.Instance.GetMultiplayerManager().OnPadMoved += MovePlayer;
            //ManagerLocator.Instance.GetMultiplayerManager().OnPlayerJoined += spawnPlayer;
        }
        public void MovePlayer(int dir)
        {
            players[0].MovePad(dir);
        }
        ~PlayerManager()
        {
            //ManagerLocator.Instance.GetMultiplayerManager().OnPlayerJoined -= spawnPlayer;
            //ManagerLocator.Instance.GetMultiplayerManager().OnPlayerConnected -= InitializePlayer;
        }
        public void InitializePlayer(int playerNumber,string name)
        {
            PlayerController playerController = new PlayerController(playerNumber, name);
            playerController.InitializePlayer(playerSettings.PlayerPrefab,spawnPoints[playerNumber].position,playerSettings.Speed);
            playerController.SetPlayerMaterial(playerMaterial[playerNumber]);
            players.Add(playerController);
        }
    }
}
