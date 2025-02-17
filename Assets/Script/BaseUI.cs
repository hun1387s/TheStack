using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    // UI를 컨트롤하는 클래스
    protected UIManager uiManager;
    public virtual void Init(UIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    protected abstract UIState GetUIState();
    public void SetActive(UIState state)
    {
        // 받아온 state와 GetUIState가 같다면 켜고 다르다면 끄는기능
        gameObject.SetActive(GetUIState() == state);
    }


}


