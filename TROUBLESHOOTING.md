# 🐛 TROUBLESHOOTING GUIDE

## Common Problems & Solutions

---

## ⚠️ COMPILATION ERRORS (Red text in Console)

### Error: "The type or namespace name 'TMPro' could not be found"

**Cause:** TextMeshPro isn't imported  
**Solution:**
1. At top of script, add:
```csharp
using TMPro;
```

### Error: "error CS0246: The type or namespace name 'IInteractable' could not be found"

**Cause:** IInteractable.cs script not found  
**Solution:**
1. Check that `IInteractable.cs` exists in `Assets/Script/`
2. Reload Visual Studio (close and reopen)
3. Or: Delete your script and reattach it

### Error: "error CS0306: The type 'SomeClass' may not be used as a type argument"

**Cause:** Generic type error (shouldn't happen in this project)  
**Solution:**
1. Check your script spelling and capitalization
2. Ensure all scripts are saved

---

## 🎮 GAMEPLAY PROBLEMS

### Problem: "Can't move with WASD"

**Checklist:**
- [ ] Player object has `CharacterController` component?
- [ ] Player object has `PlayerController` script?
- [ ] Input Manager has "Horizontal" and "Vertical" axes? (usually default in Unity)

**Debug:**
```csharp
// Add this to PlayerController.cs Update() to test:
Debug.Log($"Input - H: {Input.GetAxis("Horizontal")}, V: {Input.GetAxis("Vertical")}");
```

If log shows (0, 0), input isn't being read → Unity input settings issue

---

### Problem: "Can't look around with mouse"

**Checklist:**
- [ ] CameraHolder has `MouseLook` script?
- [ ] MouseLook has "Player Body" assigned to Player?
- [ ] Cursor locked properly?

**Test:**
```csharp
// In MouseLook.cs Start(), verify:
Debug.Log($"Cursor Lock State: {Cursor.lockState}");
Debug.Log($"PlayerBody: {playerBody?.name}");
```

If cursor not locked, try pressing ESC

---

### Problem: "Press E to interact doesn't appear"

**Checklist:**
- [ ] Camera has `InteractionSystem` script?
- [ ] InteractionSystem has "Interaction Prompt" assigned?
- [ ] InteractionPrompt panel exists with CanvasGroup?
- [ ] Raycasting is detecting objects?

**Debug:**
```csharp
// In InteractionSystem.cs DetectInteractable(), add:
Debug.Log($"Raycast hit: {hit.collider?.name ?? "Nothing"}");
```

---

### Problem: "Objects don't respond when I press E"

**Checklist:**
- [ ] Object has BoxCollider with "Is Trigger" CHECKED ✅?
- [ ] Object has script (ClueObject or PickupObject)?
- [ ] Script's fields are assigned in Inspector?

**Debug:**
```csharp
// In InteractionSystem.cs HandleInteraction(), add:
if (Input.GetKeyDown(interactionKey))
{
    Debug.Log($"E Pressed! Current Interactable: {currentInteractable?.GetInteractionText() ?? "None"}");
}
```

---

### Problem: "Object doesn't highlight when I look at it"

**Note:** Current scripts don't require highlighting to work. Check clue displays instead.

**If you want highlighting:**
- [ ] Object has `InteractableObject` script?
- [ ] Script has "Highlight Material" assigned?
- [ ] Or material colors aren't being changed

The highlight is optional - it's just visual feedback.

---

### Problem: "Clue doesn't display when I interact"

**Checklist:**
- [ ] ClueObject script assigned to object?
- [ ] "Clue Title" has text?
- [ ] "Clue Description" has text?
- [ ] "Clue Display UI" has ClueText assigned?
- [ ] ClueDisplay panel exists on Canvas?

**Debug:**
```csharp
// In ClueObject.cs OnObjectInteracted(), verify:
Debug.Log($"Displaying: {clueTitle}");
Debug.Log($"UI is null: {clueDisplayUI == null}");
```

---

### Problem: "Pick up items don't add to inventory"

**Checklist:**
- [ ] PickupObject script assigned to object?
- [ ] "Item Name" is not empty?
- [ ] "Quantity" is greater than 0?
- [ ] InventoryManager script on UIManager?
- [ ] InventoryUI assigned in InventoryManager?

**Debug:**
```csharp
// In PickupObject.cs Start(), add:
Debug.Log($"InventoryManager found: {inventoryManager != null}");
```

---

### Problem: "Inventory UI doesn't update"

**Checklist:**
- [ ] InventoryUI text exists on Canvas?
- [ ] InventoryManager has "Inventory UI" assigned?
- [ ] InventoryManager script is on a persistent object?

**Debug:**
```csharp
// In InventoryManager.cs UpdateInventoryDisplay(), add:
Debug.Log($"Updated Inventory. UI assigned: {inventoryUI != null}");
```

---

## 📐 PHYSICS PROBLEMS

### Problem: "Player falls through ground"

**Cause:** Ground collider is set to "Is Trigger"  
**Solution:**
1. Select Ground object
2. Find BoxCollider component
3. Uncheck "Is Trigger" ❌
4. Press Play again

---

### Problem: "Player collides with walls that should be passable"

**Cause:** Interactive object colliders aren't trigger colliders  
**Solution:**
1. Select the object
2. Find the Collider component
3. Check "Is Trigger" ✅

---

### Problem: "Player moves too slow/fast"

**Solution:**
1. Select Player
2. In Inspector, find PlayerController script
3. Change "Move Speed" (default: 5)
   - Higher = faster (try 7-8)
   - Lower = slower (try 3-4)

---

## 🖱️ CAMERA PROBLEMS

### Problem: "Camera movement is inverted"

**Solution:**
1. Select CameraHolder
2. Find MouseLook script
3. Change "Mouse Sensitivity" to negative value
   - Or change line in code:
   ```csharp
   xRotation -= mouseY;  // Change to:
   xRotation += mouseY;  // (remove the minus)
   ```

---

### Problem: "Camera moves too fast/slow"

**Solution:**
1. Select CameraHolder
2. Find MouseLook script
3. Change "Mouse Sensitivity"
   - Higher = faster (try 3-5)
   - Lower = slower (try 0.5-1)

---

### Problem: "Can't look up/down enough"

**Solution:**
1. Select CameraHolder
2. Find MouseLook script
3. Increase "Max Look Up Angle" and "Max Look Down Angle"
   - Default: 90 (full up/down)
   - Can go higher: 120, 150

---

## 🎨 UI PROBLEMS

### Problem: "UI is too small/big"

**Solution:**
1. Select the UI element (InteractionPrompt, ClueDisplay, etc.)
2. In Inspector, change Size (X and Y)
3. Higher values = bigger

### Problem: "UI text is too small/big"

**Solution:**
1. Select the TextMeshPro text
2. In Inspector, change "Font Size"
3. Default: 36 for prompts, 28 for clues

### Problem: "UI text is hard to read"

**Solution:**
1. Select the text object
2. Change Color (darker or different color)
3. Or select parent panel and add darker background

---

## 🔧 SCRIPT ATTACHMENT PROBLEMS

### Problem: "Script appears but doesn't work"

**Solution:**
1. Check the script name matches the class name:
   - File: `PlayerController.cs`
   - Class: `public class PlayerController`
2. If different, rename to match
3. Reimport script in Unity

### Problem: "Can't attach script - greyed out"

**Cause:** Script has compilation error  
**Solution:**
1. Open the script file
2. Look at Console for red errors
3. Fix the error
4. Script becomes available to attach

### Problem: "Inspector fields are empty/blank"

**Cause:** Script has [SerializeField] but not visible  
**Solution:**
1. In Inspector, scroll down (might be below fold)
2. Check if field should be visible (has [SerializeField] or public)
3. Try: Close Inspector and reopen it

---

## 🎯 INTERACTION PROBLEMS

### Problem: "Raycast doesn't detect objects"

**Debug:**
```csharp
// Add to InteractionSystem.cs DetectInteractable():
Debug.DrawRay(playerCamera.transform.position, 
              playerCamera.transform.forward * interactionRange, 
              Color.red);
```

This draws a line in Scene view showing where raycast goes.

**Solutions if raycast visible but not hitting:**
- [ ] Move object closer (default range: 3 units)
- [ ] Increase "Interaction Range" in InteractionSystem
- [ ] Object collider might be rotated wrong

---

### Problem: "Can interact from too far away"

**Solution:**
1. Select Camera
2. Find InteractionSystem script
3. Decrease "Interaction Range" (default: 3)
   - Try 2 for closer only
   - Try 5 for farther

---

## 🔄 RESET & START OVER

If everything is broken and you want to restart:

### Option 1: Delete Objects and Rebuild
1. Select problematic objects in Hierarchy
2. Delete them (right-click > Delete)
3. Recreate following CHECKLIST.md

### Option 2: Revert Scene
1. Close scene without saving (File > Close Scene)
2. Reopen it (File > Open Scene)

### Option 3: Fresh Start
1. Create new scene (File > New Scene)
2. Follow CHECKLIST.md from beginning

---

## 📋 DEBUGGING WORKFLOW

When something doesn't work:

```
1. LOOK AT CONSOLE
   └─ Is there a red error? → Fix it
   └─ No error but wrong behavior? → Continue

2. CHECK HIERARCHY
   └─ Does object exist?
   └─ Is it positioned correctly?
   └─ Is it inside the right parent?

3. CHECK INSPECTOR
   └─ Does object have right components?
   └─ Are fields assigned (not empty)?
   └─ Are values reasonable?

4. CHECK SCENE
   └─ Can I see the object?
   └─ Is it where I expect?
   └─ Is it the right size?

5. ADD DEBUG LOGS
   └─ Add Debug.Log() to script
   └─ See what values are
   └─ Is code even running?

6. TEST IN ISOLATION
   └─ Disable other objects
   └─ Test just the problematic object
   └─ Does it work alone?
```

---

## 💾 BACKUP YOUR WORK

After everything works:

1. Create a copy of your project folder
2. Upload to cloud storage
3. Or commit to git

This way if you break something, you can restore!

---

## 📞 STILL STUCK?

Try these:

1. **Check QUICK_REFERENCE.md** - Has more context
2. **Check TUTORIAL.md** - Has detailed explanations
3. **Read the script comments** - Developers left hints!
4. **Search for similar errors** - Google the error message
5. **YouTube tutorials** - Search "Unity interaction system"

---

## ✅ VERIFICATION CHECKLIST

Before moving to next feature, verify:

- [ ] No red errors in Console
- [ ] All objects visible in Scene
- [ ] Movement works (WASD)
- [ ] Camera rotates (Mouse)
- [ ] Can interact (E on objects)
- [ ] Clues display
- [ ] Items pickup
- [ ] Inventory updates

---

You've got this! 🚀
