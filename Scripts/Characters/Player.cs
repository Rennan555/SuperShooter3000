using Godot;
using System;

public partial class Player : Character
{
	private PackedScene bulletScene;
	private Node currentScene;
	private Timer cooldownTimer;
	private bool canShoot = true;
	
	public override void _Ready()
	{
		this.health = 3;
		this.attackPower = 1;
		this.currentScene = GetTree().CurrentScene;
		this.cooldownTimer = GetNode<Timer>("CooldownTimer");
		
		bulletScene = GD.Load<PackedScene>("res://Entities/bullet_entity.tscn");
	}
	
	public byte getHealth()
	{
		return this.health;
	}
	
	public void TakeDamage(byte damage)
	{
		this.health -= damage;
		this.currentScene.EmitSignal(Stage.SignalName.playerDamage, damage);
		
		if (this.health <= 0)
		{
			QueueFree();
		}
	}
	
	public void _EnableShoot()
	{
		this.canShoot = true;
	}
	
	public override void _Input(InputEvent @event)
	{
		if (Input.IsActionPressed("Shoot") && this.canShoot)
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
			
			this.canShoot = false;
			this.cooldownTimer.Start();
		}
	}
}
