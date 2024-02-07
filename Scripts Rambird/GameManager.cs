using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Gamestates {FinishTheLevel, RunningGame, PauseTheGame, GameOver, InteractionWithNPCorUI, Menu}
public class GameManager : MonoBehaviour
{   public static GameManager _SharedInstanceGameManager;
    public string SceneName;
    public Canvas PlayerCanvass, GameOverCanvass, PauseCanvass, InteractionCanvass, FinishLevelCanvass, MenuCanvass;
    [Range(0, 10)]
    private GameObject PlayerController1, PlayerController2;
    public Gamestates CurrentGamestate;

    public void RunTheGame() {CurrentGamestate = Gamestates.RunningGame; if(CurrentGamestate == Gamestates.RunningGame) {PlayerCanvass.enabled = true; GameOverCanvass.enabled = false; FinishLevelCanvass.enabled = false; PauseCanvass.enabled = false; InteractionCanvass.enabled = false; Time.timeScale = 1; } }
    public void PauseTheGame() {CurrentGamestate = Gamestates.PauseTheGame; if(CurrentGamestate == Gamestates.PauseTheGame) {PlayerCanvass.enabled = false; FinishLevelCanvass.enabled = false; GameOverCanvass.enabled = false; PauseCanvass.enabled = true; InteractionCanvass.enabled = false; Time.timeScale = 1; Time.timeScale = 0; } }
    public void GameOver() {CurrentGamestate = Gamestates.GameOver; if(CurrentGamestate == Gamestates.GameOver) {PlayerCanvass.enabled = false; GameOverCanvass.enabled = true; FinishLevelCanvass.enabled = false; PauseCanvass.enabled = false; InteractionCanvass.enabled = false; Time.timeScale = 0;}}
    public void FinishTheLevel() {CurrentGamestate = Gamestates.FinishTheLevel; if(CurrentGamestate == Gamestates.FinishTheLevel) { PlayerCanvass.enabled = true; FinishLevelCanvass.enabled = true; GameOverCanvass.enabled = false; PauseCanvass.enabled = false; InteractionCanvass.enabled = false; Time.timeScale = 1; } }
    public void InteractWithNPC() {CurrentGamestate = Gamestates.InteractionWithNPCorUI; if (CurrentGamestate == Gamestates.InteractionWithNPCorUI) { FinishLevelCanvass.enabled = false; PlayerCanvass.enabled = true; GameOverCanvass.enabled = false; PauseCanvass.enabled = false; Time.timeScale = 1; InteractionCanvass.enabled = true; } }
    public void MenuMoment() {CurrentGamestate = Gamestates.Menu; if (CurrentGamestate == Gamestates.Menu) { PlayerCanvass.enabled = false; GameOverCanvass.enabled = false; FinishLevelCanvass.enabled = false; PauseCanvass.enabled = false; Time.timeScale = 1; InteractionCanvass.enabled = false; MenuCanvass.enabled = true; } }

    public void ChangeGamestates(Gamestates NewGameState)
    {   if (NewGameState == Gamestates.Menu) {CurrentGamestate=NewGameState;MenuMoment();}
        else if (NewGameState == Gamestates.InteractionWithNPCorUI) { CurrentGamestate = NewGameState;InteractWithNPC();}
        else if (NewGameState == Gamestates.PauseTheGame) { CurrentGamestate = NewGameState;PauseTheGame(); }
        else if (NewGameState == Gamestates.GameOver) { CurrentGamestate = NewGameState; GameOver(); }
        else if (NewGameState == Gamestates.FinishTheLevel) { CurrentGamestate = NewGameState; FinishTheLevel(); }
        else if (NewGameState == Gamestates.RunningGame) { CurrentGamestate = NewGameState;RunTheGame(); }
    }
    
    public void RetryLevel() {SceneManager.LoadScene(SceneName); ; }

    private void Start()
    {_SharedInstanceGameManager=this;
     ChangeGamestates(CurrentGamestate);}

    void Update()
    { if (Input.GetKeyDown("p") && CurrentGamestate == Gamestates.RunningGame) {PauseTheGame();}}
}
