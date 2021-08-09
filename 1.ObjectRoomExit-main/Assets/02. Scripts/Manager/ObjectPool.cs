using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	public static ObjectPool Instance;						//전역변수 생성

	Queue<Key> m_ObjectPoolKey = new Queue<Key>();			//큐 생성
	[SerializeField] GameObject m_ObjectPoolPrefabs;		//생성해줄 게임오브젝트 변수 생성

	private void Awake()
	{
		Instance = this;									//싱글톤
		Initialize(2);										//이니셜 라이즈 함수 실행
	}

	private void Initialize(int initcount)					
	{
		for (int i = 0; i < initcount; i++)					//받아온 크기만큼 포문 돌리고
		{
			m_ObjectPoolKey.Enqueue(CreateObject());		//크기만큼 큐 끝부분에 추가
		}
	}

	private Key CreateObject()								
	{
		var newObj = Instantiate(m_ObjectPoolPrefabs).GetComponent<Key>();
		newObj.gameObject.SetActive(false);
		newObj.transform.SetParent(transform);
		return newObj;
	}

	public static Key GetObject()
	{
		if (Instance.m_ObjectPoolKey.Count > 0)
		{
			var obj = Instance.m_ObjectPoolKey.Dequeue();
			obj.transform.SetParent(null);
			obj.gameObject.SetActive(true);
			return obj;
		}
		else
		{
			var newObj = Instance.CreateObject();
			newObj.gameObject.SetActive(true);
			newObj.transform.SetParent(null);
			return newObj;
		}
	}

	public static void ReturnObject(Key obj)
	{
		obj.gameObject.SetActive(false);
		obj.transform.SetParent(Instance.transform);
		Instance.m_ObjectPoolKey.Enqueue(obj);
	}
}
