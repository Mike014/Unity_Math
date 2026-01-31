# Unity Math Lab

An educational laboratory designed to master fundamental 3D math concepts in Unity using interactive scripts and visual debugging techniques.

## Overview

This project was created as an educational resource to understand the mathematics behind game development, specifically focusing on **collision detection** and vector operations.

## Requirements

* **Unity**: 2022.3.62f3 (LTS) or higher
* **Language**: C#

## Project Structure

```
Assets/
├── Scripts/
│   ├── Bounding Box/       # Scripts for AABB collision detection
│   └── Bounding Spheres/   # Scripts for spherical collision detection
└── Scenes/
    └── SampleScene.unity   # Demo scene

```

## Mathematical Concepts

### Bounding Box (AABB)

The `Bounding Box` folder contains 5 scripts implementing collision detection via **Axis-Aligned Bounding Boxes**:

| Script | Description |
| --- | --- |
| `BoundingBox3D.cs` | Calculates 3D bounding box properties (center, size) |
| `BoundingBox3DCollision.cs` | Implements AABB collision detection using Min/Max comparison |
| `IntervalMinMax.cs` | Checks if a point is contained within a 3D volume |
| `IntervalOverlap.cs` | Detects 1D interval overlap and calculates intersection |
| `SimpleCollision.cs` | Wrapper using Unity's `Bounds.Intersects()` |

**Key Concepts:**

* Vector arithmetic (addition, subtraction)
* Min/Max calculation
* Separating Axis Theorem (SAT)
* Interval overlap logic

### Bounding Spheres

The `Bounding Spheres` folder contains 5 scripts for sphere-based collision detection:

| Script | Description |
| --- | --- |
| `Sphere.cs` | Calculates distance between two points |
| `DistanceBetweenTwoPositions.cs` | Demonstrates distance calculation (manual vs. Unity) |
| `FindRadius.cs` | Calculates sphere radius from center and surface points |
| `IsInsideOutside.cs` | Checks if a point is inside or outside a sphere |
| `SphereVSSphere.cs` | Template for sphere-sphere collision |

**Key Concepts:**

* 3D Distance Formula (Euclidean distance)
* Pythagorean Theorem extended to 3 dimensions
* Vector Magnitude calculation
* Point-in-sphere test

## Mathematical Formulas

### Distance between two points

```
d = √[(x₂-x₁)² + (y₂-y₁)² + (z₂-z₁)²]

```

### AABB Collision

Two bounding boxes collide if they overlap on all three axes:

```
collision = (A.min.x ≤ B.max.x && A.max.x ≥ B.min.x) &&
            (A.min.y ≤ B.max.y && A.max.y ≥ B.min.y) &&
            (A.min.z ≤ B.max.z && A.max.z ≥ B.min.z)

```

### Sphere-Sphere Collision

Two spheres collide if the distance between centers is less than the sum of their radii:

```
collision = distance(centerA, centerB) < radiusA + radiusB

```

## Visual Debugging

The project extensively uses Unity **Gizmos** for visualization:

* `Gizmos.DrawCube()` / `Gizmos.DrawWireCube()` - Bounding boxes
* `Gizmos.DrawSphere()` / `Gizmos.DrawWireSphere()` - Spheres
* `Gizmos.DrawLine()` - Lines and distances
* Color feedback: **green** = no collision, **red** = collision

## How to Use

1. Open the project in Unity
2. Load `SampleScene`
3. Select objects in the scene to view parameters in the Inspector
4. Press Play and observe the Gizmos in the Scene view
5. Modify parameters in real-time to experiment

## Learning Objectives

* Understand how collision detection works mathematically
* Vector operations and their geometric interpretation
* Distance and magnitude calculations in 3D space
* Differences between AABB and spherical approaches
* Visual debugging techniques for spatial algorithms

## Author

Project created as an educational exercise for the Epicode course.

## License

This project is intended for educational purposes only.

---


