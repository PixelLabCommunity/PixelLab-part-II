using Godot;
using System;

public partial class character_body_2d : CharacterBody2D
{
	private const float Speed = 50.0f;
	private AnimationPlayer _animationPlayer;

	public override void _Ready()
	{
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public override void _PhysicsProcess(double delta)
	{
		var velocity = Velocity;
		var direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;

			// Determine the animation to play based on the movement direction
			if (direction.X < 0)
				_animationPlayer.Play("walkLeft");
			else if (direction.X > 0)
				_animationPlayer.Play("walkRight");

			if (direction.Y < 0)
				_animationPlayer.Play("walkUp");
			else if (direction.Y > 0)
				_animationPlayer.Play("walkDown");
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);

			// If no movement, stop any playing animation
			_animationPlayer.Stop();
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
