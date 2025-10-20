using Godot;

public partial class customTimer : Node {
    [Export] public float time;
    public float timeLeft;
    public override void _Ready() {
        
    }
    public override void _PhysicsProcess(double delta) {
        
        timeLeft -= (float)delta;
    }
}