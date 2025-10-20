using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class SwordManager
{

	public List<Node3D> GetEnemiesInRange() {
		List<Node3D> temp = attackBox.GetOverlappingBodies().ToList();
		List<Node3D> result = new(temp.Count);
		foreach (Node3D node in temp) {
			if (node.IsInGroup("enemies")) {
				result.Add(node);
			}
		}
		return result;
	}
	public bool EnemyIsInRange() {
		return GetEnemiesInRange().Count > 0;
	}
}
