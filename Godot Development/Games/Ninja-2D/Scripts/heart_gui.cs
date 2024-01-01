using Godot;

public partial class heart_gui : Panel
{
    private Sprite2D _sprite;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _sprite = GetNode<Sprite2D>("Sprite2D");
        // Replace with function body.
    }

    public void Update(bool whole)
    {
        _sprite.Frame = whole ? 0 : 4;
    }
}