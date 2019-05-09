using Commons;
using MultiplayerSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuUI : MonoBehaviour
{
    public Button StartGame;
    public InputField nameInput;
    MultiplayerManager multiplayerManager;
    // Start is called before the first frame update
    void Start()
    {
        StartGame.onClick.AddListener(JoinGame);
        multiplayerManager = ManagerLocator.Instance.GetMultiplayerManager();
    }

    public void JoinGame()
    {
        string name = nameInput.text;
        multiplayerManager.JoinGame(name);
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        StartGame.onClick.RemoveListener(JoinGame);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
