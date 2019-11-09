using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PlayerSystem
{
    public class PlayerController
    {
        int playerID;
        string playerName;
        private PlayerView view;
        public PlayerController(int playerID, string playerName)
        {
            this.playerID = playerID;
            this.playerName = playerName;
        }
        public void InitializePlayer(PlayerView playerPrefab, Vector3 position, float speed)
        {
            view = PhotonNetwork.Instantiate("Player_Pad",position,Quaternion.identity).GetComponent<PlayerView>();
            view.SetController(this);
           // view.SetSpeed(speed);
        }
        public void SetPlayerMaterial(Material playerMat)
        {
            view.SetPlayerMaterial(playerMat);
        }
        public void MovePad(int dir)
        {

            view.MovePad(dir);
        }
        public int GetPlayerID()
        {
            return playerID;
        }
        public string GetPlayerName()
        {
            return playerName;
        }
    }
}
