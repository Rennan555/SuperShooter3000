using Godot;
using System;

[GlobalClass]
public partial class ControllerComponent : Component
{
	[Export]
	private Character char_body_2d;
	
	[Export]
	private byte char_velocity;
	
	private Vector2 getDirection()
	{
		Vector2 input = Input.GetVector("Left", "Right", "Up", "Down");
		input = new Vector2(Math.Sign(input.X), Math.Sign(input.Y));
		return input;
	}

	private void moveCharacter()
	{
		Vector2 char_direction = getDirection();
		
		this.char_body_2d.Velocity =  char_velocity * char_direction;
		this.char_body_2d.MoveAndSlide();
	}

	public override void _Process(double delta)
	{
		this.moveCharacter();
	}
}
