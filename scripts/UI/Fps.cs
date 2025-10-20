using Godot;
using System;

public partial class Fps : Label
{
	public override void _Process(double delta) {
        double fps = Settings.Instance.timeslowed ? delta*Settings.Instance.sloSpeed : delta;
        Text = $"fps : {1/fps:F0}";
	}
}
