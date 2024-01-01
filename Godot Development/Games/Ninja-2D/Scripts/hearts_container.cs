using Godot;

public partial class hearts_container : HBoxContainer
{
    private PackedScene HeartGuiClass = GD.Load<PackedScene>("res://scenes/gui/heart_gui.tscn");

    public void SetMaxHearts(int max)
    {
        for (var i = 0; i < max; i++)
        {
            var heart = HeartGuiClass.Instantiate();
            AddChild(heart);
        }
    }

    public void UpdateHearts(int currentHealth)
    {
        var hearts = GetChildren();

        for (var i = 0; i < hearts.Count; i++) ((HeartGui)hearts[i]).Update(i < currentHealth);
    }
}