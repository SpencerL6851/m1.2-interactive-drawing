// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        ///
        /// VARIABLES
        ///

        Vector2 accel = new Vector2();
        Vector2 vel = new Vector2();
        float droneX = 200.0f;
        float droneY = 200.0f;
        Vector2 targetPos = new Vector2();
        bool isFollowing = true;
        float brakingFactor = 0.0f;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Interactive Drawing");
            Window.SetSize(400, 400);
            Draw.SetLineColor(0);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(80);












            Draw.SetFillColor(128);
            // Drawing drone wings
            Draw.Rectangle(droneX - 45, droneY - 35, 15, 65);
            Draw.Quad(new Vector2(droneX - 25, droneY - 35), new Vector2(droneX - 20, droneY), new Vector2(droneX - 50, droneY), new Vector2(droneX - 50, droneY - 10));
            Draw.Triangle(new Vector2(droneX - 50, droneY), new Vector2(droneX - 25, droneY + 50), new Vector2(droneX - 20, droneY));
            Draw.Rectangle(droneX + 30, droneY - 35, 15, 65);
            Draw.Quad(new Vector2(droneX + 25, droneY - 35), new Vector2(droneX + 20, droneY), new Vector2(droneX + 50, droneY), new Vector2(droneX + 50, droneY - 10));
            Draw.Triangle(new Vector2(droneX + 50, droneY), new Vector2(droneX + 25, droneY + 50), new Vector2(droneX + 20, droneY));

            // Drawing drone main body
            Draw.Quad(new Vector2(droneX, droneY - 20), new Vector2(droneX + 20, droneY - 25), new Vector2(droneX + 25, droneY), new Vector2(droneX, droneY + 5));
            Draw.Triangle(new Vector2(droneX + 25, droneY), new Vector2(droneX + 15, droneY + 35), new Vector2(droneX, droneY + 5));
            Draw.Quad(new Vector2(droneX, droneY - 20), new Vector2(droneX - 20, droneY - 25), new Vector2(droneX - 25, droneY), new Vector2(droneX, droneY + 5));
            Draw.Triangle(new Vector2(droneX - 25, droneY), new Vector2(droneX - 15, droneY + 35), new Vector2(droneX, droneY + 5));
            Draw.Circle(droneX, droneY, 25);
            
            // Drawing drone eye
            Draw.SetFillColor(194);
            Draw.Circle(droneX, droneY, 15);
            Draw.SetFillColor(96);
            Draw.Circle(droneX, droneY, 5);

        }
    }

}
