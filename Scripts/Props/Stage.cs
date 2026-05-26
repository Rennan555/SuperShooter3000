using Godot;
using System;

public partial class Stage : Node2D
{
	[Signal]
	public delegate void addPointsEventHandler(ushort extraPoints);
	
	private ushort points = 0; // 0 a 65.535
	private PackedScene enemyScene;
	
	public override void _Ready()
	{
		this.enemyScene = GD.Load<PackedScene>("res://Entities/enemy_entity.tscn");
	}
	
	public void _SpawnEnemy()
	{
		Random rand = new Random();
		int xPosition = rand.Next(33,220);
		int yPosition = -30;
		
		Enemy newEnemy = enemyScene.Instantiate<Enemy>();
		newEnemy.GlobalPosition = new Vector2(xPosition,yPosition);
		
		GetTree().CurrentScene.AddChild(newEnemy);
	}
	
	public ushort getPoints()
	{
		return this.points;
	}
	
	public void _AddPoints(ushort extraPoints)
	{
		if (this.points >= 65535 - extraPoints)
		{
			OS.Crash("yeah");
		}
		else
		{
			this.points += extraPoints;
		}
		GD.Print("Pontos: ", this.points);
	}
}
