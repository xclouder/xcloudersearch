using System;
using System.Collections;

public class SearchTrigger {

	System.Timers.Timer timer;
	
	public SearchTrigger (float delay = 0.8f)
	{
		timer = new System.Timers.Timer(delay * 1000f);
		timer.AutoReset = false;
		timer.Elapsed += new System.Timers.ElapsedEventHandler(DoTrigger);
		timer.Stop();
	}

	~SearchTrigger()
	{
		if (timer != null)
			timer.Dispose();
	}

	public void Update()
	{
		if (timer.Enabled)
		{
			timer.Stop();
		}

		timer.Start();
	}

	private void DoTrigger(object sender, System.Timers.ElapsedEventArgs e) {
		UnityEngine.Debug.Log("trigger");

		if (onSearchTrigger != null)
		{
			onSearchTrigger();
		}

		timer.Stop();
	}

	public delegate void OnSearchTrigger();
	public event OnSearchTrigger onSearchTrigger;
}