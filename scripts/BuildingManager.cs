using Godot;
using System;
using System.Runtime.ConstrainedExecution;

public partial class BuildingManager : Node
{
	[Export] public TileMap Tiles;
	[Export] public BuildingResource TestResourceStartWith;

	private BuildingResource _selectedBuilding;
	private bool _isTPressed = false;
	private Vector2 _gridSnappedPosition;

	public override void _Ready()
	{
		_selectedBuilding = TestResourceStartWith;
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("place")) {
			Vector2 mousePos = GetViewport().GetMousePosition() - GetViewport().GetVisibleRect().GetCenter();

			bool xIsEven = Tiles.TileSet.GetPattern(_selectedBuilding.PatternIndex).GetSize().X % 2 == 0;
			bool yIsEven = Tiles.TileSet.GetPattern(_selectedBuilding.PatternIndex).GetSize().Y % 2 == 0;
			
			float xOffset = xIsEven ? 0 : 1;
			float yOffset = yIsEven ? 0 : 1;

			Vector2I patternCoords = new Vector2I(
				((int) Math.Round(mousePos.X + xOffset * 4 / 16)) + Tiles.TileSet.GetPattern(_selectedBuilding.PatternIndex).GetSize().X + (int) xOffset / 2,
				((int) Math.Round(mousePos.Y + yOffset * 4 / 16)) + Tiles.TileSet.GetPattern(_selectedBuilding.PatternIndex).GetSize().Y + (int) yOffset / 2
			);

			Tiles.SetPattern(
				1,
				patternCoords,
				Tiles.TileSet.GetPattern(_selectedBuilding.PatternIndex)
			);
		}
	}
}
