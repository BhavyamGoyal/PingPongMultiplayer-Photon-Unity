using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BallSystem
{
    public class BallViewController : MonoBehaviour
    {
        Vector3 moveToPos;
        public void Start()
        {
            GetComponent<Rigidbody>().velocity = new Vector3(5, 0, 2);
        }
    }
}