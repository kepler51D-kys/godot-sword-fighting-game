using Godot;
using System;

public partial class ChargeLabel : ProgressBar
{
	// SwordManager sword;
	public override void _Ready() {
		// sword = Settings.Instance.swordManager;
	}
	public override void _Process(double delta) {
        // Text = $"charge time : {Math.Log(sword.chargeTime,2)-1:F1}";
        Value = Math.Log(Settings.Instance.swordManager.chargeTime, 2)-2;
        Value *= 20;
    }
}
