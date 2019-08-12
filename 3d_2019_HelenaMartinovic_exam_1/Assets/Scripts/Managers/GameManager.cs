using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    CameraController cameraController;
    PlayerController playerController;

    void Start()
    {
        StatusesManager.init();
        var enemySpawnpoints = new Dictionary<EnemyType, Transform[]>();
        var mushroomSpawnPoints = GameObject.Find(StringConstants.SceneObjects.MashroomSpawnPoints);
        var turtleSpawnPoints = GameObject.Find(StringConstants.SceneObjects.TurtleSpawnPoints);

        
        if(mushroomSpawnPoints != null){
            enemySpawnpoints.Add(EnemyType.Mashroom, getAllChilds(mushroomSpawnPoints.transform));
        }

        if(turtleSpawnPoints != null){
            enemySpawnpoints.Add(EnemyType.Turtle, getAllChilds(turtleSpawnPoints.transform));
        }

        if(turtleSpawnPoints != null || mushroomSpawnPoints != null){
            EnemyRepository.InstantiateEnemies(enemySpawnpoints);
        }

        playerController = PlayerRepository.InstantiatePlayer();

        cameraController = Camera.main.GetComponent<CameraController>();
        cameraController.player = playerController.gameObject;
    }

    void Update()
    {
        var skybox = RenderSettings.skybox;

        skybox.SetTextureOffset("_FrontTex", skybox.GetTextureOffset("_FrontTex") + new Vector2(Time.deltaTime * 0.01f, 0));
        skybox.SetTextureOffset("_BackTex", skybox.GetTextureOffset("_BackTex") + new Vector2(Time.deltaTime * 0.01f, 0));
        skybox.SetTextureOffset("_LeftTex", skybox.GetTextureOffset("_LeftTex") + new Vector2(Time.deltaTime * 0.01f, 0));
        skybox.SetTextureOffset("_RightTex", skybox.GetTextureOffset("_RightTex") + new Vector2(Time.deltaTime * 0.01f, 0));
        skybox.SetTextureOffset("_UpTex", skybox.GetTextureOffset("_UpTex") + new Vector2(Time.deltaTime * 0.01f, 0));
        skybox.SetTextureOffset("_DownTex", skybox.GetTextureOffset("_DownTex") + new Vector2(Time.deltaTime * 0.01f, 0));
    }

    public Transform[] getAllChilds(Transform parent)
    {
        Transform[] childrenTransform = new Transform[parent.childCount];

        for (int i = 0; i < parent.childCount; i++)
        {
            childrenTransform[i] =parent.GetChild(i);
        }
        return childrenTransform;
    }
}
