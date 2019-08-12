using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyRepository
{
    private static GameObject mashroomEnemyResource;
    private static GameObject turtleEnemyResource;

    private static GameObject MashroomEnemyResource{
        get{
            if(mashroomEnemyResource == null){
                mashroomEnemyResource = Resources.Load<GameObject>(StringConstants.Prefabs.Mashroom);
            }

            return mashroomEnemyResource;
        }
    }

    private static GameObject TurtleEnemyResource{
        get{
            if(turtleEnemyResource == null){
                turtleEnemyResource = Resources.Load<GameObject>(StringConstants.Prefabs.Turtle);
            }

            return turtleEnemyResource;
        }
    }

    public static void InstantiateEnemies(Dictionary<EnemyType, Transform[]> spawnPoints){
        GameObject enemyResource = null;

        foreach(KeyValuePair<EnemyType, Transform[]> spawnPoint in spawnPoints)
        {
            if(spawnPoint.Key == EnemyType.Mashroom){
                enemyResource = MashroomEnemyResource;
            }
            else if(spawnPoint.Key == EnemyType.Turtle){
                enemyResource = TurtleEnemyResource;
            }

            foreach (var spawn in spawnPoint.Value) {
                GameObject.Instantiate(enemyResource, spawn.position, Quaternion.identity); 
            }
        }


    }
}
