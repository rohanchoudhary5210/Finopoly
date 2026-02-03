# 🎮 Finopoly: The Life-Sim of Dollars & Sense

> **Finopoly** is a 2D life-simulation game that transforms complex financial literacy into an engaging, choice-driven narrative. Forget spreadsheets and dry theory—in Finopoly, you learn to manage wealth by living it.

Built for the **Financial Games & Game Development** hackathon track.

---

## 🌟 The Pitch

Most people learn finance through expensive mistakes. **Finopoly** lets you make those mistakes in a safe, colorful, and strategic environment. From your first paycheck at 20 to your retirement party at 60, every decision shapes your future.

*“Will you retire a debt-free minimalist, or a high-rolling mogul with high-octane stress?”*

---

## 🔁 The Core Gameplay Loop

The game operates on a **Turn-Based Year System**. Each turn follows a specific sequence:

1.  **The Payday**: Receive income and deduct mandatory fixed costs (rent, food, tax).
2.  **The Life Event**: A random event occurs (e.g., "Car Breakdown" or "Bull Market").
3.  **The Choice**: Make a branching decision with visible trade-offs.
4.  **The Impact**: Instant visual feedback on your 4 core stats.
5.  **Optional Phase**: Micro-invest, upgrade skills, or splurge on happiness.

---

## 🧠 Game Mechanics

### 📊 The Success Quadrant
To "win" at Finopoly, you must balance four competing metrics:

| Stat | Description | Primary Driver |
| :--- | :--- | :--- |
| **💰 Wealth** | Your liquid and invested capital. | Savings and Compound Interest |
| **😊 Happiness** | Your quality of life and mental health. | Leisure spending and Life Events |
| **📘 Skill** | Your professional value and earning power. | Education and Work Experience |
| **⚠️ Risk** | Your vulnerability to market or life shocks. | Debt levels and Portfolio volatility |

### 🛠️ Strategic Financial Math
The game calculates your **Annual Financial Health ($FH$)** using a simplified weighted formula:

$$FH = \frac{(Wealth \times Skill) - (Risk \times 10)}{Happiness}$$

---

## 🎨 UI & Experience

*   **Card-Based Interaction**: Clean, modern cards for events and choices.
*   **Visual Evolution**: The character's environment changes as they move from a cramped apartment to a suburban home or a beachside retreat.
*   **Color-Coded Feedback**: Green for growth, red for loss, and amber for risk exposure.

---

## 💻 Tech Stack

*   **Engine**: Unity 2022.3 LTS (2D)
*   **Scripting**: C# (Event-driven architecture)
*   **UI**: Unity UI Toolkit for a responsive, modern look.
*   **Version Control**: Git

---

## 🚀 Getting Started

1.  **Clone the Repo**:
    ```bash
    git clone https://github.com/your-username/finopoly.git
    ```
2.  **Open in Unity**: Use **Unity Hub** to open the project folder.
3.  **Play**: Load `Assets/Scenes/MainGame.unity` and hit **Play**.

---

## 🏆 Hackathon Goals

*   **Accessibility**: Making financial jargon non-intimidating.
*   **Cause-and-Effect**: Showing the long-term power of compound interest vs. the drain of high-interest debt.
*   **Replayability**: Multiple "Archetypes" and random events ensure no two lives are the same.
