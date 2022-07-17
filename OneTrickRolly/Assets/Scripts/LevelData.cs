using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LevelData", order = 1)]
public class LevelData : ScriptableObject
{
    [SerializeField] private float _planeWidth = 5.0f;
    [SerializeField] private float _planeHeight = 5.0f;

    public float PlaneWidth { get { return _planeWidth; } }
    public float PlaneHeight { get { return _planeHeight; } }
}
