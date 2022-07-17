using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private LevelData _firstLevel = null;
    private LevelData _currentLevel = null;

    #region Properties
    public LevelData CurrentLevel { get { return _currentLevel; } }
    #endregion Properties

    // Start is called before the first frame update
    void Start()
    {
        _currentLevel = _firstLevel;
    }

    public void StartLevel(LevelData level)
    {
        _currentLevel = level;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
