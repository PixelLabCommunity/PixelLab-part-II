using Godot;

public class enemySlime : CharacterBody2D
{
	private AnimatedSprite2D Animations;

	[Export] public Marker2D EndPoint;

	private Vector2 EndPosition;

	[Export] public float Limit = 0.5f;

	[Export] public int Speed = 20;

	private Vector2 StartPosition;

	public override void _Ready()
	{
		Animations = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		StartPosition = Position;
		EndPosition = EndPoint.GlobalPosition;
	}

	private void ChangeDirection()
	{
		var tempEnd = EndPosition;
		EndPosition = StartPosition;
		StartPosition = tempEnd;
	}

	private void UpdateVelocity()
	{
		var moveDirection = EndPosition - Position;
		if (moveDirection.Length() < Limit) ChangeDirection();

		Velocity = moveDirection.Normalized() * Speed;
	}

	private void UpdateAnimation()
	{
		var animationString = "walkUp";
		if (Velocity.Y > 0)
			animationString = "walkDown";
		else if (Velocity.X > 0)
			animationString = "walkRight";
		else
			animationString = "walkLeft";
		Animations.Play(animationString);
	}

	public void _PhysicsProcess(float delta)
	{
		UpdateVelocity();
		MoveAndSlide();
		UpdateAnimation();
	}
}
