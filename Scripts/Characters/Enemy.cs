using Godot;
using System;

public partial class Enemy : Character
{
	private const byte points = 250;
	private PackedScene bulletScene;
	private Node currentScene;
	private float xSpeed;
	private float ySpeed;
	private float sprite_width;
	
	public override void _Ready()
	{
		Random rand = new Random();
		
		this.health = 1;
		this.attackPower = 1;
		this.bulletScene = GD.Load<PackedScene>("res://Entities/bullet_entity.tscn");
		this.currentScene = GetTree().CurrentScene;
		this.xSpeed = rand.Next(40, 80) * -1f;
		this.ySpeed = 10f;
	}
	
	public void _TakeDamage(byte damage)
	{
		this.health -= damage;
		if (this.health == 0)
		{
			this.currentScene.EmitSignal(Stage.SignalName.addPoints, points);
			QueueFree();
		}
	}
	
	public void Shoot()
	{
		Bullet bullet = bulletScene.Instantiate<Bullet>();
		bullet.initiate(attackPower, false);
		bullet.GlobalPosition = GlobalPosition;
		GetTree().CurrentScene.AddChild(bullet);
	}
	
	private void TurnDirection()
	{
		if (Position.X <= 13 || Position.X >= 209) {
			this.xSpeed *= -1f;
		}
	}
	
	public override void _PhysicsProcess(double delta)
	{
		this.Position += Transform.X * xSpeed * (float)delta;
		this.Position += Transform.Y * ySpeed * (float)delta;
		this.TurnDirection();
	}
}
