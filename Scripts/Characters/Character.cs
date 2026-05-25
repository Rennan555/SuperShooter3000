using Godot;
using System;

public abstract partial class Character : CharacterBody2D
{
	// Sinal para tomar dano
	[Signal]
	public delegate void takeDamageEventHandler(byte damage);
	
	// Atributos gerais
	[Export]
	protected byte health;

	[Export]
	protected byte attackPower;
}
