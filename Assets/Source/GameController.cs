using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	
	public GameObject pillPrefab;
	
	private static GameController m_Instance;
  	public static GameController Instance { get { return m_Instance; } }
	
	private int _pillCount = 0;	
	private float _totalScore = 0;
	
	void Awake()
  	{
    	m_Instance = this;
  	}

  	void OnDestroy()
  	{
    	m_Instance = null;
  	}
	
	// Use this for initialization
	void Start () {
		NewPill();
		NewPill();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	
	public void RemovePill(GameObject pill)
	{		
		Destroy(pill);
		--_pillCount;		
		
		if (Time.fixedTime / 10 > _pillCount)
		{
			NewPill();
		}
		
		NewPill();
	}	
	
	public void HitPill(GameObject pill, float score)
	{
		_totalScore += score;
		guiText.text = String.Format("{0:F0}", _totalScore);
		
		RemovePill(pill);
	}
	
	private void NewPill()
	{
		Instantiate(pillPrefab);
		++_pillCount;		
	}
}
