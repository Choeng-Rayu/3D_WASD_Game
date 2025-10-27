# 🎮 Quick Reference Guide - WASD Investigation Game

## 🚀 QUICK START (Just the essentials)

### DO THIS FIRST (in order):

1. **Scene**: Open SampleScene, delete defaults
2. **Ground**: Create Plane (20x20 scale), Position (0,-1,0)
3. **Player**: Create Capsule, add CharacterController component
4. **Camera**: Create child "CameraHolder", add Camera to it
5. **Controls**: Add MouseLook script to CameraHolder
6. **Interaction**: Add InteractionSystem script to Camera
7. **UI**: Create Canvas with InteractionPrompt panel
8. **Objects**: Add interactable cubes/cylinders with scripts
9. **Test**: Press Play!

---

## 🎯 GAME FLOW DIAGRAM

```
┌─────────────────────────────────────────────────────────────┐
│                     PLAYER BEHAVIOR                          │
├─────────────────────────────────────────────────────────────┤
│                                                               │
│  Every Frame:                                                │
│  ┌──────────────────────────────────────────────────────┐    │
│  │ 1. PlayerController.Update()                         │    │
│  │    └─ Reads WASD input                               │    │
│  │    └─ Moves character with CharacterController       │    │
│  │                                                        │    │
│  │ 2. MouseLook.Update()                                │    │
│  │    └─ Reads Mouse X/Y                                │    │
│  │    └─ Rotates camera                                 │    │
│  │                                                        │    │
│  │ 3. InteractionSystem.Update()                        │    │
│  │    └─ Shoots raycast from camera                     │    │
│  │    └─ Detects IInteractable objects                  │    │
│  │    └─ Shows "Press E" prompt if object found         │    │
│  │    └─ If E pressed: calls object.Interact()          │    │
│  │                                                        │    │
│  │ 4. Object's OnObjectInteracted()                     │    │
│  │    └─ If ClueObject: Display clue on UI              │    │
│  │    └─ If PickupObject: Add to inventory              │    │
│  │                                                        │    │
│  └──────────────────────────────────────────────────────┘    │
│                                                               │
└─────────────────────────────────────────────────────────────┘
```

---

## 📋 SCRIPT RESPONSIBILITIES

### PlayerController.cs
**What it does:** Handles movement physics
```
INPUT: W, A, S, D keys
PROCESS: Calculate direction + apply gravity
OUTPUT: Move CharacterController
```

### MouseLook.cs
**What it does:** Handles camera look
```
INPUT: Mouse X, Y movement
PROCESS: Rotate playerBody (left/right), Rotate camera (up/down)
OUTPUT: Camera view rotates with mouse
```

### InteractionSystem.cs
**What it does:** Detects and manages interactions
```
INPUT: Player looking at objects, E key press
PROCESS: Raycast from camera, check if IInteractable exists
OUTPUT: Show prompt UI, call Interact() on E press
```

### IInteractable.cs (Interface)
**What it does:** Defines contract for interactive objects
```
Any script that implements this MUST have:
- Interact()
- GetInteractionText()
- OnLookAt()
- OnLookAway()
```

### InteractableObject.cs (Base Class)
**What it does:** Implements IInteractable with common features
```
FEATURES:
- Highlighting when looked at
- Can be single-use or multi-use
- Can override OnObjectInteracted()
```

### ClueObject.cs (Inherits from InteractableObject)
**What it does:** Displays clues
```
ON INTERACT:
- Shows title and description on ClueDisplayUI
- Can be looked at multiple times
```

### PickupObject.cs (Inherits from InteractableObject)
**What it does:** Adds items to inventory
```
ON INTERACT:
- Adds item to inventory
- Destroys the object (can only pick up once)
- Updates inventory UI
```

### InventoryManager.cs (Singleton)
**What it does:** Manages all inventory
```
SINGLETON = Only ONE exists in entire game
Can be accessed from anywhere:
  InventoryManager.instance.AddItem("Key", 1)
```

---

## 🔍 HOW INTERACTION WORKS (Step by Step)

### User presses E while looking at object:

```
1. InteractionSystem shoots raycast from camera forward

2. Physics.Raycast() returns hit.collider

3. InteractionSystem gets IInteractable from collider

4. InteractionSystem calls: interactable.Interact()

5. For ClueObject: ClueObject.OnObjectInteracted()
   └─ Updates ClueDisplayUI text

6. For PickupObject: PickupObject.OnObjectInteracted()
   └─ Calls InventoryManager.AddItem()
   └─ Destroys gameObject
```

---

## 🎨 HIERARCHY STRUCTURE (What should look like)

```
Scene (SampleScene)
├── Player (Capsule)
│   ├── CharacterController
│   ├── PlayerController script
│   └── CameraHolder (Empty)
│       ├── MouseLook script
│       └── Camera
│           └── InteractionSystem script
│
├── Environment (Empty - Organization)
│   ├── Ground (Plane)
│   ├── Desk (Cube + ClueObject script)
│   ├── GoldenKey (Cube + PickupObject script)
│   └── Painting (Cylinder + ClueObject script)
│
├── Canvas (UI)
│   ├── InteractionPrompt (Panel + CanvasGroup)
│   │   └── PromptText (TextMeshPro)
│   ├── ClueDisplay (Panel)
│   │   └── ClueText (TextMeshPro)
│   └── InventoryUI (TextMeshPro)
│
├── UIManager (Empty)
│   └── InventoryManager script
│
└── Directional Light
```

