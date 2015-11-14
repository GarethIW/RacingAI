    var deltaTime = 0.0f;
	
function Update()
	{
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
	}
 
function OnGUI()
	{
		var w = Screen.width;
		var h = Screen.height;
 
		var style = new GUIStyle();
 
		var rect = new Rect(20, 20, w, h * 2 / 100);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * 2 / 100;
		var msec = deltaTime * 1000.0f;
		var fps = 1.0f / deltaTime;
		var timeValue = Time.deltaTime;
if (fps < 10 )
{
		style.normal.textColor = new Color (1.0f, 0.0f, 0.0f, 1.0f);
}
else 
	if(fps < 30)
	{
			style.normal.textColor = new Color (1.0f, 0.92f, 0.016f, 1.0f);
	}
	else
	{
			style.normal.textColor = new Color (0.0f, 1.0f, 0.0f, 1.0f);

	}
		
if ( timeValue == 0 )
		{
			style.normal.textColor = new Color (0.0f, 0.0f, 0.0f, 0.0f);
		};
		
		var text = String.Format("{0:0.0} fps ({1:0.0} ms)", fps, msec);
		GUI.Label(rect, text, style);
	}