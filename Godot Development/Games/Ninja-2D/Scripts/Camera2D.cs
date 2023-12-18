using Godot;

public partial class Camera2D : Godot.Camera2D
{
	[Export] public TileMap Tilemap { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Rect2 mapRect = Tilemap.GetUsedRect();

		// Check if CellQuadrantSize is Vector2
		var tileSize = Tilemap.CellQuadrantSize;

		var worldSizeInPixels = mapRect.Size * tileSize;

		// Assign float values directly to LimitRight and LimitBottom
		LimitRight = (int)worldSizeInPixels.X;
		LimitBottom = (int)worldSizeInPixels.Y;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void _Process(float delta)
	{
		// Your _process code goes here
	}
}
