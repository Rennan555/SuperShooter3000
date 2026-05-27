using Godot;
using System;

public partial class Stage : Node2D
{
	[Signal]
	public delegate void addPointsEventHandler(ushort extraPoints);
	
	[Signal]
	public delegate void playerDamageEventHandler(byte damage);
	
	private ushort points = 0; // 0 a 65.535
	private byte lives;
	private byte difficultyLevel;
	
	private PackedScene enemyScene;
	private Player player;
	
	private Label livesLabel;
	private Label levelLabel;
	private Label pointsLabel;
	private Label gameOverLabel;
	
	public override void _Ready()
	{
		this.enemyScene = GD.Load<PackedScene>("res://Entities/enemy_entity.tscn");
		this.player = GetNode<Player>("Player");
		this.lives = player.getHealth();
		this.livesLabel = GetNode<Label>("CanvasLayer/LivesLabel");
		this.levelLabel = GetNode<Label>("CanvasLayer/LevelLabel");
		this.pointsLabel = GetNode<Label>("CanvasLayer/PointsLabel");
		this.gameOverLabel = GetNode<Label>("CanvasLayer/GameOverLabel");
	}
	
	public void _SpawnEnemy()
	{
		Random rand = new Random();
		int xPosition = rand.Next(33,210);
		int yPosition = -30;
		
		Enemy newEnemy = enemyScene.Instantiate<Enemy>();
		newEnemy.initiate(this.difficultyLevel);
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
		
		this.difficultyLevel = (byte)(this.points / 5000);
		this.levelLabel.Text = "Level: " + (this.difficultyLevel + 1);
		
		pointsLabel.Text = "Pontos: " + this.points;
	}
	
	public void _PlayerDamage(byte damage)
	{
		this.lives -= damage;
		this.livesLabel.Text = "Vida: " + this.lives;
		
		if (this.lives <= 0)
		{
			this.gameOverLabel.Visible = true;
		}
	}
}
