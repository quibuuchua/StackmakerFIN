using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Unity.VisualScripting;

public class LevelManager : Singleton<LevelManager>
{
    // Start is called before the first frame update
    [SerializeField]public List<Level> levels = new List<Level>();
    
    [SerializeField ]Player player;
   public Level currentLevel;
    public int level = 1;
    private void Start()
    {
        
        //Debug.Log(Resources.Load("abc"));

        LevelLoading();
     
        UiManager.Instance.MenuOpen();
    }
   public void LevelLoading()
    {
        LoadLevel(level);
        OnInit();

    }
    public void LoadLevel(int indexLevel)
    {
        if(currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }
        currentLevel = Instantiate(levels[indexLevel-1]); 
        //var temp = Resources.Load("Resources/Level/Level1.prefab", typeof(Level));
        //currentLevel = Instantiate(temp) as Level;

            

    }
    public void OnInit()
    {
        player.transform.position= currentLevel.startPos.position;
        player.OnInit();
    }
    public void OnPlaying()
    {
        GameManager.Instance.ChangeState(GameState.PlayingMode);
    }
    public void OnWin()
    {
        UiManager.Instance.VictoryOpen();
        GameManager.Instance.ChangeState(GameState.Victory);
    }
    public void NextLevel()
    {
        level++;
        LevelLoading();
    }
    public void ChooseLevel()
    {

    }
}
