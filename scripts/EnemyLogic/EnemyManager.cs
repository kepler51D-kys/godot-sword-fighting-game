using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class EnemyManager : Node3D
{
	PackedScene enemyTemplate = GD.Load<PackedScene>("res://scenes/enemy.tscn");
	
	List<Node> enemies = [];
	
	public CharacterBody3D player;
	
	public override void _Ready()
	{
		SpawnEnemy();
		
		Control healthbar = enemies[enemies.Count-1].GetNode<Control>("Health Bar");
		if (healthbar is HealthBar script) {
			script.init();
		}
	}

	public override void _Process(double delta)
	{
	}

	public void SpawnEnemy() {
		Node temp = enemyTemplate.Instantiate();
		AddChild(temp);
		temp.AddToGroup("enemies");
		enemies.Add(temp);
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
