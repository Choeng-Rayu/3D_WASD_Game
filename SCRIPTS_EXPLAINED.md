# Game Overview - Simple Beginner Game for Learning Unity

## 🎯 Learning Objectives
This game teaches you:
1. **Player Movement** - WASD keys to move around
2. **Mouse Look** - Move mouse to look around
3. **Interaction System** - Press E to interact with objects
4. **Object-Oriented Programming** - Using interfaces and inheritance
5. **UI Management** - Displaying information on screen

---

## 📚 Script Breakdown (What Each Script Does)

### **1. PlayerController.cs** ✅
**Location:** Attached to Player object

**What it does:**
- Reads WASD input from keyboard
- Moves the character forward/backward/left/right
- Applies gravity so player doesn't float in air
- Uses CharacterController component (built-in Unity)

**Simple explanation:** This is the **brain of movement** - it decides where the player goes.

---

### **2. MouseLook.cs** ✅
**Location:** Attached to CameraHolder (child of Player)

**What it does:**
- Reads mouse movement
- Rotates the camera up/down (pitch)
- Rotates the player body left/right (yaw)
- Locks cursor to center of screen so it doesn't escape
- Press ESC to unlock/lock cursor

**Simple explanation:** This is the **camera controller** - it lets you look around with your mouse.

---

### **3. IInteractable.cs** ✅
**Location:** Interface file (no object attached)

**What it does:**
- This is just a **contract/rule** that says "anything interactive must have these functions"
- Functions:
  - `Interact()` - Called when player presses E
  - `GetInteractionText()` - Returns text to display
  - `OnLookAt()` - Called when player looks at object
  - `OnLookAway()` - Called when player stops looking at object

**Simple explanation:** This is a **template** - it's like saying "all interactive objects must follow these rules".

---

### **4. InteractableObject.cs** ✅
**Location:** Base class for interactive objects

**What it does:**
- Implements the IInteractable interface
- Stores object settings (name, interaction text)
- Handles visual feedback (highlighting objects when you look at them)
- Calls `OnObjectInteracted()` when player interacts

**Simple explanation:** This is the **base class** - it's the foundation for all objects you can interact with.

---

### **5. InteractionSystem.cs** ✅
**Location:** Attached to Main Camera (child of Player)

**What it does:**
- Shoots a ray (invisible line) from camera forward
- Detects if the ray hits something interactive
- Shows/hides "Press E to interact" prompt
- When player presses E, calls `Interact()` on the object

**Simple explanation:** This is the **detector** - it's like a laser beam that finds what you're looking at.

---

### **6. ClueObject.cs** ✅
**Location:** Attached to interactive objects (Desk, Painting)

**What it does:**
- Inherits from InteractableObject
- When interacted, displays a clue on screen
- You can set:
  - Clue Title (like "Desk Note")
  - Clue Description (the actual clue text)

**Simple explanation:** This is for **clues** - when you interact with it, it tells you information.

---

### **7. PickupObject.cs** ✅
**Location:** Attached to pickable items (KeyItem)

**What it does:**
- Inherits from InteractableObject
- When interacted, adds item to inventory
- Then destroys itself (removes from scene)
- Works with InventoryManager to track items

**Simple explanation:** This is for **items you can collect** - pick it up, add to inventory, then it disappears.

---

### **8. InventoryManager.cs** ✅
**Location:** Attached to Canvas

**What it does:**
- Stores a list of items you have collected
- Functions:
  - `AddItem()` - Add item to inventory
  - `RemoveItem()` - Remove item from inventory
  - `HasItem()` - Check if you have an item
  - `GetItemCount()` - Count how many of an item you have
- Updates UI text to show current inventory

**Simple explanation:** This is the **inventory tracker** - it remembers what items you've picked up.

---

## 🔄 How Everything Works Together

```
PLAYER PRESSES WASD
        ↓
PlayerController Moves Player
        ↓
PLAYER MOVES WITH MOUSE
        ↓
MouseLook Rotates Camera
        ↓
PLAYER LOOKS AT OBJECT
        ↓
InteractionSystem Detects Object with Ray
        ↓
Shows "Press E to interact" Prompt
        ↓
PLAYER PRESSES E
        ↓
InteractionSystem Calls Interact() on Object
        ↓
Object's OnObjectInteracted() Runs
        ↓
If it's a Clue: Shows clue text on screen
If it's an Item: Adds to inventory and destroys object
```

---

## 🎮 How to Use in Game

### **Controls:**
- **W** = Move Forward
- **A** = Move Left
- **S** = Move Backward
- **D** = Move Right
- **Mouse** = Look Around
- **E** = Interact with object (when prompt shows)
- **ESC** = Unlock/Lock Mouse

### **What You Can Do:**
1. Walk around the scene using WASD
2. Look around using mouse
3. When you see an object and "Press E to interact" appears:
   - Press E to interact
   - If it's a clue → see information
   - If it's an item → pick it up (added to inventory)

---

## 📝 What Your Teacher is Teaching

### **Programming Concepts:**
1. **Interfaces** - IInteractable (rules for interactive objects)
2. **Inheritance** - InteractableObject extends the interface
3. **Polymorphism** - Different objects (ClueObject, PickupObject) behave differently
4. **Encapsulation** - Each script has its own job and data
5. **Delegates** - Not used here, but events could be added

### **Game Development Concepts:**
1. **Input System** - Reading keyboard and mouse input
2. **Physics** - CharacterController for movement with gravity
3. **Raycasting** - Detecting objects with invisible ray
4. **UI Management** - Updating screens and text
5. **Object Management** - Creating and destroying game objects

---

## ✅ Checklist - All Scripts Present

- ✅ **PlayerController.cs** - Handles movement
- ✅ **MouseLook.cs** - Handles camera rotation
- ✅ **IInteractable.cs** - Interface for interactive objects
- ✅ **InteractableObject.cs** - Base class for interactive objects
- ✅ **InteractionSystem.cs** - Detects interactions
- ✅ **ClueObject.cs** - Displays clues
- ✅ **PickupObject.cs** - Pickable items
- ✅ **InventoryManager.cs** - Tracks inventory

---

## 🚀 Ready to Build!

All scripts are ready. Now you need to:
1. Open `BUILD_GAME.md` to follow setup instructions
2. Create objects in the scene
3. Attach scripts to objects
4. Press Play and test!

Good luck! 🎮
