using UnityEngine;
using UnityEditor;
using SocketIO;
using System;
using Commons;
using Player;
using InpuSystem;

namespace MultiplayerSystem
{
    public class MultiplayerManager : SocketIOComponent
    {
        public event Action<PlayerData> OnPlayerConnected;
        public event Action<PlayerData> OnPlayerJoined;
        public event Action<UpdateData> OnGameUpdate;
        public event Action OnGamePlayStarted;
        public event Action<UpdateData> OnPadMoved;

        PlayerManager playerManager;
        public override void Start()
        {
            base.Start();
            playerManager = ManagerLocator.Instance.GetPlayerManager();
            On("onConnected", OnConnected);
            On("onUserRegister", OnRegister);
            On("onJoinGame", PlayerJoined);
            On("onGameStarted", OnGameStarted);
            On("onServerUpdate", OnServerUpdate);
        }
        private void OnConnected(SocketIOEvent socketEvent)
        {
            Debug.Log("[MultiplayerManager]OnConnected" + socketEvent.data.ToString());
        }
        private void OnServerUpdate(SocketIOEvent socketEvent)
        {
            Debug.Log("[MultiplayerManager]Position Updating" + socketEvent.data.ToString());
            UpdateData updateData = new UpdateData();
            BallData ballData = new BallData();
            JSONObject ballPositionObject = socketEvent.data.GetField("ball");
            //Debug.Log("<color=red> ball positon on server update +received </color>" + ballPositionObject.ToString());
            ballPositionObject.GetField(ref ballData.xPos, "xPos");
            ballPositionObject.GetField(ref ballData.yPos, "yPos");
            updateData.ballPos = ballData;
            JSONObject padsPositionsObject = socketEvent.data.GetField("pads");
            if (padsPositionsObject.keys.Count != 0)
            {
                for (int i = 0; i < padsPositionsObject.keys.Count; i++)
                {
                    PadData pData = new PadData();
                    JSONObject padPos = padsPositionsObject.GetField(padsPositionsObject.keys[i]);
                    padPos.GetField(ref pData.xPos, "xPos");
                    padPos.GetField(ref pData.yPos, "yPos");

                    updateData.padData.Add(padsPositionsObject.keys[i], pData);
                }
                OnPadMoved.Invoke(updateData);
            }
            OnGameUpdate.Invoke(updateData);
        }
        private void OnRegister(SocketIOEvent socketEvent)
        {
            Debug.Log("[MultiplayerManager]OnRegister" + socketEvent.data.ToString());
            PlayerData playerData = new PlayerData();
            socketEvent.data.GetField(ref playerData.playerID, "playerID");
            socketEvent.data.GetField(ref playerData.playerName, "playerName");
            OnPlayerConnected.Invoke(playerData);
            JoinRoom();
        }
        private void OnGameStarted(SocketIOEvent socketEvent)
        {

            Debug.Log("[MultiplayerManager]OnGameStarted" + socketEvent.data.ToString());
            string message = "GameStarted";
            OnGamePlayStarted.Invoke();
        }
        public void sendInput(InputStructure inputData)
        {
            JSONObject dataToSend = new JSONObject();
            dataToSend.AddField("direction", inputData.direction);
            Emit("sendInput", dataToSend);
        }
        private void PlayerJoined(SocketIOEvent socketEvent)
        {
            Debug.Log("[MultiplayerManager]PlayerJoined" + socketEvent.data.ToString());
            PlayerData playerData = new PlayerData();
            socketEvent.data.GetField(ref playerData.playerID, "playerID");
            socketEvent.data.GetField(ref playerData.spawnPoint, "playerSpawn");
            OnPlayerJoined.Invoke(playerData);
        }
        public void JoinGame(string name)
        {
            JSONObject dataToSend = new JSONObject();
            dataToSend.AddField("playerName", name);
            Emit("registerUser", dataToSend);
        }
        public void JoinRoom()
        {
            Emit("joinRoom");
        }
    }
}