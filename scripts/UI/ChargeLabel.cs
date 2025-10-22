using Godot;
using System;

public partial class ChargeLabel : Label
{
	SwordManager sword;
	public override void _Ready() {
		sword = Settings.Instance.swordManager;
	}
	public override void _Process(double delta) {
		Text = $"charge time : {Math.Log(sword.chargeTime,2)-1:F1}";
	}
}
