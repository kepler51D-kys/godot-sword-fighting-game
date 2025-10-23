// using System;
// using Godot;

// public partial class CustomTimer : Node {
//     public float timeLeft;
//     public CustomTimer(float timeInput) {
//         // time = timeInput;
//         timeLeft = timeInput;
//     }
//     public override void _Ready() {
        
//     }
//     public override void _PhysicsProcess(double delta, Func<void> del) {
//         if (Settings.Instance.timeslowed) {
//             timeLeft -= (float)delta * Settings.Instance.sloSpeed;
//         }
//         else if (Settings.Instance.isTimestopped) {
//             timeLeft -= (float)delta;
//         }
//         if (timeLeft <= 0) {

//         }
//     }
// }