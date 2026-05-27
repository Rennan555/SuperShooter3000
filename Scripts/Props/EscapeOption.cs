using Godot;
using System;

[GlobalClass]
public partial class EscapeOption : Node
{
	public override void _Process(double delta)
	{
		if (Input.IsActionPressed("Escape")) GetTree().Quit();
	}
}
