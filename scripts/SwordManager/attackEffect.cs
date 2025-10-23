using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class SwordManager
{
	public void ScreenFlash() {
		ColorRect flashOverlay = new()
		{
			Size = GetViewport().GetVisibleRect().Size,
			Color = new Color(1, 1, 1, 0.7f)
		};

		AddChild(flashOverlay);
		
		var timer = new Timer();
		AddChild(timer);
		timer.WaitTime = Settings.Instance.timeslowed ? 0.05f*Settings.Instance.sloSpeed : 0.05f;
		timer.OneShot = true;
		timer.ProcessMode = Timer.ProcessModeEnum.Always;
		timer.Timeout += () => {
			flashOverlay.QueueFree();
		};
		timer.Start();
	}
	
	public void ActivateTimestop(float time) {
		canAttack = false;
        if (Settings.Instance.isTimestopped) {
			return;
		}

		Settings.Instance.isTimestopped = true;
		
		GetTree().Paused = true;

		var resumeTimer = new Timer();
		AddChild(resumeTimer);
		
		//resumeTimer.WaitTime = time;
		resumeTimer.WaitTime = Settings.Instance.timeslowed ? time*Settings.Instance.sloSpeed : time;
		
		resumeTimer.ProcessMode = Timer.ProcessModeEnum.Always;
		resumeTimer.OneShot = true;
		resumeTimer.Timeout += () => {
			GetTree().Paused = false;
			Settings.Instance.isTimestopped = false;
		};
		resumeTimer.Start();
        canAttack = true;
    }
}
