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


    private void Update(bool whole)
    {
        if (whole) _sprite.Frame = 0;
    }
}