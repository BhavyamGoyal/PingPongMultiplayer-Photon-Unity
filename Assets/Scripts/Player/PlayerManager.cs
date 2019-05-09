using Commons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player
{
   
    public class PlayerManager
    {
        private PlayerScriptable playerSettings;
        private string localPlayerID=null;
        List<Material> playerMaterial;
        public Dictionary<string,PlayerController> players = new Dictionary<string,PlayerController>();
        public List<Transform> spawnPoints=new List<Transform>();
        public PlayerManager(PlayerScriptable playerSettings,List<Material> playerMaterial)
        {
            this.playerMaterial = playerMaterial;
            this.playerSettings = playerSettings;
            spawnPoints.Add(GameObject.FindGameObjectWithTag("spawn1").GetComponent<Transform>());
            spawnPoints.Add(GameObject.FindGameObjectWithTag("spawn2").GetComponent<Transform>());
            ManagerLocator.Instance.GetMultiplayerManager().OnPlayerConnected += InitializePlayer;
            ManagerLocator.Instance.GetMultiplayerManager().OnPadMoved += MovePlayer;
            ManagerLocator.Instance.GetMultiplayerManager().OnPlayerJoined += spawnPlayer;
        }
        public void MovePlayer(UpdateData data)
        {
            foreach(string id in data.padData.Keys)
            {
                players[id].MovePad(data.padData[id]);
            }
        }
        ~PlayerManager()
        {
            ManagerLocator.Instance.GetMultiplayerManager().OnPlayerJoined -= spawnPlayer;
            ManagerLocator.Instance.GetMultiplayerManager().OnPlayerConnected -= InitializePlayer;
        }
        public void InitializePlayer(PlayerData playerData)
        {
            if (localPlayerID == null)
            {
                localPlayerID = playerData.playerID;
            }
            PlayerController playerController = new PlayerController(playerData.playerID, playerData.playerName);
            players.Add(playerData.playerID, playerController);
        }
        public void spawnPlayer(PlayerData playerData)
        {
            if (!players.ContainsKey(playerData.playerID))
            {
                PlayerController playerController = new PlayerController(playerData.playerID, playerData.playerName);
                players.Add(playerData.playerID, playerController);
            }
            players[playerData.playerID].InitializePlayer(playerSettings.PlayerPrefab, spawnPoints[playerData.spawnPoint].position, playerSettings.Speed);
            players[playerData.playerID].SetPlayerMaterial(playerMaterial[playerData.spawnPoint]);
        }
    }
}
