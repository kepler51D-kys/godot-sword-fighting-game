using Godot;

public partial class Settings : Node3D {
    public static Settings _instance;
    public bool isTimestopped = false;
    public bool timeslowed = false;
    [Export] public float sloSpeed = 0.2f;
    public Player player;
    public SwordManager swordManager;
    public EnemyManager enemyManager;
    [Export] public ProgressBar enemyHealthBar;
    [Export] public ProgressBar TimeSlowBar;
    [Export] public Label chargeLabel;
    [Export] public Label fpsLabel;
    [Export] public Label speedLabel;
    public RigidBody3D playerBody;
    public static Settings Instance {
        get {
            return _instance;
        }
    }
    public Settings() {
        _instance = this;
    }
    public override void _Ready() {
        // DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
    }
}
public class UserInterface {
    public ProgressBar enemyHealthBar;
    public ProgressBar TimeSlowBar;
    public Label chargeLabel;
    public Label fpsLabel;
    public Label speedLabel;
}