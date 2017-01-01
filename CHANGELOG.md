# Change Log
All notable changes to this project will be documented in this file.
This project adheres to [Semantic Versioning](http://semver.org/).
This changelog follows the format as defined by [Keep a Changelog](http://keepachangelog.com/).
All unreleased changes are found in develop. Master is for released content only.

## [Alpha 1.3.0] - 2017-1-1
###Added
 - Functionality for Crates
 - In-game options menu
 - More user-friendly error popups
 - Users can now host their own private servers
 - Game saves last entered username and IP
 - Game saves options
 - Basic nonfunctional inventory (full functionality coming next update)
###Changed
 - Servers now run on DarkRift API instead of Photon API
 - User enters username and IP instead of blind joining
 - Updated Input Manager: automatically detects buttons for changing controls
 - Free resizing no longer allowed
###Fixed
 - Return to Main Menu occasionally fails
 - Fullscreen toggle not working
 - Game not launching on Mac
 - Player drifts away from camera
 - Several player duplication glitches
 - Mouse lock not working
 
## [Alpha 1.2.1] - 2016-07-13
###Added
 - Fullscreen toggle
 - InputManager Axis Support
###Changed
 - Splash image replaced with more finalized version
 - Updated Input Manager: improved custom key management

###Fixed
 - Could not rejoin after leaving to main menu
 - Controls.cfg not generating properly in build mode
 - Running not toggling properly
 
## [Alpha 1.2.0] - 2016-06-27
###Added
- Crates (Archer, Ninja, Bomber and Miner)
- Randomized crate spawning
- Controls menu (editable controls)
- Animations for player
- Weapon and Armor models (currently unimplemented)

###Changed
 - Placeholder player model replaced with new one
 - Joining server now built in to main menu
 - Updated player controller
 
###Fixed
 - Fall detection
 - Problems with joining server 
 - Player glitching through walls
 
## [Alpha 1.1.0] - 2016-06-05
###Added
- Basic multiplayer setup
- Basic teams system
- Build checking/travis CI support
- Fall detection
- HUD Outline

###Changed
 - New logo
 - New code for player controller and player GUI
 - Player is now a character instead of a rigidbody
 - Main Menu background improved
 

## [Alpha 1.0.1] - 2016-05-08
###Added
 - Ability to jump
 - Basic player GUI (Pause menu)
 - Custom logo
 
###Fixed
 - Mouse was not hidden

###Removed
 - Unity Popup

## [Alpha 1.0.0] - 2016-05-07
### Added
- Main Menu (Options, Credits, Level Select)
- Testing level
- Basic functionality for player
- Standard Unity assets


[Alpha 1.0.0]: https://github.com/FewdpewGames/unity-game/releases/tag/v1.0.0-alpha
[Alpha 1.0.1]: https://github.com/FewdpewGames/unity-game/releases/tag/v1.0.1-alpha
[Alpha 1.1.0]: https://github.com/FewdpewGames/unity-game/releases/tag/v1.1.0-alpha
[Alpha 1.2.0]: https://github.com/FewdpewGames/unity-game/releases/tag/v1.2.0-alpha
[Alpha 1.2.1]: https://github.com/FewdpewGames/unity-game/releases/tag/v1.2.1-alpha
[Alpha 1.3.0]: https://github.com/FewdpewGames/unity-game/releases/tag/v1.3.0-alpha


<!---
[//]: # ## [X.y.z] - YYYY-MM-DD
[//]: # ### Added, Changed, Removed, Deprecated, Fixed, Security


[//]: # [Unreleased]: https://github.com/olivierlacan/keep-a-changelog/compare/v0.3.0...HEAD
[//]: # [0.3.0]: https://github.com/olivierlacan/keep-a-changelog/compare/v0.2.0...v0.3.0
-->
