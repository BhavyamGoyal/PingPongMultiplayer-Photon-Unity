using Commons;
using MultiplayerSystem;
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
        void Start()
        {
            multiplayerManager = ManagerLocator.Instance.GetMultiplayerManager();
        }
        InputStructure inputData = new InputStructure();
        bool send = true;
        void FixedUpdate()
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                send = true;
                inputData.direction = 1;
                multiplayerManager.sendInput(inputData);
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                send = true;
                inputData.direction = -1;
                multiplayerManager.sendInput(inputData);
            }
            else if (send)
            {
                inputData.direction = 0;
                multiplayerManager.sendInput(inputData);
                send = false;
            }
        }
    }
}