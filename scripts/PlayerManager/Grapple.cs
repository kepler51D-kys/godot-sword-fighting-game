using Godot;
using System;

public partial class Player
{
	[Export] float pullStrength;
	public Vector3 target;
	[Export] CollisionObject3D except;
	MeshInstance3D targetDisplay;
	[Export] float steerStrength;
	float distanceLock = 0;
	Node3D parent;
    RayCast3D raycast;

    public void GetTarget() {
		target = raycast.GetCollisionPoint();
		targetDisplay.GlobalPosition = target;
	}
	public void GrappleInit() {
        raycast = GetChild<Node3D>(1).GetChild<Camera3D>(0).GetChild<RayCast3D>(1);

        targetDisplay = GetChild<MeshInstance3D>(3);
		parent = GetParent<Node3D>();
		raycast.AddException(except);
		raycast.TargetPosition = new Vector3(0,0,-500);
	}
	public void GrappleManage(double delta) {
		// targetDisplay.GlobalPosition = target;
		if (Input.IsActionPressed("grapple")) {
			Vector3 targetDir = target-child.Position;
            float len = targetDir.Length();
            targetDir = (
                -RigidPair.GlobalTransform.Basis.Z.Normalized() * steerStrength +
                targetDir.Normalized()*pullStrength
            );
            GD.Print(targetDir);
            child.ApplyCentralForce(targetDir*1000*(float)delta);
		}
		if (Input.IsActionJustPressed("grapple")) {
			GetTarget();
			distanceLock = (target - child.Position).Length();
		}
	}
}
