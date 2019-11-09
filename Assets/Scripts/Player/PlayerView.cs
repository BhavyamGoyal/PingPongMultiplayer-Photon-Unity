using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PlayerSystem
{
    public class PlayerView : MonoBehaviour
    {
        PlayerController controller;
        Rigidbody rb;
        Vector3 moveingSpeed = new Vector3(0, 0, 10);
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
        // Update is called once per frame
        void Update()
        {

        }
        
        public void SetPlayerMaterial(Material playerMat)
        {
            //Debug.Log("Player spawn"+playerMat.name);
            gameObject.GetComponentInChildren<Renderer>().material = playerMat;
        }
        public void SetController(PlayerController controller)
        {
            this.controller = controller;
        }
        public void MovePad(int dir)
        {
            Debug.Log("inputs");
            rb.velocity=(dir * moveingSpeed);
        }
    }
}
