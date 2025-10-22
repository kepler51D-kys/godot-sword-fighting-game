using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class HealthBar : ProgressBar {
	[Export] private float width = 400f;
	[Export] private float height = 20f;
	public Enemy boss;
	public bool initialised = false;
	
	public void init(Enemy attach) {
        boss = attach;
        initialised = true;
	}
	
	// public override void _Ready() {
    // }
	
	public override void _Process(double delta) {
		if (initialised) {
			if (boss == null || !IsInstanceValid(boss))
			{
				QueueFree();
				return;
			}
			
			if (boss.maxHealth <= 0 || float.IsNaN(boss.health) || float.IsInfinity(boss.health))
			{
				GD.PrintErr("HealthBar: Invalid health values!");
				return;
			}
			
			float healthRatio = Mathf.Clamp(boss.health / boss.maxHealth, 0f, 1f);
			Value = healthRatio*100;
		}
	}
}
