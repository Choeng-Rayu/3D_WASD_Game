# Build Your WASD Game - Unity 2022

## What You're Building
A game where you walk around (WASD), look around (mouse), and press E to interact with objects.

---

## STEP 1: Scene Setup
1. Open `SampleScene.unity`
2. Delete the default Cube and Camera
3. Keep only the Directional Light

---

## STEP 2: Create Player (THIS IS YOUR CHARACTER)
1. Right-click in Hierarchy → 3D Object → Capsule
   - Name it: **Player**
   - Position: X=0, Y=1, Z=0
   - Scale: X=0.6, Y=1, Z=0.6

2. Add Components to Player:
   - Click "Add Component"
   - Search: **CharacterController** (add it)
   - Search: **PlayerController** (attach the script)

3. Create child object:
   - Right-click Player → Create Empty Child
   - Name it: **CameraHolder**
   - Position: X=0, Y=0.6, Z=0

4. Drag **Main Camera** from Hierarchy into CameraHolder as a child

5. Select Camera → Add Component → **InteractionSystem** script

---

## STEP 3: Create Ground
1. Right-click in Hierarchy → 3D Object → Plane
   - Name it: **Ground**
   - Position: X=0, Y=-1, Z=0
   - Scale: X=20, Y=1, Z=20

2. Add Component: **BoxCollider** (keep "Is Trigger" UNCHECKED)

---

## STEP 4: Create UI (Interaction Prompt)
1. Right-click in Hierarchy → UI → Canvas
   - This creates a Canvas automatically

2. Right-click Canvas → UI → Panel
   - Name it: **InteractionPrompt**
   - Position: X=0, Y=-200, Z=0
   - Width: 400, Height: 100

3. Right-click InteractionPrompt → UI → TextMeshPro
   - Type in text: "Press E to interact"
   - Font size: 36
   - Alignment: Center

---

## STEP 5: Create First Object to Interact With (DESK WITH CLUE)
1. Right-click in Hierarchy → 3D Object → Cube
   - Name it: **Desk**
   - Position: X=5, Y=0.5, Z=0
   - Scale: X=2, Y=0.5, Z=1

2. Add Component: **BoxCollider**
   - Check "Is Trigger" ✓

3. Add Component: **ClueObject** script
   - In Inspector, set:
     - Clue Title: "Desk Note"
     - Clue Description: "Found a suspicious note on the desk..."

---

## STEP 6: Create Second Object (PICKUP ITEM - KEY)
1. Right-click in Hierarchy → 3D Object → Cube
   - Name it: **KeyItem**
   - Position: X=3, Y=0.5, Z=2
   - Scale: X=0.3, Y=0.3, Z=0.3

2. Change color to Yellow:
   - Select KeyItem
   - In Inspector, find the Mesh Renderer
   - Under Materials, click on "Default-Material"
   - Change Albedo color to Yellow

3. Add Component: **BoxCollider**
   - Check "Is Trigger" ✓

4. Add Component: **PickupObject** script
   - In Inspector, set:
     - Item Name: "Golden Key"
     - Quantity: 1

---

## STEP 7: Create Third Object (ANOTHER CLUE - PAINTING)
1. Right-click in Hierarchy → 3D Object → Cylinder
   - Name it: **Painting**
   - Position: X=-5, Y=1.5, Z=0
   - Scale: X=1, Y=2, Z=0.2

2. Add Component: **BoxCollider**
   - Check "Is Trigger" ✓

3. Add Component: **ClueObject** script
   - In Inspector, set:
     - Clue Title: "Hidden Safe"
     - Clue Description: "There's a safe hidden behind the painting!"

---

## STEP 8: Create UI for Displaying Clues
1. Right-click Canvas → UI → Panel
   - Name it: **ClueDisplay**
   - Make it bigger for clues
   - Position: Center of screen

2. Right-click ClueDisplay → UI → TextMeshPro
   - Text: "Clue will appear here"
   - Font size: 32

---

## STEP 9: Create UI for Inventory
1. Right-click Canvas → UI → TextMeshPro
   - Name it: **InventoryUI**
   - Position: Top-left (X=50, Y=-50)
   - Text: "Inventory: Empty"
   - Font size: 24

2. Select Canvas → Add Component: **InventoryManager** script
   - In Inspector, drag InventoryUI into the "Inventory UI" field

---

## STEP 10: Connect UI to Scripts

### For ClueObject scripts:
1. Select **Desk**
2. In the ClueObject script component, drag **ClueDisplay** panel into "Clue Display UI" field
3. Do the same for **Painting**

### For InteractionSystem script:
1. Select **Camera**
2. In InteractionSystem script component, drag **InteractionPrompt** panel into the field

---

## STEP 11: Test Your Game
1. Press Play ▶️
2. Try:
   - **WASD** = Walk around
   - **Mouse** = Look around
   - **E** (while near objects) = Interact
   - Walk near KeyItem and press E = Pick it up (appears in inventory)
   - Walk near Desk and press E = See clue

---

## If Something Doesn't Work

### Player doesn't move:
- Check Player has **CharacterController** component
- Check Player has **PlayerController** script

### Can't look around with mouse:
- Check Camera is inside **CameraHolder**
- Check Camera has **InteractionSystem** script

### Can't interact:
- Check object has **BoxCollider** with "Is Trigger" ✓
- Check object has either **ClueObject** or **PickupObject** script

### Inventory doesn't show:
- Check Canvas has **InventoryManager** script
- Check InventoryUI is assigned in InventoryManager

---

## Done! 🎮
Your game is ready to play!
