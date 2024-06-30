using Godot;
using System;

public partial class BuildingResource : Resource
{
	[Export] public PackedScene Building { get; set; }
	[Export] public int PatternIndex { get; set; }

	public BuildingResource() : this(null, 0) {}

	public BuildingResource(PackedScene building, int pattern) {
		Building = building;
		PatternIndex = pattern;
	}
}
