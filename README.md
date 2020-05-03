<h1 align="center">NextGenerationHero Project</h1>
Group members: Khaoula Bahloul, Johnny Pham, Gabriel Oliver

Game Url: https://gabrieloliver.itch.io/nght4draft2

## Hero

The control scheme to move the hero can be toggled by clicking the M-key, to switch between WASD and mouse movement.

Eggs that the hero shoots get destroyed when making contact with the world bounds, enemies, and waypoints.

Counters are incremented each time the hero shoots an egg (also decrements after eggs disappear), the hero destroys an enemy with an egg, and when the hero collides with enemies.

## Waypoints

When H-key is pressed, the waypoints will be hidden and if they are hiden and H-key is pressed, the waypoints will show again. The code for this is in the Update() function. This was implemented by flipping the sprite.enabled flag on the SpriteRenderer of the waypoint.

When a waypoint object collides with an egg, it loses 25% of its opacity. We implemented this feature in OnTriggerEnter2D function. We first check if the sprite is enabled because we don't want the waypont to lose their color when they are hidden, then we check if an egg hits the waypoint. If the conditions are ture, we decrease the alpha channel of the SpriteRenderer color by 0.25 and then we destroy the egg.

On the forth collision with an egg (when the alpha value reaches 0), a waypoint object will disappear and re-position in a new point that is randomly located at + or - 15 units in both X and Y from the initial position of the waypoint. That was implemented by choosing a random float number between -15 and 15 then adding it to the initial position in both x and y.


## Enemy 

Enemies are destroyed when making contact with the hero, or when making contact with an egg.

A new enemy spawns when one is destroyed.

The enemy follows a path to a waypoint, either sequentially or through random waypoints (toggle with J-key). The enemy will still follow waypoints after they have been moved.
