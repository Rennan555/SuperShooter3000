using Godot;
using System;

public partial class StartButton : Button
{
	public override void _Pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/main_stage.tscn");
	}
}
