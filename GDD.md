# Finopoly - Game Design Document (GDD)

**Version**: 2.0 (Board Game Update)
**Theme**: Life Simulation Board Game

---

## 1. High-Level Concept
**Finopoly** is a turn-based life simulation board game where financial literacy is taught through cause-and-effect gameplay. The player moves a token along a "Life Path" (similar to *Game of Life*), dealing with events, expenses, and career moves as they age from student to retiree.

**Goal**: Reach the "Retirement" node with the highest possible **Net Worth** and **Happiness**.

---

## 2. Core Mechanics

### A. The Board System
The game is played on a linear or branching path of nodes.
*   **Movement**: Players spin a wheel (or roll dice) to move 1-6 spaces forward.
*   **Time**: Each node represents a passage of time (e.g., 1 Month) or a significant event. The player "Ages" as they progress.

### B. Node Types
The board is populated with different colored nodes:
1.  **🔵 Standard Node**: Nothing happens (or small flavor text).
2.  **🔴 Event Node**: Triggers a **Random Event Card** (Car crash, Job offer, Fee hike).
3.  **🟡 Payday Node**: Player receives their Salary.
4.  **🟢 Decision Node**: Mandatory choice (e.g., Choose College Major, Buy vs Rent House).
5.  **🏁 End Node**: Retirement/Score Calculation.

### C. Player Stats
Values the player must manage:
*   **💰 Money**: currency for transactions. Game Over if < -$5000.
*   **😁 Happiness**: (0-100%). Game Over if 0. Affects final score.
*   **🎓 Career/Skill**: (1-10). Higher skill = Higher Payday income.

---

## 3. Gameplay Loop
```mermaid
graph TD
    Start[Spin Wheel] --> Move[Move Token X Steps]
    Move --> Land[Land on Node]
    Land --> CheckType{Node Type?}
    
    CheckType -- Payday --> GetMoney[Gain Salary]
    CheckType -- Event --> DrawCard[Draw Event Card]
    CheckType -- Standard --> EndTurn
    
    DrawCard --> Choice[Player Makes Choice]
    Choice --> Resolve[Update Stats (Money/Happy)]
    
    GetMoney --> EndTurn
    Resolve --> EndTurn
    
    EndTurn --> CheckWin{Retired?}
    CheckWin -- No --> Start
    CheckWin -- Yes --> WinScreen
```

---

## 4. UI & Controls
*   **Main View**: 2D Side-scrolling or Top-down view of the Board.
*   **HUD (Top)**:
    *   Money Counter ($)
    *   Happiness Bar (😁)
    *   Age Indicator
*   **Controls (Bottom)**: 
    *   Big **"SPIN"** Button.
*   **Event Popup**:
    *   Appears over the board when an Event Node is hit.
    *   Title, Image, and 2 Decision Buttons.

---

## 5. Content Data
### Life Stages
The board is thematically divided into zones:
1.  **Student Zone**:
    *   *Events*: Part-time jobs, Exams, Tuition fees, Parties.
    *   *Economy*: Low income, high expense.
2.  **Young Adult Zone**:
    *   *Events*: Rent, Dating, First Car, Promotions.
    *   *Economy*: Building savings, first debts.
3.  **Professional Zone**:
    *   *Events*: Mortgages, Stock Market, Children, Medical bills.
    *   *Economy*: High income, high risk investment opportunities.

---

## 6. Future Expansion Ideas
*   **Mini-Games**: Instead of just rolling dice, play a mini-game to determine income?
*   **Stock Market**: A separate menu to buy/sell stocks that fluctuate every turn.
*   **Branching Paths**: "Safe Path" (University = Debt but High Pay) vs "Risky Path" (Startup = Low cost but Variable Pay).
