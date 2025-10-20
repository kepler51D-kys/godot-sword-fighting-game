using Godot;
using System;

public partial class timeSlowLeft : ProgressBar
{
	[Export] float timeSlowMax = 5f;
	public float timeSlowTimer = 0f;
	public override void _Ready() {
	}
	
	public override void _Process(double delta) {
		if (Settings.Instance.timeslowed) {
			timeSlowTimer += (float)delta/Settings.Instance.sloSpeed/2;
		}
		else {
			timeSlowTimer -= (float)delta;
		}
		if (timeSlowTimer >= timeSlowMax) {
			Settings.Instance.timeslowed = false;
		}
		timeSlowTimer = Mathf.Max(0f,timeSlowTimer);
		timeSlowTimer = Mathf.Min(timeSlowMax,timeSlowTimer);
		Value = timeSlowTimer*100/timeSlowMax;
	}
}
