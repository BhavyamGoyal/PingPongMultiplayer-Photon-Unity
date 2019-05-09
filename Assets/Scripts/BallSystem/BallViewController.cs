using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BallSystem
{
    public class BallViewController : MonoBehaviour
    {
        Vector3 moveToPos;
        private void FixedUpdate()
        {
            if (moveToPos != this.transform.position)
            {
                this.transform.position = moveToPos;//Vector3.Lerp(this.transform.position, moveToPos, 1 * Time.deltaTime);
            }
        }
        public void UpdateBallPosition(BallData updatedBallPos)
        {
            moveToPos = new Vector3(updatedBallPos.xPos,this.transform.position.y,updatedBallPos.yPos);
        }
    }
}