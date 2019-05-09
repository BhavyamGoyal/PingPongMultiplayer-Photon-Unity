using BallSystem;
using Commons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameSystem {
    public class GameManager
    {
        public GameObject ball;
        BallViewController ballController; 


        public GameManager()
        {
            ball = Resources.Load<GameObject>("ballPrefab");
            ManagerLocator.Instance.GetMultiplayerManager().OnGamePlayStarted += CreateBall;
            ManagerLocator.Instance.GetMultiplayerManager().OnGameUpdate += UpdateGame;
        }
        public void UpdateGame(UpdateData data)
        {

            ballController.UpdateBallPosition(data.ballPos);
        }
        public void CreateBall()
        {
            ballController = GameObject.Instantiate(ball).GetComponent<BallViewController>();
        }



    }
}