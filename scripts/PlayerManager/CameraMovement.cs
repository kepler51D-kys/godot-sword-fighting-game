using Godot;
using System;

public partial class Player
{
	Node3D RigidPair;

	[Export] float horiSpeed;
	[Export] float vertSpeed;
	[Export] float speedMult;
	Vector2 mouseDelta;
	Vector2 size;
	float verticalRotation = 0f;
	bool mouseVisible = false;
	
	public void CameraInit() {
		ProcessMode = ProcessModeEnum.Always;
		RigidPair = GetChild<Node3D>(1);
		// sibling = parent.GetParent<Node3D>().GetChild<RigidBody3D>(0);
		
		Input.SetMouseMode(Input.MouseModeEnum.Captured);
		Viewport screen = GetViewport();
		size = screen.GetVisibleRect().Size;
		Input.WarpMouse(size/2);
	}

	public void CameraManage(double delta) {
        RigidPair.Position = child.Position;
        if (Input.IsActionJustPressed("escape")) {
			//GetTree().Paused = true;
			if (mouseVisible) {
				Input.SetMouseMode(Input.MouseModeEnum.Captured);
				Input.WarpMouse(size/2);
			}
			else {
				Input.SetMouseMode(Input.MouseModeEnum.Visible);
			}
			mouseVisible = !mouseVisible;
		}
		if (mouseDelta != Vector2.Zero && !mouseVisible) {
			RigidPair.RotateY(-mouseDelta.X * horiSpeed * speedMult * (float)delta);
            verticalRotation = Mathf.Clamp(verticalRotation - mouseDelta.Y * vertSpeed * speedMult * (float)delta, -Mathf.Pi/2, Mathf.Pi/2);
			camera.Rotation = new Vector3(verticalRotation, 0, 0);
		}
		mouseDelta = Vector2.Zero;
	}
	public override void _Input(InputEvent @event) {
		if (@event is InputEventMouseMotion mouseMotion) {
			mouseDelta = mouseMotion.Relative;
		}
	}
}
