using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class SwordManager
{
	void CheckHeavyAttack(double delta) {
		if (Input.IsActionPressed("heavy attack") && canHeavyAttack) {
			chargeTime += (float)delta;
		}
		if (Input.IsActionJustReleased("heavy attack")) {
			if (canHeavyAttack && enemies.Count > 0) {
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
                canHeavyAttack = false;
            }
            else {
                // punish player for missing heavy attack
            }
			chargeTime = 2;

            var cooldownTimer = new Timer();
            AddChild(cooldownTimer);

            cooldownTimer.WaitTime = heavyAttackCooldown;
            
            cooldownTimer.OneShot = true;
            cooldownTimer.Timeout += () => {
                canHeavyAttack = true;
            };
            cooldownTimer.Start();
		}
	}
	void CheckLightAttack(double delta) {
		enemies = GetEnemiesInRange();
		if (Input.IsActionJustPressed("light attack") && canLightAttack && enemies.Count > 0) {
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
            canLightAttack = false;
            var cooldownTimer = new Timer();
            AddChild(cooldownTimer);

            cooldownTimer.WaitTime = lightAttackLen;

            cooldownTimer.OneShot = true;
            cooldownTimer.Timeout += () => {
                canLightAttack = true;
            };
            cooldownTimer.Start();
		}
	}
}
