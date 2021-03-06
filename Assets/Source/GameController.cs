﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
		
	public GameObject pillPrefab;
	
	// Complexity of the game. After each 10 sec. additional pill will be appear
	private int SecondForAdditionalPills = 10;
	
	private static GameController m_Instance;
  	public static GameController Instance { get { return m_Instance; } }
	
	private int _pillCount = 0;	
	private float _totalScore = 0;
	
	void Awake()
  	{
    	m_Instance = this;
		pillPrefab = (GameObject)BundleLoader.Load("file://" + Application.dataPath + "/AssetBundles/Pill.unity3d");
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
	void Update () 
	{
		UpdateText();
	}	
	
	public void RemovePill(GameObject pill)
	{		
		DestroyImmediate(pill.renderer.material.mainTexture);
		Destroy(pill);
		--_pillCount;		
		
		RespawnPills();
	}	
	
	// Spawn new pills
	private void RespawnPills()
	{
		if (Time.fixedTime / SecondForAdditionalPills > _pillCount)
		{
			NewPill();
		}
		
		NewPill();
	}
	
	
	// Increase score counter
	public void HitPill(GameObject pill, float score)
	{
		_totalScore += score;		
		
		RemovePill(pill);
	}
	
	
	// Add new pill on scene	
	private void NewPill()
	{
		Instantiate(pillPrefab);
		++_pillCount;		
	}
	
	
	// Show timer and score	
	private void UpdateText()
	{
		var totalTime = TimeSpan.FromSeconds(Time.fixedTime);
		guiText.text = String.Format("Time {0:00}:{1:00} Score {2:F0}", totalTime.TotalMinutes, totalTime.Seconds, _totalScore);
	}
}
