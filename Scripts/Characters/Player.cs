using Godot;
using System;

public partial class Player : Character
{
	private PackedScene bulletScene;
	
	public override void _Ready()
	{
		this.health = 3;
		this.attackPower = 1;
		
		bulletScene = GD.Load<PackedScene>("res://Entities/bullet_entity.tscn");
	}
	
	public void TakeDamage(byte damage)
	{
		this.health -= damage;
		GD.Print("Tomei: ", this.health);
		if (this.health <= 0)
		{
			QueueFree();
		}
	}
	
	public override void _Input(InputEvent @event)
	{
		if (Input.IsActionPressed("Shoot"))
		{
			Bullet bullet1 = bulletScene.Instantiate<Bullet>();
			Bullet bullet2 = bulletScene.Instantiate<Bullet>();
			Bullet bullet3 = bulletScene.Instantiate<Bullet>();
			Bullet bullet4 = bulletScene.Instantiate<Bullet>();
			
			bullet2.initiate(this.attackPower, true);
			bullet3.initiate(this.attackPower, true);
			bullet4.initiate(this.attackPower, true);
			bullet1.initiate(this.attackPower, true);
			
			bullet1.GlobalPosition = GlobalPosition;
			bullet2.GlobalPosition = GlobalPosition;
			bullet3.GlobalPosition = GlobalPosition;
			bullet4.GlobalPosition = GlobalPosition;
			
			bullet1.GlobalPosition += new Vector2(21,-7);
			bullet2.GlobalPosition += new Vector2(-13,-9);
			bullet3.GlobalPosition += new Vector2(13,-9);
			bullet4.GlobalPosition += new Vector2(-21,-7);
			
			GetTree().CurrentScene.AddChild(bullet1);
			GetTree().CurrentScene.AddChild(bullet2);
			GetTree().CurrentScene.AddChild(bullet3);
			GetTree().CurrentScene.AddChild(bullet4);
		}
	}
}
