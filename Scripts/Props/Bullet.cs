using Godot;
using System;

public partial class Bullet : CharacterBody2D
{
	private short velocity;
	private byte damage;
	private bool playerOrigin;
	private Area2D area;
	
	public void initiate(byte damage, bool playerOrigin)
	{
		this.damage = damage;
		this.playerOrigin = playerOrigin;
	}

	public override void _Ready()
	{
		this.velocity = 900;
		
		if (!this.playerOrigin)
		{
			this.velocity /= -2;
			GetNode<Sprite2D>("BulletSprite").RotationDegrees = 180;
		}
		
		this.area = GetNode<Area2D>("BulletArea");
	}

	public override void _PhysicsProcess(double delta)
	{
		Position -= Transform.Y * (float)velocity * (float)delta;
	}
	
	public void _OnBodyEntered(CharacterBody2D body)
	{
		if (body is Enemy && this.playerOrigin)
		{
			body.EmitSignal(Enemy.SignalName.takeDamage, this.damage);
			QueueFree();
		} else if (body is Player && !this.playerOrigin)
		{
			body.EmitSignal(Player.SignalName.takeDamage, this.damage);
			QueueFree();
		}
	}
}
