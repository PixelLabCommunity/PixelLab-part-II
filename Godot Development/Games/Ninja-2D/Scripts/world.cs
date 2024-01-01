using Godot;

public partial class world : Node2D
{
    private Node2D heartsContainer;
    private Node2D player;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        heartsContainer = GetNode<Node2D>("CanvasLayer/heartsContainer");
        player = GetNode<Node2D>("TileMap/Player");

        if (heartsContainer is Node2D heartsContainerInstance && player is player playerInstance)
        {
            heartsContainer.SetMaxHearts(playerInstance.GetCurrentHealth());
            heartsContainerInstance.UpdateHearts(1);

            playerInstance.Connect("HealthChanged", this, "_OnPlayerHealthChanged");
        }
        else
        {
            GD.Print("HeartsContainer or Player node not found or not of the expected type.");
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        // Your _Process logic here
    }

    private void _OnPlayerHealthChanged(int newHealth)
    {
        if (heartsContainer is HeartsContainer heartsContainerInstance) heartsContainerInstance.UpdateHearts(newHealth);
    }
}