using Godot;
using System;

public partial class Player : Node3D {
	private RigidBody3D child;
	private Vector2 inputDirection;
	[Export] RayCast3D floorDetect;
	[Export] Camera3D camera;

	public bool canJump = true;
	[Export] float Speed;
	[Export] float JumpVelocity;
	[Export] float gravity;

	public override void _Ready() {
        child = GetChild<RigidBody3D>(0);
        Settings.Instance.player = this;
        Settings.Instance.playerBody = child;
	    GrappleInit();
        CameraInit();
		floorDetect.TargetPosition = new Vector3(0,-1.5f,0);
		inputDirection = Vector2.Zero;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		child.ApplyTorque(GetForce(GetInput()));
        JumpManage();
        TimeSlowManage();
        GrappleManage(delta);
        CameraManage(delta);
    }
}
