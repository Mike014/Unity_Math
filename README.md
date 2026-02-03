# Math for Unity: Applied Formulas & Concepts

This repository acts as a practical interactive guide to the essential mathematics behind game development in Unity. It translates abstract mathematical formulas into visual, playable C# examples.

The goal is to move beyond theory and show **how** math is used to solve common gameplay problems like movement, targeting, physics reflections, and collision detection.

---

## Project Overview

The project is divided into key modules, each focusing on a specific mathematical pillar described in the *Math for Unity* curriculum.

### 1. Foundations & Optimization

Understanding space and the trade-offs between precision and performance.

* **Coordinate Systems:** Visualizing Cartesian 3D space (X, Y, Z).
* **Bounding Boxes (AABB):** Demonstrating the "Pizza Box" analogy. How to sacrifice precision for speed using simple geometric shapes for collision detection.

### 2. Distances & Proximity

* **Pythagorean Theorem:** Calculating distances between objects manually vs. using `Vector3.Distance`.
* **Bounding Spheres:** Implementing simple collision checks using center points and radii .

---

## Core Mechanics

### 3. Vector Algebra

The engine of movement. This module demonstrates:

* **Scaling:** Modifying magnitude (speed) without changing direction.
* **Normalization:** Creating Unit Vectors (length = 1) for pure direction.
* **Vector Addition:** Combining forces (e.g., `PlayerVelocity + WindForce`).

### 4. Dot Product & Cross Product (The Toolkit)

A deep dive into the two most critical operations for game logic.

| Operation | Output | Key Question | Applications in Repo |
| --- | --- | --- | --- |
| **Dot Product**  | Scalar (Number) | *"Are we aligned?"* | FOV detection ("Is the player looking at me?"), Vector Projections. |
| **Cross Product**  | Vector | *"What is perpendicular?"* | Calculating surface Normals, building local axis frames. |

---

### 5. 2D Planes in 3D Space

Handling interactions with walls, floors, and surfaces.

* **Plane Equation:** Visualizing .
* **Plane Construction:**
* Deriving a plane Normal from **3 Points** (Triangle) using the Cross Product.

* **Interactions:**
* **Ray Casting:** Using the Dot Product denominator to calculate Line-Plane intersection.
* **Shadow Projection:** Flattening a 3D object onto a plane.
* **Specular Reflection:** The "Bounce" formula.

---

## How to Use

1. **Clone the Repository:**
```bash
git clone https://github.com/Mike014/Math_for_Unity.git

```

2. **Open in Unity:**
* Load the project in Unity [Version 2022.3+ Recommended].

3. **Enable Gizmos:**
* Most visualizations rely on `OnDrawGizmos`. Ensure **Gizmos** are toggled **ON** in the Scene View to see the vectors, rays, and planes.

4. **Play & Modify:**
* Open the scenes in the `Scenes/` folder.
* Move the GameObjects labeled `PointA`, `PointB`, or `Player` to see calculations update in real-time.

## 📝 License

This project is for educational purposes. Feel free to use the code snippets in your own projects.
