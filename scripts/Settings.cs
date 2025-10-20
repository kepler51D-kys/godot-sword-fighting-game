using Godot;

public class Settings {
    public static Settings _instance;
    public bool isTimestopped = false;
    public bool timeslowed = false;
    [Export] public float sloSpeed = 0.2f;
    public Player player;
    public RigidBody3D playerBody;
    public static Settings Instance {
        get {
            if (_instance == null) {
                _instance = new Settings();
            }
            return _instance;
        }
    }
}