---

## 🐛 DEBUGGING CHECKLIST

### If object can't be interacted:
- [ ] Object has BoxCollider component?
- [ ] BoxCollider "Is Trigger" is checked?
- [ ] Object has IInteractable script (ClueObject or PickupObject)?
- [ ] InteractionSystem script is on Camera?
- [ ] Raycast range is large enough (default: 3 units)?

### If interaction prompt doesn't show:
- [ ] InteractionPrompt has CanvasGroup component?
- [ ] InteractionPrompt assigned in InteractionSystem Inspector?
- [ ] PromptText has "Press E to interact" text?

### If inventory doesn't update:
- [ ] InventoryUI assigned in InventoryManager Inspector?
- [ ] InventoryManager on Canvas (or persistent object)?
- [ ] PickupObject script has InventoryManager reference?

### If player can't move:
- [ ] Player has CharacterController component?
- [ ] PlayerController assigned to Player?
- [ ] CameraHolder is child of Player?
- [ ] Ground doesn't have "Is Trigger" checked?

### If camera won't look around:
- [ ] CameraHolder has MouseLook script?
- [ ] MouseLook "Player Body" set to Player transform?
- [ ] Mouse Sensitivity value reasonable (2-5)?

---

## 📊 EXAMPLE: Adding a New Clue Object

```csharp
// WHAT TO DO IN EDITOR:

1. Create > 3D Object > Cube
2. Name: "SafeBox"
3. Position: (0, 1, -5)
4. Add Component > Script > ClueObject
5. Set in Inspector:
   - Clue Title: "Safe Discovered"
   - Clue Description: "A locked safe! I need a key..."
   - Clue Display UI: Drag the ClueText from Canvas

// NOW IN CODE:
// ClueObject.cs already handles everything!
// Just put it in scene and it works.
```

---

## 📊 EXAMPLE: Adding a New Pickup Item

```csharp
// WHAT TO DO IN EDITOR:

1. Create > 3D Object > Cube
2. Name: "Photograph"
3. Position: (2, 0.5, 3)
4. Scale: (0.2, 0.3, 0.2)
5. Material Color: White
6. Add Component > Script > PickupObject
7. Set in Inspector:
   - Item Name: "Mysterious Photograph"
   - Quantity: 1

// NOW IN CODE:
// PickupObject.cs handles adding to inventory!
// When player picks it up:
// - Appears in inventory UI
// - Object is destroyed
// - Can't pick it up again
```

---

## 🎮 CONTROLS REFERENCE

| Key | Action |
|-----|--------|
| **W** | Move Forward |
| **A** | Move Left |
| **S** | Move Backward |
| **D** | Move Right |
| **Mouse** | Look Around |
| **E** | Interact (when prompt shows) |
| **ESC** | Toggle cursor lock |

---

## 💡 TIPS FOR SUCCESS

1. **Save often** - Before making changes
2. **Test frequently** - After each change, press Play
3. **Check console** - Debug.Log() messages help understand flow
4. **Zoom in/out** - Use scroll wheel to see objects better
5. **Use colors** - Assign different colors to objects so you can find them
6. **Read error messages** - Red text in console tells you what's wrong

---

## 🎓 NEXT STEPS AFTER BASIC SETUP

### EASY (1-2 hours):
- [ ] Add 5 more interactive objects
- [ ] Create a second room/area
- [ ] Add a win condition (collect all items)

### MEDIUM (3-5 hours):
- [ ] Add NPC with simple dialogue
- [ ] Create a puzzle (need key to open safe)
- [ ] Add sound effects when interacting
- [ ] Create different clue themes (mystery solving)

### ADVANCED (5+ hours):
- [ ] Create a complete mystery story
- [ ] Add enemies that chase you
- [ ] Save/load game progress
- [ ] Create custom 3D models

---

## ❓ COMMON QUESTIONS

**Q: Can I make objects always interactable?**
A: Yes! In InteractableObject, set "Can Interact Multiple Times" = true

**Q: How do I change interaction range?**
A: In InteractionSystem script, change "Interaction Range" (default 3)

**Q: Can I add more than 3 objects?**
A: Absolutely! Just duplicate any object and change its properties

**Q: How do I add custom highlights?**
A: In InteractableObject, assign a highlight material in Inspector

**Q: Can I make objects only interactable if I have an item?**
A: Yes! You'd need to modify the script to check inventory first

---

## 📞 TROUBLESHOOTING FLOW

```
PROBLEM OCCURS
    ↓
[Check Console for error message]
    ↓
NO ERROR → Object doesn't do what expected
    ↓
[Check Inspector - are components assigned?]
[Check Hierarchy - is object in right place?]
[Check Script - read the code and comments]

YES ERROR → Something is breaking
    ↓
[Read error message carefully]
[Find the file and line number it mentions]
[Check if component is missing or null]
```

---

Remember: **A game is just code + objects + physics + UI working together!** Each script does ONE thing, and they talk to each other. Build it piece by piece, test often, and you'll have a working game! 🎉
