using Godot;

namespace Ninja2D.Scripts;

public partial class EnemySlime2 : CharacterBody2D
{
	private Vector2 _endPosition;
	private float _speed = 50.0f; // Adjust the speed as needed
	private Vector2 _startPosition;

	public override void _Ready()
	{
		_startPosition = Position;
		_endPosition = _startPosition + new Vector2(0, 3 * 16);
	}

	private void UpdateVelocity(float delta)
	{
		var moveDirection = (_endPosition - Position).Normalized();
		Velocity = moveDirection * _speed;
	}

	private void _PhysicsProcess(float delta)
	{
		UpdateVelocity(delta);
		MoveAndSlide();
	}
}
