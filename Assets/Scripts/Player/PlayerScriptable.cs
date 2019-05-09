using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Player/PlayerSettings")]
    public class PlayerScriptable : ScriptableObject
    {
        public float Speed = 5;
        public PlayerView PlayerPrefab;

    }
}