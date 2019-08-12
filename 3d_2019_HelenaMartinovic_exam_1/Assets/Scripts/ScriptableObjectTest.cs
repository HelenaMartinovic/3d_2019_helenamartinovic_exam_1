using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Inventory/List", order = 1)]
public class ScriptableObjectTest : ScriptableObject
{
    public string objectName;
    public Vector3[] spawnPoints;
}