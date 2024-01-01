extends Node2D

@onready var heartsContainer = $CanvasLayer/heartsContainer
@onready var player = $TileMap/Player
# Called when the node enters the scene tree for the first time.
func _ready():
	heartsContainer.setMaxHearts(player._currentHealth)
	heartsContainer.updateHearts(1)


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
