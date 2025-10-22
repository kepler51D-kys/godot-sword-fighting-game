using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class EnemyManager : Node3D
{
	PackedScene enemyTemplate = GD.Load<PackedScene>("res://scenes/enemy.tscn");
	
	public List<Node> enemies = [];
	
	public CharacterBody3D player;
	
	public override void _Ready()
	{
		// SpawnEnemy();
		
		HealthBar healthBar = Settings.Instance.enemyHealthBar as HealthBar;
		// if (healthbar is HealthBar script) {
		healthBar.init(SpawnEnemy());
		// }
	}

	public override void _Process(double delta)
	{
	}

	public Enemy SpawnEnemy() {
		Node temp = enemyTemplate.Instantiate();
		AddChild(temp);
		temp.AddToGroup("enemies");
        enemies.Add(temp);
        return temp as Enemy;
	}
}

public class GraphNode {
	public worldState nodeState;
	public List<GraphNode> To;

	public GraphNode(worldState world) {
		nodeState = world;
	}
}
public class Graph {
	List<GraphNode> nodes;

	void addNode(worldState world, GraphNode From) {
		GraphNode existingNode = nodes.FirstOrDefault(item => item.nodeState.data == world.data);
		if (existingNode != null) {
			From.To.Add(existingNode);
		}
		else {
			GraphNode newNode = new(world);
			nodes.Add(newNode);
			From.To.Add(newNode);
		}
	}
	public Graph() {
		nodes = [];
	}

}
