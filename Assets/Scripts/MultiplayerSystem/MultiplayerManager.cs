using UnityEngine;
using UnityEditor;
using System;
using Commons;
using PlayerSystem;
using InpuSystem;
using Photon.Pun;
using Photon.Realtime;

namespace MultiplayerSystem
{
    public class MultiplayerManager : MonoBehaviourPunCallbacks
    {
        public event Action OnPlayerConnected;
        public event Action<int,string> OnPlayerJoinedRoom;
        public event Action OnGameStart;
        //public event Action<UpdateData> OnGameUpdate;
        //public event Action OnGamePlayStarted;
        //public event Action<UpdateData> OnPadMoved;
        PlayerManager playerManager;
        public void Awake()
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        public void JoinRoom()
        {
            PhotonNetwork.JoinRandomRoom();
        }
        public override void OnConnectedToMaster()
        {
            OnPlayerConnected?.Invoke();
            Debug.Log("<color=red>Player connected to master</color>");
        }
        public void Register(string name)
        {
            PhotonNetwork.NickName = name;  
            PhotonNetwork.JoinLobby();
        }
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            Debug.Log("<color=red>On Remote PlayerJoined </color>"+ newPlayer.NickName);
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                OnGameStart.Invoke();
            }
            // OnPlayerJoinedRoom.Invoke(PhotonNetwork.CurrentRoom.PlayerCount - 1, PhotonNetwork.NickName);
        }
        public override void OnJoinedLobby()
        {
            Debug.Log("<color=red>Player Joined Lobby</color>");
            JoinRoom();
        }
        public override void OnJoinedRoom()
        {
            Debug.Log("<color=red>Player Joined Room </color>"+PhotonNetwork.CurrentRoom.Name);
            OnPlayerJoinedRoom.Invoke(PhotonNetwork.CurrentRoom.PlayerCount - 1,PhotonNetwork.NickName);
            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                OnGameStart.Invoke();
            }
        }
        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            Debug.Log("<color=red> Join Room Failed</color>");
            CreateRoom();
            //PhotonNetwork.JoinRandomRoom();
        }
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("<color=red> Join Random Room Failed</color>");
            CreateRoom();
            //PhotonNetwork.JoinRandomRoom();
        }
        public void CreateRoom()
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 2;
            PhotonNetwork.CreateRoom("Room" + PhotonNetwork.CountOfRooms);
        }
    }
}