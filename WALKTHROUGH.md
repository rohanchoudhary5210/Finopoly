# Finopoly - Complete Walkthrough & Setup Guide

Welcome to Finopoly! This guide covers everything from opening the project to playing the prototype.

## Part 1: Initial Project Setup
1.  **Open Unity Hub**.
2.  Click **Open** -> **Add project from disk**.
3.  Select the folder: `c:\Users\Asus\Downloads\Devfolio`.
4.  Wait for Unity to import the assets (this might take a minute).

## Part 2: Generating Game Content
I have included a custom tool to generate the game events for you.
1.  In the Unity Editor top menu, click **Finopoly** -> **Generate Sample Events**.
2.  Check the `Assets/Resources/Events` folder. You should see "Student" and "Adult" folders with event files inside.

## Part 3: Wiring the Scene (The Most Important Part!)
Since I wrote the scripts but cannot "touch" the Unity Editor, you must wire the components together manually.

### A. The Hierarchy Structure
Create your Scene Hierarchy to look like this:
```mermaid
graph TD
    Scene[Scene: MainGame]
    GM[GameManager (GameObject)]
    Canvas[Canvas (UI)]
    ES[EventSystem]

    Scene --> GM
    Scene --> Canvas
    Scene --> ES

    Canvas --> TP[TopPanel_Stats]
    Canvas --> CP[CenterPanel_Event]
    Canvas --> AP[ActionPanel_Bottom]
```

### B. Configuring the GameManager
1.  Select the `GameManager` GameObject.
2.  Ensure it has **4 Components**: `GameManager`, `PlayerStats`, `EventManager`, `UIManager`.
3.  **Link the Scripts**:
    - Drag the `PlayerStats` component header into the **Player Stats** slot on `GameManager`.
    - Drag `EventManager` into the **Event Manager** slot.
    - Drag `UIManager` into the **Ui Manager** slot.

### C. Configuring the EventManager
1.  Locate the **Student Events** and **Adult Events** lists in the `EventManager` component.
2.  Drag all `.asset` files from `Assets/Resources/Events/Student` into the **Student Events** list.
3.  Drag all `.asset` files from `Assets/Resources/Events/Adult` into the **Adult Events** list.

### D. Configuring the UIManager
1.  Create your UI elements (Text and Buttons) in the Canvas.
2.  Select `GameManager` (where UIManager is attached).
3.  Drag your UI objects into the corresponding slots:
    - `MoneyText`, `HappinessText`, `AgeText`
    - `EventTitle`, `EventDescription`
    - `ChoiceAButton`, `ChoiceBButton`

## Part 4: How to Play
1.  Press **Play** in Unity.
2.  **Turn 1**: You start at Age 18.
3.  **Event**: A random event (e.g., "Part Time Job") will appear.
4.  **Choice**: Click a button to decide. Your Money/Happiness will update.
5.  **Next Turn**: If you didn't add a manual "Next Turn" button, the game loop might need a trigger.
    *   *Pro Tip*: Add a button to your UI, click `+` on OnClick, drag in GameManager, and select `GameManager.NextTurn()`.

## Troubleshooting
*   **"NullReferenceException"**: This usually means you forgot to drag a slot in the Inspector (Step 3).
*   **"No Events Found"**: You forgot to generate events (Step 2) or drag them into the EventManager list (Step 3C).
