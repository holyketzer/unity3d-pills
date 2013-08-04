using UnityEngine;
using System.Collections;

public class PillClass : MonoBehaviour {
	
	private float minAngleSpeed = 50f;
	private float maxAngleSpeed = 200f;
	
	private float minScale = 0.25f;
	private float maxScale = 2;	
	
	private float maxFallSpeed = 5;
	
	private float rotateSpeedX;
	private float rotateSpeedY;
	private float rotateSpeedZ;
		
	private float scale = 1;
	private float fallSpeed = 1;
	
	private static float _zOffset = 0;
	
	// Use this for initialization
	void Start() {
		rotateSpeedX = GetAngleSpeed();
		rotateSpeedY = GetAngleSpeed();
		rotateSpeedZ = GetAngleSpeed();
		
		scale = GetScale();
		fallSpeed = maxFallSpeed/scale;
		transform.localScale += new Vector3(scale, scale, scale);
		
		Camera cam = Camera.main;
		float camHeight = 2f * cam.orthographicSize;
		float camWidth = camHeight * cam.aspect;		
				
		var pillHeight = renderer.bounds.size.y;
		var dxMax = (camWidth - pillHeight)/2;
		var dx = Random.Range(-dxMax, dxMax);			
		
		//_zOffset += pillHeight;
		if (_zOffset > 22)
		{
			_zOffset = 0;
		}
		transform.Translate(new Vector3(dx, 0, _zOffset));
	}
	
	// Update is called once per frame
	void Update() {		
		transform.Rotate(new Vector3(rotateSpeedX*Time.deltaTime, rotateSpeedY*Time.deltaTime, rotateSpeedZ*Time.deltaTime));		
		transform.Translate( new Vector3(0, -fallSpeed*Time.deltaTime,0), Space.World);
	}
	
	void OnMouseDown() {
		GameController.Instance.HitPill(this.gameObject, GetScore());		
	}
	
	void OnTriggerEnter(Collider obj) {
		if (obj.gameObject.name == "Bottom") {								
			GameController.Instance.RemovePill(this.gameObject);
		}
	}
	
	private float GetAngleSpeed()
	{		
		return Random.Range(minAngleSpeed, maxAngleSpeed);	
	}
	
	private float GetScale()
	{
		return Random.Range(minScale, maxScale);
	}
	
	private float GetScore()
	{		
		return (fallSpeed * fallSpeed) / 5;
	}
}
