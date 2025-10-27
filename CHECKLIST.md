# ✅ STEP-BY-STEP SETUP CHECKLIST

Use this checklist to track your progress. Check each box as you complete it!

---

## PHASE 1: PREPARATION ⏱️ ~5 min

- [ ] Open Unity and open the project
- [ ] Open `Assets > Scenes > SampleScene.unity`
- [ ] Delete all default objects in scene (if any)
- [ ] Scene should be empty except for Main Camera in Hierarchy

---

## PHASE 2: CREATE GROUND ⏱️ ~3 min

### In Hierarchy:
- [ ] Right-click > 3D Object > Plane → Name: `Ground`
- [ ] Right-click > Create Empty → Name: `Environment`
- [ ] Drag Ground into Environment

### Select Ground, in Inspector:
- [ ] Position: X=0, Y=-1, Z=0
- [ ] Scale: X=20, Y=1, Z=20
- [ ] Add BoxCollider (if not present)
- [ ] **IMPORTANT:** BoxCollider "Is Trigger" = **UNCHECKED** ❌
- [ ] Material Color: Gray (optional, for visibility)

### Test:
- [ ] Press Play
- [ ] Camera should be above ground
- [ ] Nothing should fall

---

## PHASE 3: CREATE PLAYER ⏱️ ~5 min

### Create Capsule:
- [ ] Right-click Hierarchy > 3D Object > Capsule → Name: `Player`
- [ ] Position: X=0, Y=1, Z=0
- [ ] Scale: X=0.6, Y=1, Z=0.6
- [ ] Rotation: X=0, Y=0, Z=0

### Add Components to Player:
- [ ] Add Component > CharacterController
  - [ ] Center: X=0, Y=0, Z=0
  - [ ] Radius: 0.3
  - [ ] Height: 2
- [ ] Add Component > Script > PlayerController

### Add PlayerController settings:
- [ ] Move Speed: 5
- [ ] Ground Drag: 5
- [ ] Gravity: -9.81

### Test:
- [ ] Press Play
- [ ] Player capsule appears above ground
- [ ] Doesn't fall (CharacterController working)
- [ ] Stop Play

---

## PHASE 4: CREATE CAMERA SYSTEM ⏱️ ~5 min

### Create Camera Holder:
- [ ] Select Player
- [ ] Right-click Player > Create Empty → Name: `CameraHolder`
- [ ] CameraHolder Position: X=0, Y=0.6, Z=0
- [ ] CameraHolder Rotation: X=0, Y=0, Z=0

### Delete old Main Camera:
- [ ] Delete the default Main Camera from scene (if it exists)

### Create New Camera:
- [ ] Select CameraHolder
- [ ] Right-click CameraHolder > 3D Object > Camera → Name: `Camera`
- [ ] Camera Position: X=0, Y=0, Z=0
- [ ] Camera Tag: Change to `MainCamera`

### Test:
- [ ] Press Play
- [ ] Scene view shows from inside player perspective
- [ ] Stop Play

---

## PHASE 5: MOUSE LOOK ⏱️ ~3 min

### Add MouseLook Script:
- [ ] Select CameraHolder (the parent of Camera)
- [ ] Add Component > Script > MouseLook

### Configure MouseLook in Inspector:
- [ ] Mouse Sensitivity: 2
- [ ] Max Look Up Angle: 90
- [ ] Max Look Down Angle: 90
- [ ] Player Body: **Drag Player from Hierarchy**

### Test:
- [ ] Press Play
- [ ] Move mouse - camera should rotate
- [ ] WASD still does nothing yet (normal)
- [ ] Press ESC - cursor should unlock
- [ ] Press ESC again - cursor locks
- [ ] Stop Play

---

## PHASE 6: TEST MOVEMENT ⏱️ ~2 min

### Test:
- [ ] Press Play
- [ ] Press W - player moves forward
- [ ] Press A - player moves left
- [ ] Press S - player moves backward
- [ ] Press D - player moves right
- [ ] Move mouse - camera rotates
- [ ] Stop Play ✅ **MOVEMENT WORKING!**

---

## PHASE 7: CREATE UI CANVAS ⏱️ ~5 min

### Create Canvas:
- [ ] Right-click Hierarchy > UI > Canvas - TextMeshPro
- [ ] Accept TextMeshPro setup if prompted

