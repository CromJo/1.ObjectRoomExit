using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    bool m_KeyActive;
    Player m_Player;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        m_KeyActive = false;
        m_Player = m_Player.gameObject.transform.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //플레이어가 키를 습득 할시 게임오브젝트 삭제or플레이어 인벤토리에 넣기

        //습득한 순간 플레이어의 m_Key bool값은 true로 바뀜
        //true로 바뀐 순간에서 KeyDoor라는 태그를 가진 문에 왼쪽 클릭을 할 경우 문이 열림.
    }

    public void PickUpKey()
    {
        m_Player.IsGetKey = true;
        Destroy(this);

	}

    public void GetKey()
    {
        
    }
    
}
