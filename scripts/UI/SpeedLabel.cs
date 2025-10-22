using Godot;
using System;

public partial class SpeedLabel : Label {
	public override void _Ready() {
	}
	
	public override void _Process(double delta) {
		Text = $"speed : {Settings.Instance.playerBody.LinearVelocity.Length():F0}";
	}
}