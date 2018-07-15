extends Area2D

export (int) var speed
export var damage = 5
export (float) var lifetime

var velocity = Vector2()

func start(_position, _direction):
    position = _position
    direction = _direction
    $lifetime.wait_time = lifetime
    velocity = _direction * speed

func _process(delta):
    position += velocity * delta

func _on_Bullet_body_entered(body):
    pass

func _on_Bullet_body_entered(body):
    pass