using Godot;
using System;

public partial class Enemy : Node3D
{
	EnemyManager manager;
	Label3D label;
	public Node3D player;

	[Export] public float maxHealth;
	public float health;

	public override void _Ready()
	{
		label = GetChild<Label3D>(0);
		health = maxHealth;
		player = GetParent<Node3D>().GetChild<Node3D>(0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		float healthProport = health/maxHealth;
		
	}
	public void receiveDamage(float dmg) {
		health -= dmg;
		if (health <= 0) {
			QueueFree();
		}
		label.Text = $"{dmg:F0}";
	}
}
public class StateMachine {
	public healthState Health;
	public attackState AttackState;
	public attackState EnemyAttackState;
    public speedState SpeedState;
    public speedState EnemySpeedState;

    public StateMachine() {
        Health = healthState.high;
        AttackState = attackState.idle;
        EnemyAttackState = attackState.idle;
        SpeedState = speedState.stationary;
        EnemySpeedState = speedState.stationary;
    }
	public void process() {
        bool enemyAttacking = EnemyAttackState != attackState.idle;
        bool inCurrentDanger = EnemySpeedState > speedState.medium ||
				(enemyAttacking && EnemySpeedState > speedState.slow);
		
    }
}
public enum healthState {
	high, // above 0.75
	medium, // above 0.5
	low, // above 0.25
	veryLow, // below 0.25
}
public enum attackState {
	lightAttack,
	heavyAttack,
	parry,
	idle,
}
public enum speedState {
	fast, // more than 300
	medium, // more than 200
	slow, // more than 100
	stationary // less than 100
}
