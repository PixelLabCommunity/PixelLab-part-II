using Godot;

namespace Ninja2D.Scripts;

public partial class Camera2D : Godot.Camera2D
{
	[Export] private TileMap Tilemap { get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Rect2 mapRect = Tilemap.GetUsedRect();

		// Check if CellQuadrantSize is Vector2
		var tileSize = Tilemap.CellQuadrantSize;

		var (worldWight, worldHeight) = mapRect.Size * tileSize;

		LimitRight = (int)worldWight;
		LimitLeft = -(int)worldWight;

		LimitTop = -(int)worldHeight;
		LimitBottom = (int)worldHeight;
	}
}
