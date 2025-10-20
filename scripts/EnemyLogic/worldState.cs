using Godot;
using System;

public struct worldState {
	public UInt32 data;
	playerHealth player {
		get {
			return (playerHealth)(data & 0b11);
		}
		set {
			data &= 0xFFFFFFFC;
			data |= (UInt32)value;
		}
	}

	enemyHealth enemy1 {
		get {
			return (enemyHealth)(data & 0b1100);
		}
		set {
			data &= 0xFFFFFFF3;
			data |= (UInt32)value << 2;
		}
	}
	enemyHealth enemy2 {
		get {
			return (enemyHealth)(data & 0b110000);
		}
		set {
			data &= 0xFFFFFFCF;
			data |= (UInt32)value << 4;
		}
	}
	enemyHealth enemy3 {
		get {
			return (enemyHealth)(data & 0b11000000);
		}
		set {
			data &= 0xFFFFFF3F;
			data |= (UInt32)value << 6;
		}
	}
	rangeFromPlayer range1 {
		get {
			return (rangeFromPlayer)(data & 0b1100000000);
		}
		set {
			data &= 0xFFFFFCFF;
			data |= (UInt32)value << 8;
		}
	}
	rangeFromPlayer range2 {
		get {
			return (rangeFromPlayer)(data & 0b110000000000);
		}
		set {
			data &= 0xFFFFF3FF;
			data |= (UInt32)value << 10;
		}
	}
	rangeFromPlayer range3 {
		get {
			return (rangeFromPlayer)(data & 0b11000000000000);
		}
		set {
			data &= 0xFFFFCFFF;
			data |= (UInt32)value << 12;
		}
	}
	attackMove lastmove1 {
		get {
			return (attackMove)(data & 0b1100000000000000);
		}
		set {
			data &= 0xFFFF3FFF;
			data |= (UInt32)value << 14;
		}
	}
	attackMove lastmove2 {
		get {
			return (attackMove)(data & 0b110000000000000000);
		}
		set {
			data &= 0xFFFCFFFF;
			data |= (UInt32)value << 16;
		}
	}
	attackMove lastmove3 {
		get {
			return (attackMove)(data & 0b11000000000000000000);
		}
		set {
			data &= 0xFFF3FFFF;
			data |= (UInt32)value << 18;
		}
	}
}

public enum playerHealth {
	high,
	medium,
	low,
	dead,
}
public enum enemyHealth {
	high,
	medium,
	low,
	dead,
}
public enum rangeFromPlayer {
	far,
	medium,
	close,
	dead,
}
public enum attackMove {
	attackFront,
	attackBack,
	attackSide,
	retreat
}
