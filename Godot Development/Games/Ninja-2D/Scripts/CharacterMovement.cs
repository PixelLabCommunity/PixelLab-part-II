using Godot;

namespace Ninja2D.Scripts;

public partial class CharacterMovement : CharacterBody2D
{
	[Signal]
	public delegate void HealthChangedEventHandler(int newHealth);

	private const float Speed = 35.0f;
	private int _currentHealth;
	private int _damageBase = 1;
	private AnimationPlayer _playerAnimation;
	private int _startHealth = 3;

	public override void _Ready()
	{
		_currentHealth = _startHealth;
		_playerAnimation = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public override void _PhysicsProcess(double delta)
	{
		var moveDirection = Input.GetVector("ui_left", "ui_right", "ui_up",
			"ui_down");
		var velocity = Velocity;

		if (moveDirection != Vector2.Zero)
		{
			velocity.X = moveDirection.X * Speed;
			velocity.Y = moveDirection.Y * Speed;
			var moveAnimation = "Down";
			switch (velocity.X)
			{
				case < 0:
					moveAnimation = "Left";
					break;
				case > 0:
					moveAnimation = "Right";
					break;
				default:
				{
					if (velocity.Y < 0)
						moveAnimation = "Up";
					break;
				}
			}

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
	private void _on_hurt_box_area_entered(Node area)
	{
		if (area.Name == "hitBox")
		{
			_currentHealth -= _damageBase;
			if (_currentHealth < 0) _currentHealth = _startHealth;
			EmitSignal(nameof(HealthChanged), _currentHealth);
		}
	}
}
