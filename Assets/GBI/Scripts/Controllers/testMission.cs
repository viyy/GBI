using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testMission : MonoBehaviour
{
    private GameObject _mazeGameObject;
    private Maze _mazeScript;
    public GameObject _treasure;
    private IntVector2 _tempPos;
    public bool _generateTreasureFlag;
    private void Update()
    {
        if (_generateTreasureFlag == false)
        {
           Generate();         
        }
        
    }
    public GameObject Generate()
    {
        
        _tempPos = FindMazeOnScene().RandomCoordinates;
        return GameObject.Instantiate(_treasure,new Vector3(_tempPos.x,1,_tempPos.z), new Quaternion());
    }

    private Maze FindMazeOnScene()
    {
        GameObject _mazeGameObject = GameObject.FindWithTag("Maze");
        Maze _mazeScript = _mazeGameObject.GetComponentInParent<Maze>() as Maze;
        _generateTreasureFlag = true;
        return _mazeScript;
    }
}
