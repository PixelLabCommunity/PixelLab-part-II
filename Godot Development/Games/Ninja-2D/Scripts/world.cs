using Godot;

public partial class world : Node2D
{
	private Node2D heartsContainer;
	private Node2D player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		hearts_container = GetNode<Node2D>("CanvasLayer/heartsContainer");
		player = GetNode<Node2D>("TileMap/Player");

		hearts_container
		heartsContainer.SetMaxHearts(playerInstance.GetCurrentHealth());
		heartsContainerInstance.UpdateHearts(1);
		player._currentHealth.Connect(heartsContainer);
	}
}
