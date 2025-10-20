using Godot;
using System;

public partial class SpeedLabel : Label {
	RigidBody3D player;
	public override void _Ready() {
		player = GetParent<Node3D>().GetChild<RigidBody3D>(0);
	}
	
	public override void _Process(double delta) {
		Text = $"speed : {player.LinearVelocity.Length():F0}";
	}
}