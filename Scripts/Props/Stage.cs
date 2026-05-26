using Godot;
using System;

public partial class Stage : Node2D
{
	[Signal]
	public delegate void addPointsEventHandler(ushort extraPoints);
	
	private ushort points; // 0 a 65.535
	
	public ushort getPoints()
	{
		return this.points;
	}
	
	public void _AddPoints(ushort extraPoints)
	{
		this.points += extraPoints;
		GD.Print("Pontos: ", this.points);
	}
}
