# Knights

An experimental RPG using [Torque 3D][].

 [Torque 3D]: https://github.com/GarageGames/Torque3D

## Basics

In Knights you control a squad of soldiers defending the Bailey from a besieging army.
The game takes place in the Bailey, in the adjacent town, and in the surrounding woodlands.
The action takes place over several days, each day bringing a new challenge to your soldiers.

## Controls

The game is controlled entirely via the keyboard.
The letters you press give commands to your soldiers.
For example, pressing `jho` will tell **J**ordan to **h**eal **O**rton.

### Selection

In _normal mode_, pressing the key that starts one of your squadmates' names will select that character and place you in _command mode_.
From there, you can issue commands to that character.
The game will pause when in _command mode_, initiated by selecting a character.
You can also pause the game manually with the space key.
Pretting `ctrl c` at any time will cancel the current command and place you back in _normal mode_, unfrozen.
Pressing `e` instead of a character's key will select everyone.

### Targeting

Most commands require a target to be selected - for example, healing must be applied to someone.
There are several styles of targeting, with different commands.

 * Party targeting: some commands must be applied to the party.
   These commands are targeted by pressing the key associated with a character,
	the same way as selecting the character.
 * Enemy targeting: when a command needs an enemy, letters will appear above visible enemies.
   If there are a lot of enemies, two-letter combinations might be used.
 * Inventory targeting: commands that interact with the inventory will make a list of stored items visible,
   which will be tagged with letters in the same way as enemies.
 * Task targeting: commands that interact with a character's task list have access to the following selectors:
   `n` and `l` refer to the next and last tasks in the list. Either of those numbers prefixed with an integer
	refers to, for example, the 3rd last or 4th next task.
 * Positioning: where commands need a position, relative directions `l`, `r`, `f` and `b` are used.
   They can be modified by either a `c` or an `f` in front of them, for close and far respetively.

In addition, some special selectors are commonly available:

 * `E`: Everyone
 * `S`: Self

In the case of a command applied to everyone, the command will be repeated once for each target in a queue, starting with the closest target.

### Commands

Basic instructions in _command mode_ are:

 * `m`: Move. The character will take up a position in the given region.
 * `a`: Attack once. Selected character attacks the target using whatever weapon is equipped.
 * `e`: Engage. Selected character engages the target until one of them is dead.
 * `h`: Heal (or help). Selected charater gives the target whatever medical attention they can.
 * `g`: Glance. Selected character glances in a direction.
 * `l`: Loot. Search a corpse or container for any objects.

In addition, there are more advanced commands:

 * `,`: And. Allows you to select multiple characters.
 * `;`: Then. Allows you to queue another command for the same character.
 * `c`: Cancel. Cancels a specific task.
 * `.`: Repeat. Perform the last command again.
 * `w`: Wield. Select a piece of equipment from the character's inventory.
 * `u`: Use. Choose a special ability for the character to use.
 * `x`: Hide. The character will take cover behind/within a specified obstacle.
 * `v`: Evade! The character will dodge.

