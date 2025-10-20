using Godot;
using System;

public partial class Player : Node3D {
	private RigidBody3D child;
	private Vector2 inputDirection;
	// [Export] public float sloSpeed;
	[Export] RayCast3D floorDetect;
	[Export] Camera3D camera;

	// public bool timeslowed = false;
	public bool canJump = true;
	[Export] float Speed;
	[Export] float JumpVelocity;
	[Export] float gravity;

	public override void _Ready() {
        GrappleInit();
        CameraInit();
        child = GetChild<RigidBody3D>(0);
		// camera = GetChild<Node3D>(1).GetChild<Camera3D>(0);
		// floorDetect = GetChild<Node3D>(1).GetChild<RayCast3D>(2);
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
