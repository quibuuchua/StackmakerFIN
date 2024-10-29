using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UiManager : Singleton<UiManager>
{
    // Start is called before the first frame update
    [SerializeField] GameObject menu;
   // [SerializeField] GameObject playingMode;
    [SerializeField] GameObject victory;
    [SerializeField] GameObject lose;
    [SerializeField] GameObject levelSelect;
    public void Start()
    {
        MenuOpen();
    }
    public void MenuOpen()
    {
        menu.SetActive(true );
        lose.SetActive(false );
        victory.SetActive(false );
        levelSelect.SetActive(false );
       //GameManager.Instance.ChangeState(GameSate.)
       
    }  public void VictoryOpen()
    {
        menu.SetActive(false );
        lose.SetActive(false );
        victory.SetActive(true );
       
    } public void LoseOpen()
    {
        menu.SetActive(false );
        lose.SetActive(true );
        victory.SetActive(false);
       
    }
    
    public void LevelSelectOpen()
    {
        menu.SetActive(false ) ;
        levelSelect.SetActive(true);
        lose.SetActive(false);
        victory.SetActive(false);

    }
    public void PlayButton()
    {
        menu.SetActive(false);
       // LevelManager.Instance.OnInit();
        LevelManager.Instance.OnPlaying();
        //GameManager.Instance.ChangeState(GameState.PlayingMode);

    }
    
    public void RetryButton()
    {
       
        GameManager.Instance.ChangeState(GameState.Menu);
        MenuOpen();
        LevelManager.Instance.LevelLoading();

    }
    public void NextLevelButton()
    {
        MenuOpen();
        LevelManager.Instance.NextLevel();
    }
    public void LevelSelectButton()
    {
        LevelSelectOpen();
    }
   public void LevelButton()
    {
        GameManager.Instance.ChangeState(GameState.Menu);
        MenuOpen();

        LevelManager.Instance.LevelLoading();

    }
}
