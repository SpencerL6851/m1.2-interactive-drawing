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

        Vector2 accel = new();
        Vector2 vel = new();
        int maxSpeed = 30;
        Vector2 dronePos = new(200, 200);
        Vector2 targetPos = new(200, 200);
        bool isFollowing = true;

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
            
            
            if (isFollowing) { targetPos = Input.GetMousePosition(); } // Getting the mouse position if the drone is supposed to follow it.


            // Doing physics to calculate the acceleration, velocity, and updated position of the drone.
            accel = Vector2.Normalize(targetPos - dronePos) * 10f - (vel * 0.025f);
            vel += accel;
            Vector2.Clamp(vel, new Vector2(-maxSpeed), new Vector2(maxSpeed));
            dronePos += (vel + (0.5f * accel)) * Time.DeltaTime;
            float droneX = dronePos.X;
            float droneY = dronePos.Y;

            if (Input.IsMouseButtonPressed(0)) { isFollowing = !isFollowing; } // Toggles follow mode on click.

            Draw.SetLineColor(0);

            // Drawing drone wings.
            Draw.SetFillColor(96);
            Draw.Quad(new Vector2(droneX - 45, droneY - 35), new Vector2(droneX - 30, droneY - 35), new Vector2(droneX - 30, droneY + 30), new Vector2(droneX - 45, droneY + 30));
            Draw.Quad(new Vector2(droneX + 30, droneY - 35), new Vector2(droneX + 45, droneY - 35), new Vector2(droneX + 45, droneY + 30), new Vector2(droneX + 30, droneY + 30));
            Draw.SetFillColor(128);
            Draw.Quad(new Vector2(droneX - 25, droneY - 35), new Vector2(droneX - 20, droneY), new Vector2(droneX - 50, droneY), new Vector2(droneX - 50, droneY - 10));
            Draw.Quad(new Vector2(droneX + 25, droneY - 35), new Vector2(droneX + 20, droneY), new Vector2(droneX + 50, droneY), new Vector2(droneX + 50, droneY - 10));
            Draw.Triangle(new Vector2(droneX - 50, droneY), new Vector2(droneX - 25, droneY + 50), new Vector2(droneX - 20, droneY));            
            Draw.Triangle(new Vector2(droneX + 50, droneY), new Vector2(droneX + 25, droneY + 50), new Vector2(droneX + 20, droneY));

            // Drawing drone main body.
            Draw.Quad(new Vector2(droneX, droneY - 20), new Vector2(droneX + 20, droneY - 25), new Vector2(droneX + 25, droneY), new Vector2(droneX, droneY + 5));
            Draw.Quad(new Vector2(droneX, droneY - 20), new Vector2(droneX - 20, droneY - 25), new Vector2(droneX - 25, droneY), new Vector2(droneX, droneY + 5));
            Draw.Triangle(new Vector2(droneX + 25, droneY), new Vector2(droneX + 15, droneY + 35), new Vector2(droneX, droneY + 5));
            Draw.Triangle(new Vector2(droneX - 25, droneY), new Vector2(droneX - 15, droneY + 35), new Vector2(droneX, droneY + 5));
            Draw.Circle(droneX, droneY, 25);
            
            // Drawing drone eye.
            Draw.SetFillColor(32);
            Draw.Circle(droneX, droneY, 15);
            Draw.SetFillColor(196);
            Draw.Circle(droneX, droneY, 5);

            if (!isFollowing) // Drawing target at the target position if the drone isn't following the mouse.
            {
                Draw.SetFillColor(new Color(0, 0));
                Draw.SetLineColor(Color.Red);
                Draw.Circle(targetPos, 10);
                Draw.Line(new Vector2(targetPos.X, targetPos.Y + 15), new Vector2(targetPos.X, targetPos.Y - 15));
                Draw.Line(new Vector2(targetPos.X + 15, targetPos.Y), new Vector2(targetPos.X - 15, targetPos.Y));
            }
            
        }
    }

}
