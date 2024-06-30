using Godot;
using System;

public partial class BuildingResource : Resource
{
	[Export] public PackedScene Building { get; set; }
	[Export] public TileMapPattern Pattern { get; set; }

	public BuildingResource() : this(null, null) {}

	public BuildingResource(PackedScene building, TileMapPattern pattern) {
		Building = building;
		Pattern = pattern;
	}
}
