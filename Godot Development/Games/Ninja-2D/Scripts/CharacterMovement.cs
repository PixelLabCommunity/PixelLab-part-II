using Godot;

namespace Ninja2D.Scripts;

public partial class CharacterMovement : CharacterBody2D
{
	private const float Speed = 35.0f;
	private AnimationPlayer _playerAnimation;

	public override void _Ready()
	{
		_playerAnimation = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public override void _PhysicsProcess(double delta)
	{
		var moveDirection = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		var velocity = Velocity;

		if (moveDirection != Vector2.Zero)
		{
			velocity.X = moveDirection.X * Speed;
			velocity.Y = moveDirection.Y * Speed;
			var moveAnimation = "Down";
			if (velocity.X < 0)
				moveAnimation = "Left";
			else if (velocity.X > 0)
				moveAnimation = "Right";
			else if (velocity.Y < 0)
				moveAnimation = "Up";

			_playerAnimation.Play("walk" + moveAnimation);
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
			if (_playerAnimation.IsPlaying()) _playerAnimation.Stop();
		}

		Velocity = velocity;
		MoveAndSlide();
		// HandleCollision();
	}

	private void HandleCollision()
	{
		for (var i = 0; i < GetSlideCollisionCount(); i++)
			if (GetSlideCollision(i) is { } collision)
				if (collision.GetCollider() is Node2D collider)
					GD.Print(collider.Name);
	}

	// Ensure that this method is inside the class definition
	private static void OnHurtBoxAreaEntered(Node area)
	{
		if (area.Name == "hitBox") GD.Print(area.GetParent().Name);
	}
}