### Create Interaction Prompt Panel:
- [ ] Right-click Canvas > Create Empty → Name: `InteractionPrompt`
- [ ] InteractionPrompt Position: X=0, Y=-250, Z=0
- [ ] InteractionPrompt Size: X=600, Y=100

### Add CanvasGroup to InteractionPrompt:
- [ ] Select InteractionPrompt
- [ ] Add Component > CanvasGroup

### Add Text to InteractionPrompt:
- [ ] Select InteractionPrompt
- [ ] Right-click InteractionPrompt > TextMeshPro - Text → Name: `PromptText`
- [ ] PromptText Size: X=600, Y=100
- [ ] PromptText Text: "Press E to interact"
- [ ] PromptText Font Size: 36
- [ ] PromptText Alignment: Center / Middle

---

## PHASE 8: CREATE CLUE DISPLAY UI ⏱️ ~5 min

### Create Clue Panel:
- [ ] Right-click Canvas > Panel - TextMeshPro → Name: `ClueDisplay`
- [ ] ClueDisplay Position: X=0, Y=0, Z=0
- [ ] ClueDisplay Size: X=800, Y=600
- [ ] ClueDisplay Image Color: Black, Alpha=0.8 (darker for readability)

### Add Text to ClueDisplay:
- [ ] Right-click ClueDisplay > TextMeshPro - Text → Name: `ClueText`
- [ ] ClueText Position: X=0, Y=0, Z=0
- [ ] ClueText Size: X=700, Y=500
- [ ] ClueText Text: "(Clues will appear here)"
- [ ] ClueText Font Size: 28
- [ ] ClueText Alignment: Center / Middle
- [ ] ClueText Enable "Text Wrapping"

### Disable ClueDisplay by default:
- [ ] Select ClueDisplay
- [ ] Uncheck the checkbox next to "ClueDisplay" in Hierarchy (makes it inactive)

---

## PHASE 9: CREATE INVENTORY UI ⏱️ ~3 min

### Create Inventory Text:
- [ ] Right-click Canvas > TextMeshPro - Text → Name: `InventoryUI`
- [ ] InventoryUI Position: X=-300, Y=300, Z=0
- [ ] InventoryUI Size: X=400, Y=400
- [ ] InventoryUI Text: "Inventory:"
- [ ] InventoryUI Font Size: 24
- [ ] InventoryUI Alignment: Top Left

### Create UI Manager:
- [ ] Right-click Hierarchy (not under Canvas) > Create Empty → Name: `UIManager`
- [ ] Add Component > Script > InventoryManager
- [ ] Drag InventoryUI from Canvas to "Inventory UI" field in InventoryManager

---

## PHASE 10: ADD INTERACTION SYSTEM ⏱️ ~3 min

### Add InteractionSystem Script to Camera:
- [ ] Select Camera (child of CameraHolder)
- [ ] Add Component > Script > InteractionSystem

### Configure InteractionSystem in Inspector:
- [ ] Interaction Range: 3
- [ ] Interaction Key: E
- [ ] Player Camera: **Drag Main Camera from Hierarchy** (or auto-finds)
- [ ] Interaction Prompt: **Drag InteractionPrompt from Canvas**

---

## PHASE 11: CREATE DESK (CLUE OBJECT) ⏱️ ~5 min

### Create Desk Cube:
- [ ] Select Environment
- [ ] Right-click Environment > 3D Object > Cube → Name: `Desk`
- [ ] Position: X=5, Y=0, Z=0
- [ ] Scale: X=2, Y=0.5, Z=1
- [ ] Material Color: Brown (optional)

### Add Collider:
- [ ] Select Desk
- [ ] Find BoxCollider component
- [ ] Check "Is Trigger" ✅

### Add ClueObject Script:
- [ ] Add Component > Script > ClueObject

### Configure ClueObject in Inspector:
- [ ] Clue Title: `"Desk Investigation"`
- [ ] Clue Description: `"You found a mysterious note on the desk! It reads: 'Look behind the painting for the real answer...'"`
- [ ] Clue Display UI: **Drag ClueText from Canvas > ClueDisplay**

---

## PHASE 12: CREATE GOLDEN KEY (PICKUP) ⏱️ ~4 min

### Create Key Cube:
- [ ] Select Environment
- [ ] Right-click Environment > 3D Object > Cube → Name: `GoldenKey`
- [ ] Position: X=3, Y=0.5, Z=0
- [ ] Scale: X=0.3, Y=0.3, Z=0.3
- [ ] Material Color: Yellow (stands out!)

