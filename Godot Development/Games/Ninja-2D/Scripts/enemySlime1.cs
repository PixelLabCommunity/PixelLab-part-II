using Godot;

namespace Ninja2D.Scripts;

public partial class EnemySlime1 : CharacterBody2D
{
	private AnimatedSprite2D _animations;
	private Vector2 _endPosition;
	private Vector2 _startPosition;
	[Export] public Marker2D EndPoint;
	[Export] public float Limit = 0.5f;
	[Export] public float Speed = 20;

	public override void _Ready()
	{
		var _animations = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		string[] mobTypes = _animations.SpriteFrames.GetAnimationNames();
		_animations.Play(mobTypes[GD.Randi() % mobTypes.Length]);
		_startPosition = Position;
		_endPosition = EndPoint.GlobalPosition;
	}

	private void ChangeDirection()
	{
		(_endPosition, _startPosition) = (_startPosition, _endPosition);
	}

	private void UpdateVelocity()
	{
		var moveDirection = _endPosition - Position;
		if (moveDirection.Length() < Limit)
			ChangeDirection();

		Velocity = moveDirection.Normalized() * Speed;
	}

	private void UpdateAnimation()
	{
		var verticalAnimation = "";
		var horizontalAnimation = "";

		if (Velocity.Y > 0)
			verticalAnimation = "walkDown";
		else if (Velocity.Y < 0)
			verticalAnimation = "walkUp";

		if (Velocity.X > 0)
			horizontalAnimation = "walkRight";
		else if (Velocity.X < 0)
			horizontalAnimation = "walkLeft";

		var animationString = verticalAnimation != "" ? verticalAnimation : horizontalAnimation;
		_animations.Play(animationString);
	}

	private void _PhysicsProcess()
	{
		UpdateVelocity();
		MoveAndSlide();
		UpdateAnimation();
	}
}
