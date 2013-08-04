using UnityEngine;
using System.Collections;

public class PillClass : MonoBehaviour {
	
	private float minAngleSpeed = 50f;
	private float maxAngleSpeed = 200f;
	
	private float minScale = 0.15f;
	private float maxScale = 1.5f;
	
	private float maxFallSpeed = 5;
	
	private float rotateSpeedX;
	private float rotateSpeedY;
	private float rotateSpeedZ;
		
	private float scale;
	private float fallSpeed;	
	
	// Use this for initialization
	void Start() {				
		RandomizeAngleSpeed();
		RandomizeSize();
		RandomizeXCoord();		
		RandomizeTexture();
	}
	
	private void RandomizeAngleSpeed()
	{
		rotateSpeedX = GetAngleSpeed();
		rotateSpeedY = GetAngleSpeed();
		rotateSpeedZ = GetAngleSpeed();
	}
	
	private void RandomizeSize()
	{
		scale = GetScale();
		fallSpeed = maxFallSpeed/scale;
		transform.localScale += new Vector3(scale, scale, scale);
	}
	
	private void RandomizeXCoord()
	{
		var cameraWidth = GetCameraWidth();
		var pillHeight = renderer.bounds.size.y;
		var dxMax = (cameraWidth - pillHeight)/2;
		var dx = Random.Range(-dxMax, dxMax);			
		
		transform.Translate(new Vector3(dx, 0, 0));
	}
	
	private void RandomizeTexture()
	{
		var texture = PillTextureGenerator.Generate(32, 32);
		renderer.material.mainTexture = texture;
	}
	
	// Update is called once per frame
	void Update() {		
		transform.Rotate(new Vector3(rotateSpeedX*Time.deltaTime, rotateSpeedY*Time.deltaTime, rotateSpeedZ*Time.deltaTime));		
		transform.Translate( new Vector3(0, -fallSpeed*Time.deltaTime,0), Space.World);
	}
	
	void OnMouseDown() {
		// User clicked pill by mouse
		GameController.Instance.HitPill(this.gameObject, GetScore());		
	}
	
	void OnTriggerEnter(Collider obj) {
		// Remove pill if it touches bottom plane
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
	
	private float GetCameraWidth()
	{
		var cam = Camera.main;
		var camHeight = 2f * cam.orthographicSize;
		return camHeight * cam.aspect;		
	}
}
