using Godot;

public partial class enemySlime2 : CharacterBody2D
{
	private AnimatedSprite2D _animations;
	private Vector2 _endPosition;
	private Vector2 _startPosition;

	[Export] public Marker2D EndPoint;

	[Export] public float Limit = 0.5f;

	[Export] public int Speed = 20;

	public override void _Ready()
	{
		_startPosition = Position;
		_endPosition = EndPoint.GlobalPosition;
		_animations = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	private void ChangeDirection()
	{
		(_endPosition, _startPosition) = (_startPosition, _endPosition);
	}

	private void UpdateVelocity()
	{
		var moveDirection = _endPosition - Position;
		if (moveDirection.Length() < Limit) ChangeDirection();

		Velocity = moveDirection.Normalized() * Speed;
	}

	private void UpdateAnimation()
	{
		var animationString = Velocity.X switch
		{
			> 0 => "walkRight",
			< 0 => "walkLeft",
			_ => Velocity.Y switch
			{
				> 0 => "walkDown",
				< 0 => "walkUp",
				_ => ""
			}
		};

		_animations.Play(animationString);
	}

	public override void _PhysicsProcess(double delta)
	{
		UpdateVelocity();
		MoveAndSlide();
		UpdateAnimation();
	}
}
