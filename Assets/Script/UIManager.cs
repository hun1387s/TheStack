using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public enum UIState
{
    Home,
    Game,
    Score
}
public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager Instance
    {
        get { return instance; }
    }

    UIState currentState = UIState.Home;
    HomeUI homeUI = null;
    GameUI gameUI = null;
    ScoreUI scoreUI = null;

    TheStack theStack = null;

    private void Awake()
    {
        instance = this;
        theStack = FindObjectOfType<TheStack>();

        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI?.Init(this); // homeUI가 null이 아니면 동작해라

        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI?.Init(this); // homeUI가 null이 아니면 동작해라

        scoreUI = GetComponentInChildren<ScoreUI>(true);
        scoreUI?.Init(this); // homeUI가 null이 아니면 동작해라

        ChangeState(UIState.Home);
    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        scoreUI?.SetActive(currentState);
    }

    public void OnClickStart()
    {
        theStack.Restart();
        ChangeState(UIState.Game);
    }

    public void OnClickExit()
    {
        // 전처리기를 통한 제어
        // 유니티 에디터라면, 에디터 플레이를 종료
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void UpdateScore()
    {
        gameUI.SetUI(theStack.Score, theStack.Combo, theStack.MaxCombo);
    }

    public void SetScoreUI()
    {
        scoreUI.SetUI(theStack.Score, theStack.MaxCombo, theStack.BestScore, theStack.BestCombo);
        ChangeState(UIState.Score);
    }


}
