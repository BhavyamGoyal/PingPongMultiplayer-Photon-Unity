using Commons;
using MultiplayerSystem;
using PlayerSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InpuSystem
{
    public class InputController : MonoBehaviour
    {
        // Start is called before the first frame update
        // Update is called once per frame
        MultiplayerManager multiplayerManager;
        PlayerManager playerManager;
        bool takeInput = false;
        void Start()
        {
            //playerManager = ManagerLocator.Instance.GetPlayerManager();
            multiplayerManager = ManagerLocator.Instance.GetMultiplayerManager();
            multiplayerManager.OnGameStart += GameStarted;
        }
        void GameStarted()
        {
            Debug.Log("GameStarted");
            takeInput = true;
        }
        public void SetPlayerManager(PlayerManager playerManager)
        {
            this.playerManager = playerManager;
        }
        InputStructure inputData = new InputStructure();
        bool send = false;
        void FixedUpdate()
        {
            if (takeInput)
            {
                if (Input.GetAxis("Vertical") > 0)
                {
                    
                    send = true;
                    inputData.direction = 1;
                    playerManager.MovePlayer(1);
                    //multiplayerManager.sendInput(inputData);
                }
                else if (Input.GetAxis("Vertical") < 0)
                {
                    send = true;
                    inputData.direction = -1;
                    playerManager.MovePlayer(-1);
                    //multiplayerManager.sendInput(inputData);
                }
                else if (send)
                {
                    send = false;
                    inputData.direction = 0;
                    playerManager.MovePlayer(0);
                    //multiplayerManager.sendInput(inputData);
                }
            }

        }
    }
}