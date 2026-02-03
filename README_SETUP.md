# Finopoly - Project Setup Guide

I have generated the core scripts and the project structure. Follow these steps to get the game running in Unity.

## 1. Open the Project
1.  Open **Unity Hub**.
2.  Click **Open** -> **Add project from disk**.
3.  Select the folder: `c:\Users\Asus\Downloads\Devfolio`.
4.  Wait for Unity to import the assets (this might take a minute).

## 2. Generate Content
I included a magic button to create sample events for you.
1.  In the Unity Editor top menu, click **Finopoly** -> **Generate Sample Events**.
2.  Check the `Assets/Resources/Events` folder. You should see "Student" and "Adult" folders with event files inside.

## 3. Scene Setup
Since I cannot interact with the Unity Editor, you need to wire up the scene.

### A. Create the Game Manager
1.  Create an empty GameObject, name it `GameManager`.
2.  Add the `GameManager` script component.
3.  Add the `EventManager` script component.
4.  Add the `PlayerStats` script component.
5.  Add the `UIManager` script component.

### B. Create the UI
1.  In logic, right-click Hierarchy -> **UI** -> **Canvas**.
2.  **Top Panel (Stats)**:
    *   Create 3 Text(TMP) objects: `MoneyText`, `HappinessText`, `AgeText`.
3.  **Center Panel (Event)**:
    *   Create a specialized Panel (or Image) for the Event Card.
    *   Add Text(TMP) for `Title` and `Description`.
    *   Add 2 Buttons for `Choice A` and `Choice B`.
4.  **Action Panel (Bottom)**: 
    *   Add a logic-less panel for now (we'll focus on the event loop first).

### C. Link References
1.  Select the `GameManager` object.
2.  **GameManager Script**: Drag the `PlayerStats`, `EventManager`, and `UIManager` components (from the same object) into the slots.
3.  **EventManager Script**:
    *   Lock the Inspector (top right lock icon) or open two inspector windows.
    *   Drag the generated Event assets (from Step 2) into the "Student Events" list and "Adult Events" list.
4.  **UIManager Script**:
    *   Drag your UI Text objects and Buttons into the corresponding slots (`MoneyText`, `ChoiceAButton`, etc.).

## 4. Play!
*   Press **Play**.
*   You should see your stats, and an Event should appear.
*   Clicking a choice should close the event and update your money/happiness.
*   (Click "Next Turn" mechanism is currently automated in my code or needs a button linked to `GameManager.NextTurn`).

> **Tip**: Add a button to your UI calling `GameManager.Instance.NextTurn()` to advance the age manually!
