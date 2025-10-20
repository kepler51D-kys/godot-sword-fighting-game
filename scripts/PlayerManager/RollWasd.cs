using Godot;
using System;

public partial class Player {
	public Vector3 GetForce(Vector2 inputDirection) {
		Vector3 forward = camera.GlobalTransform.Basis.X.Normalized();
		Vector3 right = -camera.GlobalTransform.Basis.Z.Normalized();
		return forward * inputDirection.Y * Speed + right * inputDirection.X * Speed;
	}
	public Vector2 GetInput() {
        return new Vector2(
            Input.GetActionStrength("right") - Input.GetActionStrength("left"),
            Input.GetActionStrength("backward") - Input.GetActionStrength("forward")
        ).Normalized();
    }
    public void JumpManage() {
		if (Input.IsActionPressed("jump") && floorDetect.IsColliding()) {
			child.ApplyCentralForce(new Vector3(0,JumpVelocity,0));
			canJump = false;
			var timer = new Timer();
			AddChild(timer);
			timer.WaitTime = Settings.Instance.timeslowed ? 0.1f*Settings.Instance.sloSpeed : 0.1f;
			timer.OneShot = true;
			timer.ProcessMode = Timer.ProcessModeEnum.Always;
			timer.Timeout += () => {
				canJump = true;
			};
			timer.Start();
		}
	}
	public void TimeSlowManage() {
		if (Input.IsActionJustPressed("time slow")) {
			Settings.Instance.timeslowed = !Settings.Instance.timeslowed;
		}
		if (Settings.Instance.timeslowed) {
			Engine.TimeScale = Settings.Instance.sloSpeed;
		}
		else {
			Engine.TimeScale = 1f;
		}
	}
}
