using BallSystem;
using Commons;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public class GameManager
    {
        public GameObject ball;
        BallViewController ballController;


        public GameManager()
        {
            ManagerLocator.Instance.GetMultiplayerManager().OnGameStart += CreateBall;
            //ManagerLocator.Instance.GetMultiplayerManager().OnGameUpdate += UpdateGame;
        }
        public void CreateBall()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                ballController = PhotonNetwork.Instantiate("ball", new Vector3(0, 0.24f, 0), Quaternion.identity).GetComponent<BallViewController>();
            }
        }



    }
}