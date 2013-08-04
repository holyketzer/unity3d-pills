using UnityEngine;
using System.Collections;

public class PillTextureGenerator {
	
	private static Color[] MainColors = new Color[]
	{
		Color.blue,
		Color.cyan,		
		Color.magenta,
		Color.red,
		Color.yellow,		
		Color.gray,
		new Color(239f/255, 211f/255, 52f/255),
		new Color(255f/255, 215f/255, 0),
		new Color(255f/255, 117f/255, 24f/255),
		new Color(220f/255, 20f/255, 60f/255),
		new Color(31f/255, 174f/255, 233f/255),
		new Color(102f/255, 0, 153f/255),
		new Color(127f/255, 199f/255, 255f/255),
		new Color(11f/255, 218f/255, 81f/255),
		new Color(23f/255, 114f/255, 69f/255),
		new Color(173f/255, 255f/255, 47f/255),
		new Color(204f/255, 255f/255, 0),
	};	
		
	public static Texture2D Generate(int width, int height)
	{
		var mainColor = GetRandomColor(MainColors);
		var secondColor = Color.white;
		
		var texture = new Texture2D(width, height);
	    for(int x = 0; x < width; x++) 
		{
	    	for(int y = 0; y < height; y++) 
			{
	        	var color = y < height/2 ? mainColor : secondColor;
              	texture.SetPixel(x, y, color);
			}
      	}
		texture.Apply();			
		
		return texture;
	}
	
	private static Color GetRandomColor(Color[] colors)
	{
		return colors[Random.Range(0, colors.Length)];
	}
}
