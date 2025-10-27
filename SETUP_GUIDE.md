# WASD Investigation Game - Setup Guide

## Game Concept
A simple investigation game where players use WASD to move around a scene and press E to interact with objects and find clues.

## Setup Steps

### 1. **Scene Setup**
- Open your `SampleScene.unity`
- Clear any default objects

### 2. **Player Setup**
1. Create a new 3D Capsule (this will be the player)
   - Name it "Player"
   - Position: (0, 1, 0)
   - Scale: (0.6, 1, 0.6)

2. Add components to Player:
   - **CharacterController** component (Unity built-in)
   - **PlayerController** script (attach the script we created)

3. Create an empty child object called "Camera Holder"
   - Parent it to Player
   - Position: (0, 0.6, 0)
   - Add **Main Camera** to it

4. Add components to Camera:
   - **InteractionSystem** script

### 3. **UI Setup**
1. Create a Canvas in the scene (Right-click > UI > Canvas)

2. Add a Panel inside Canvas for interaction prompt:
   - Name: "InteractionPrompt"
   - Position: bottom center
   - Add TextMeshPro text: "Press E to interact"

3. Add a Panel for clue display:
   - Name: "ClueDisplay"
   - Position: center
   - Add TextMeshPro text inside it

4. Add a TextMeshPro text for inventory:
   - Name: "InventoryUI"
   - Position: top-left corner

5. Attach **InventoryManager** script to Canvas
   - Assign InventoryUI to the script

### 4. **Create Interactable Objects**

#### Clue 1 (Examine an object):
1. Create a Cube
   - Name: "Desk"
   - Position: (5, 0, 0)
   - Scale: (2, 0.5, 1)

2. Add **BoxCollider** (check "Is Trigger")

3. Add **ClueObject** script
   - Clue Title: "Desk Note"
   - Clue Description: "Found a suspicious note on the desk..."
   - Assign ClueDisplay UI to the script

#### Pickup Item:
1. Create another Cube
   - Name: "KeyItem"
   - Position: (3, 0.5, 0)
   - Scale: (0.3, 0.3, 0.3)
   - Color: Yellow (to stand out)

2. Add **BoxCollider** (check "Is Trigger")

3. Add **PickupObject** script
   - Item Name: "Golden Key"
   - Quantity: 1

#### Another Clue:
1. Create a Cylinder
   - Name: "Painting"
   - Position: (-5, 1, 0)
   - Scale: (1, 2, 0.2)

2. Add **BoxCollider** (check "Is Trigger")

3. Add **ClueObject** script
   - Clue Title: "Behind the Painting"
   - Clue Description: "There's a hidden safe behind the painting!"

### 5. **Ground Setup**
1. Create a Plane
   - Scale: (20, 1, 20)
   - Position: (0, -1, 0)
   - Name: "Ground"

2. Add **BoxCollider** (don't check "Is Trigger")

### 6. **Lighting**
- Add a Directional Light for basic illumination
- Adjust intensity to ~0.8

## How to Play
- **WASD** - Move around
- **Mouse** - Look around (camera)
- **E** - Interact with objects
- Objects highlight when you look at them
- Collect items for inventory
- Read clues to solve the mystery

## Testing
1. Press Play
2. Move with WASD
3. Look at objects (should highlight)
4. Press E to interact
5. Check inventory for collected items

## Next Steps (Enhancements)
- Add more clues to create a mystery
- Create puzzle solutions
- Add audio feedback
- Create locked doors that require items
- Add NPC dialogue
- Create a solution UI showing all found clues
