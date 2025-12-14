# Afton Robotics - Development Log
This project will be centered on learning how to develop in VR space through a "Sit and Survive" style game that will keep the focus on navigating various VR problems and techniques

*Developed By: Amelia Roberts*

*Created With: Unity*

*Started On: 12-07-2025*

## 12/14/2025 Pivoting to Levers
<details>
<summary><strong>Changed my crank to a lever and opened new doors!</strong></summary>

### What I did
- Scrapped original crank idea (more on this in today's "Challenges" and "What I learned" sections)
- Created a working lever with a LeverReader that reads it's angle (relative to its min and max angle) as a value from 0 to 1 using InverseLerp.
	- I designed the LeverReader to accept a configurable rotation axis, making it simple to read the lever's rotation along whichever axis the lever rotation (Note: So long as that axis is exactly X, Y, or Z. The lever will not currently allow rotation across multiple axes)
- Created a SlidingDoorController that takes the LeverReader value to inform the door how far it should be slid between open and closed positions.

### Challenges
- The crank
	- Rotation around 360 degrees did not work well due to Hinge Joint limitations
	- This requires more complicated logic that calculates the rotation of the pivot based on the movement of the handle
- There's a lot to remember, I had to spend some time going back through VR tutorials to remember exactly how grab interactables work

### What I learned
- Unity's Hinge Joint does not play well with infinite circular rotation. They express a value between -180 and 180 so when a full rotation happens it sees the crank and snapping violently backwards on its hinge causing a jumping effect every full rotation. The crank will require more complicated logic

### Next Steps
- Change SlidingDoorController to slide the door closed/open when LeverReader is at it's max/min angle

### Future Considerations (Backlog)
- Allow LeverReader to read across mixed rotation axes, not just full X, Y, and Z
- Create a working crank to replace the door levers
</details>

## 12/08/2025 Devlog Setup + Initial Project
<details>
<summary><strong>Started this log and learned a lot about VR development</strong></summary>

### What I did
- Setup this devlog (planning theming and log structure)
- Created my first VR project with moving simple objects
- Started working on adding a crank that can be rotated by the player's hand


### Challenges
- I tried adding a pivot to a crank asset so it could be rotated around the pivot rather than around the center of the whole crank and could not figure out why I was seeing the parent's transform gizmo move when I moved a child's transform. It turned out Unity has a way to choose where that is and I had "Center" selected not "Pivot". That meant it kept moving to the center of the overall object when I moved its children.


### What I learned
- XR Interactive Toolkit is an easy way to start VR development
- XR Grab Interactables have 3 movement types that change what generates force in physics interactions:


| Movement Type | Can exert force on other objects | Other objects can exert force on it | Description|
|---------------|-------------------------------|-------------------------------------|------------|
| Instantaneous	| No | No| Object moves by directly changing the transform and rotation values |
| Kinematic | Yes | No | Uses the kinematic rigidbody to move |
| Velocity Tracking | Yes | Yes | Sets the velocity of the rigidbody

- Dynamic Attach allows the initial offset when an XR Grab Interactable is grabbed to remain when the object is grabbed rather than snapping the object to the center of the grabber
- Attach Transform is a Transform attribute on an XR Grab Interactable that, when set, will create a specific offset relative to the grabber when grabbed
- Unity has a Pivot mode for Gizmos to show exactly where the single object is rather than Center which shows where the center of the total object is


### Next steps
- FIX the crank! 
	- Redo the crank's pivot's position with Pivot mode
	- Add collider for grabbing the handle
	- Add collider for the crank to keep it on top of the table
	- Make the crank rotate with player movement
</details>