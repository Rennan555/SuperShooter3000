using Godot;
using System;

public partial class Enemy : Character
{
	private const byte points = 250;
	private PackedScene bulletScene;
	private Node current_scene;
	private float x_speed;
	private float y_speed;
	private float sprite_width;
	
	public override void _Ready()
	{
		this.health = 1;
		this.attackPower = 1;
		this.bulletScene = GD.Load<PackedScene>("res://Entities/bullet_entity.tscn");
		this.current_scene = GetTree().CurrentScene;
		this.x_speed = -60f;
		this.y_speed = 10f;
	}
	
	public void _TakeDamage(byte damage)
	{
		this.health -= damage;
		if (this.health == 0) QueueFree();
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
		if (Position.X == 13 || Position.X == 209) this.x_speed *= -1f;
	}
	
	public override void _PhysicsProcess(double delta)
	{
		this.Position += Transform.X * x_speed * (float)delta;
		this.Position += Transform.Y * y_speed * (float)delta;
		this.TurnDirection();
	}
}
