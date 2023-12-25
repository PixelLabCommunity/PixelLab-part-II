using Godot;
using System;

public partial class enemySlime3 : CharacterBody2D
{
	[Export]
	public int Speed = 20;

	[Export]
	public float Limit = 0.5f;

	[Export]
	public Marker2D EndPoint;

	private AnimatedSprite2D Animations;

	private Vector2 StartPosition;
	private Vector2 EndPosition;

	public override void _Ready()
	{
		StartPosition = Position;
		EndPosition = EndPoint.GlobalPosition;
		Animations = GetNode<AnimatedSprite2D>("AnimatedSprite2D"); 
	}

	private void ChangeDirection()
	{
		var tempEnd = EndPosition;
		EndPosition = StartPosition;
		StartPosition = tempEnd;
	}

	private void UpdateVelocity()
	{
		var moveDirection = (EndPosition - Position);
		if (moveDirection.Length() < Limit)
		{
			ChangeDirection();
		}

		Velocity = moveDirection.Normalized() * Speed;
	}

	private void UpdateAnimation()
	{
		string animationString = "";

		if (Velocity.Y > 0)
		{
			animationString = "walkDown";
		}
		else if (Velocity.Y < 0)
		{
			animationString = "walkUp";
		}

		if (Velocity.X > 0)
		{
			animationString = "walkRight";
		}
		else if (Velocity.X < 0)
		{
			animationString = "walkLeft";
		}

		Animations.Play(animationString);
	}

	public override void _PhysicsProcess(double delta)
	{
		UpdateVelocity();
		MoveAndSlide();
		UpdateAnimation();
	}
}
