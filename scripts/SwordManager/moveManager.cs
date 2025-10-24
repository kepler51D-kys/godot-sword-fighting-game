using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class SwordManager
{
	void CheckHeavyAttack(double delta) {
		if (Input.IsActionPressed("heavy attack") && canAttack && !cooldown) {
			chargeTime += (float)delta * chargeSpeed;
		}
		if (Input.IsActionJustReleased("heavy attack")) {
			if (canAttack && enemies.Count > 0) {
				ScreenFlash();
				ActivateTimestop(timestopDurationHeavyAttack);
				foreach (Node3D enemy in enemies) {
					if (enemy is Enemy enemyscript) {
						float speed = body.LinearVelocity.Length();
						speed = Mathf.Max(1f,speed);
						speed *= speed;
						speed /= 100;
						enemyscript.receiveDamage(heavyAttackDmg*speed*(float)(Math.Log(chargeTime,2f)-1));
					}
				}
            }
            else {
                // punish player for missing heavy attack
            }
			chargeTime = 2;

            cooldown = true;
            var cooldownTimer = new Timer();
            AddChild(cooldownTimer);

            cooldownTimer.WaitTime = heavyAttackCooldown;
            cooldownTimer.ProcessMode = ProcessModeEnum.Pausable;
            cooldownTimer.OneShot = true;
            cooldownTimer.Timeout += () => {
                cooldown = false;
            };
            cooldownTimer.Start();
		}
	}
	void CheckLightAttack(double delta) {
        if (Input.IsActionJustPressed("light attack") && canAttack && enemies.Count > 0 && !cooldown) {
			ScreenFlash();
			ActivateTimestop(timestopDurationLightAttack);
			foreach (Node3D enemy in enemies) {
				if (enemy is Enemy enemyscript) {
					float speed = body.LinearVelocity.Length();
					speed = Mathf.Max(1f,speed);
					speed *= speed;
					speed /= 100;
					enemyscript.receiveDamage(lightAttackDmg*speed);
				}
			}
            cooldown = true;
            var cooldownTimer = new Timer();
            AddChild(cooldownTimer);

            cooldownTimer.WaitTime = lightAttackLen;
            cooldownTimer.ProcessMode = ProcessModeEnum.Pausable;
            cooldownTimer.OneShot = true;
            cooldownTimer.Timeout += () => {
                cooldown = false;
            };
            cooldownTimer.Start();
		}
	}
}
