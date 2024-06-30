using Godot;
using System;

public partial class BuildingManager : Node
{
	private bool isTPressed = false;
	private Sprite2D buildingPreview;
	private Vector2 gridSnappedPosition;
	private PackedScene SelectedBuilding = GD.Load<PackedScene>("res://scenes/test_building.tscn");

	public override void _Ready()
	{
		buildingPreview = GetNode<Sprite2D>("BuildingPreview");
	}

	public override void _Process(double delta)
	{
		Vector2 mousePos = GetViewport().GetMousePosition() - GetViewport().GetVisibleRect().GetCenter();
		gridSnappedPosition = new Vector2(
			(float) Math.Round(mousePos.X / 16) * 16,
			(float) Math.Round(mousePos.Y / 16) * 16 + 8f
		);

		if (isTPressed)
			buildingPreview.Position = gridSnappedPosition;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventKey keyEvent && keyEvent.Keycode == Key.T)
		{
			isTPressed = keyEvent.Pressed;

			if (!keyEvent.Pressed)
				buildingPreview.Hide();
			else
				buildingPreview.Show();
		}

		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left && isTPressed)
		{
			Node2D newBuilding = (Node2D) SelectedBuilding.Instantiate();
			GetTree().Root.AddChild(newBuilding);
			newBuilding.Position = gridSnappedPosition;
		}
	}
}
