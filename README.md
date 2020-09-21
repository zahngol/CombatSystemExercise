# CombatSystemExercise

## Future Expansion

#### How would your code change if weapons had range?
Modifying the weapon would be straight forward, you could easily add a Range parameter. The larger modification would be to the players and battle system. Currently the players have no concept of position and therefore no concept of distance. You could add a 1D, 2D, or 3D position parameter to the characters, along with a movement speed parameter. Then during battle, after a target is selected, a distance comparison could be performed between the character and it's target. If the distance is larger than the weapon range, then the player would move toward the target until it is in range, and then begin it's normal attack sequence.

#### How would your code change if weapons had special effects, like the ability to make targets catch fire?
I would create the effects as classes, all deriving from a parent class. For example, FireEffect and ElectricityEffect inherit from Effect. A weapon would maintain a list of it's effects, and the characters would maintain a list of currently applied effects. When hit with a weapon, the weapon's effects are added to the player's list of applied effects. All effects would have a required Engage() method along with a lifespan parameter and it's own time loop (assuming time is a factor in the effect, such as damage over time from a fire). The Engage method would be run, and all effects would be applied for their lifetime, after which the effect would be removed from the character's list of applied effects.

#### How might this system be incorporated into a larger items and inventory system?
Like the effects, Weapons would be modified to inherit from an Item class, which would require parameters such as cost from a shop and weight/size for storage requirements. Once this system is in place, new items such as Shields, Armor, and Consumables could also be created as derivatives from Item so they can all function within the inventory system.

Essentially, as systems such as this scale, polymorphism becomes a vital part of ensuring that all items, systems, and characters fall into proper categories and maintain "contracts" to ensure they are able to execute the necessary tasks for objects of their type.
