using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class SwordManager : Node3D
{
	[Export] float lightAttackDmg = 5f;
    [Export] float lightAttackLen = 0.1f;
    [Export] float heavyAttackDmg = 5f;
    [Export] float heavyAttackCooldown = 2f;
	public float timestopDurationLightAttack = 0.25f;
	public float timestopDurationHeavyAttack = 0.75f;
	bool canAttack = true;
    bool cooldown = false;
    [Export] Area3D attackBox;
	[Export] RigidBody3D body;
	public float chargeTime = 2;
    List<Node3D> enemies;

    public override void _Ready() {
        Settings.Instance.swordManager = this;
        ProcessMode = Timer.ProcessModeEnum.Always;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta) {
		enemies = GetEnemiesInRange();
        CheckHeavyAttack(delta);
        CheckLightAttack(delta);
        // GD.Print(canAttack, cooldown, enemies.Count);
    }
}
