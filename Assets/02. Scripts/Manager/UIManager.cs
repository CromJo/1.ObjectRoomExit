using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    Text m_Text;
    Door m_Door;
    Key m_Key;

    public enum TextState
    {
        None = 0,
        DoorLock,                   //문을 못열때
        DoorOpenAndClose,               //열고 닫을때 
        GetKeyOpenDoor,                         //키얻고 문앞에 있을 때
        ItemEquip
    }
    public TextState m_State = TextState.None;
    public TextState TextStatus { get { return m_State; } set { m_State = value; } }
    // Start is called before the first frame update
    void Start()
    {
        m_Text = gameObject.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    public void UpdateState(TextState state)
    {
        if (m_State == state)
            return;

        m_State = state;

        switch(m_State)
        {
            case TextState.None:
                m_Text.text = "";
                break;
            case TextState.DoorLock:
                m_Text.text = "문이 잠겨있다. 열쇠가 필요할 것 같다.";
                break;
            case TextState.DoorOpenAndClose:
                m_Text.text = "문 열기/닫기";
                break;
            case TextState.GetKeyOpenDoor:
                m_Text.text = "문이 잠겨있다. 어쩌면 이 열쇠로 열 수 있을 것 같다.";
                break;
            case TextState.ItemEquip:
                m_Text.text = "아이템 줍기";
                break;
        }
    }

    bool IsState(TextState state)
    {
        return m_State == state;
    }
    
}
