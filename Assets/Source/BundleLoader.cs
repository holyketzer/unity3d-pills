using System;
using UnityEngine;
using System.Collections; 

class BundleLoader : MonoBehaviour 
{  		
	public static object Load(string url) 
	{
	   // Download the file from the URL. It will not be saved in the Cache
	   using (WWW www = new WWW(url)) 
		{		   
		   	if (www.error != null)
			{
				throw new Exception("WWW download had an error:" + www.error);
			}
			
		   	AssetBundle bundle = www.assetBundle;
		  	return bundle.mainAsset;		   		
	   }
   }
}