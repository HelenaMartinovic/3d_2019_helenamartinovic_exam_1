using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerRepository
{
    private static PlayerController _playerController;//todo pripaziti na reset zbog levela

    public static PlayerController InstantiatePlayer(){
        if(_playerController != null)
        return _playerController;

        GameObject playerObject = GameObject.Instantiate(Resources.Load<GameObject>(StringConstants.Prefabs.Player),
                                                         Vector3.zero,
                                                         Quaternion.identity);

        var playerController = playerObject.GetComponent<PlayerController>();
        playerController.playerAudio = AudioManager.Instance;
        
        _playerController = playerController;
        return _playerController;
    }
}