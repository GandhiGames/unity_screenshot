using UnityEngine;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

public class Screenshot : MonoBehaviour
{
	public int SuperSize = 1;

	public string path = "your_path_here";

	private string ScreenShotName ()
	{
		return string.Format ("/screenshot_{0}.png", 
		                     System.DateTime.Now.ToString ("yyyy-MM-dd_HH-mm-ss"));
	}
	
	private string Directory ()
	{
		return string.Format ("{0}{1}", path,
		                      Regex.Replace (Application.productName.ToString ().Trim (), "( )+", ""));
	}

	void LateUpdate ()
	{
		if (Input.GetKeyDown ("k")) {
			
			if (!System.IO.Directory.Exists (Directory ())) {
				System.IO.Directory.CreateDirectory (Directory ());
				Debug.Log ("Directory created: " + Directory ());
			}
			
			Application.CaptureScreenshot (Directory () + ScreenShotName (), SuperSize);
			Debug.Log ("Screenshot saved to: " + Directory () + ScreenShotName ());

		}
	}

}