### Add Collider:
- [ ] Select GoldenKey
- [ ] Find BoxCollider component
- [ ] Check "Is Trigger" ✅

### Add PickupObject Script:
- [ ] Add Component > Script > PickupObject

### Configure PickupObject in Inspector:
- [ ] Item Name: `"Golden Key"`
- [ ] Quantity: 1

---

## PHASE 13: CREATE PAINTING (CLUE OBJECT) ⏱️ ~5 min

### Create Painting Cylinder:
- [ ] Select Environment
- [ ] Right-click Environment > 3D Object > Cylinder → Name: `Painting`
- [ ] Position: X=-5, Y=1, Z=0
- [ ] Scale: X=1, Y=2, Z=0.2
- [ ] Material Color: Red (optional)

### Add Collider:
- [ ] Select Painting
- [ ] Find CapsuleCollider component
- [ ] Check "Is Trigger" ✅
- [ ] (Or remove CapsuleCollider and add BoxCollider, then check "Is Trigger")

### Add ClueObject Script:
- [ ] Add Component > Script > ClueObject

### Configure ClueObject in Inspector:
- [ ] Clue Title: `"Hidden Safe Behind Painting"`
- [ ] Clue Description: `"Behind the painting, you discover a safe! This must contain important evidence!"`
- [ ] Clue Display UI: **Drag ClueText from Canvas > ClueDisplay**

---

## PHASE 14: ADD LIGHTING ⏱️ ~3 min

### Create Directional Light:
- [ ] Right-click Hierarchy > Light > Directional Light → Name: `Sun`
- [ ] Position: X=0, Y=10, Z=0
- [ ] Rotation: X=50, Y=-30, Z=0
- [ ] Intensity: 0.8

### (Optional) Add Ambient Light:
- [ ] Window > Rendering > Lighting Settings
- [ ] Ambient Light > Intensity: 0.3
- [ ] Close window

---

## PHASE 15: FINAL TEST! 🎮 ⏱️ ~5 min

### Press Play Button:

#### Movement Test:
- [ ] Press W → Move forward ✓
- [ ] Press A → Move left ✓
- [ ] Press S → Move backward ✓
- [ ] Press D → Move right ✓
- [ ] Move mouse → Camera rotates ✓

#### Interaction Test:
- [ ] Look at Desk → "Press E to interact" appears ✓
- [ ] Press E on Desk → Clue displays ✓
- [ ] Move away → Clue disappears ✓
- [ ] Look at GoldenKey → Prompt appears ✓
- [ ] Press E on Key → Appears in inventory, key disappears ✓
- [ ] Look at Painting → Prompt appears ✓
- [ ] Press E on Painting → Clue displays ✓

#### UI Test:
- [ ] Inventory shows "Golden Key: 1" in top-left ✓
- [ ] ESC → Unlocks cursor ✓
- [ ] ESC → Locks cursor again ✓

### If all work:
- [ ] 🎉 **CONGRATULATIONS! GAME IS WORKING!**

### If something doesn't work:
- [ ] See QUICK_REFERENCE.md "Debugging Checklist"

---

## WHAT YOU'VE BUILT

```
✅ Player movement system (WASD + Mouse)
✅ Interaction detection (Raycast + E key)
✅ UI feedback (Prompts, displays, inventory)
✅ Two types of interactive objects (Clues & Pickups)
✅ Inventory management system
✅ Complete game loop!
```

---

## 🎓 NEXT: Learn the Code

Now that it's working, read through the scripts:
- [ ] Read PlayerController.cs - understand movement
- [ ] Read MouseLook.cs - understand camera rotation
- [ ] Read InteractionSystem.cs - understand detection
- [ ] Read ClueObject.cs - understand inheritance
- [ ] Read PickupObject.cs - understand inventory
- [ ] Read InventoryManager.cs - understand singleton pattern

---

## 📝 NOTES

Write any issues you encounter here:

```
Issue 1: ________________________________
Solution: ________________________________

Issue 2: ________________________________
Solution: ________________________________

Issue 3: ________________________________
Solution: ________________________________
```

---

## 🚀 YOU'RE READY!

You've built a complete interactive game from scratch! 

**Next steps:**
- Add more objects
- Create more areas
- Design an actual mystery to solve
- Add NPCs with dialogue
- Create puzzles that require items

Great job! 🎮✨
