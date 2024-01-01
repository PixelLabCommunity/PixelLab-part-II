using Godot;
using Godot.Collections;

public partial class hearts_container : HBoxContainer
{
    private PackedScene HeartGuiClass = GD.Load<PackedScene>("res://scenes/gui/heart_gui.tscn");

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Replace with function body.
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        // Replace with function body.
    }

    public void SetMaxHearts(int max)
    {
        for (var i = 0; i < max; i++)
        {
            var heart = (Node)HeartGuiClass.Instance();
            AddChild(heart);
        }
    }

    public void UpdateHearts(int currentHealth)
    {
        Array hearts = GetChildren();
        for (var i = 0; i < currentHealth; i++) ((HeartGui)hearts[i]).Update(true);

        for (var i = currentHealth; i < hearts.Count; i++) ((HeartGui)hearts[i]).Update(false);
    }
}