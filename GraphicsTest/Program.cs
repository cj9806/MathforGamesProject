using System;
using System.Collections.Generic;
using static Raylib_cs.Raylib;  // core methods (InitWindow, BeginDrawing())
using static Raylib_cs.Color;   // color (RAYWHITE, MAROON, etc.)
using Raylib_cs;
using MathClasses;
using System.Numerics;

namespace GraphicsTest
{
    public class core_basic_window
    {
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            const int screenWidth = 1600;
            const int screenHeight = 900;

            InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");
            //texture init
            Texture2D playerBody = LoadTexture(@"topdowntanks\PNG\Tanks\tankGreen.png");            
            Texture2D playerBarrel = LoadTexture(@"topdowntanks\PNG\Tanks\barrelGreen.png");
            Texture2D redBarrel = LoadTexture(@"topdowntanks\PNG\Obstacles\barrelRed_side.png");
            Texture2D bullet = LoadTexture(@"topdowntanks\PNG\Bullets\bulletYellowSilver.png");

            //player body info
            int bodyWidth = playerBody.width;
            int bodyHeight = playerBody.height;
            Rectangle tankSourceRec = new Rectangle(0,0, bodyWidth,bodyHeight);
            Rectangle tankDestinationRec = new Rectangle(screenWidth/2, screenHeight/2, bodyWidth*2, bodyHeight*2);
            System.Numerics.Vector2 bodyOrigin = new System.Numerics.Vector2(bodyWidth, bodyHeight);

            //player barrel info
            int barrWidth = playerBarrel.width;
            int barrHeight = playerBarrel.height;
            Rectangle barrSourceRec = new Rectangle(0, 8, barrWidth, barrHeight);
            Rectangle barrDestinationRec = new Rectangle(screenWidth/2, screenHeight/2, barrWidth * 2, barrHeight * 2);
            System.Numerics.Vector2 barrOrigin = new System.Numerics.Vector2((barrWidth/2)+10, 0);

            Rectangle barrelHitBox = new Rectangle(20, 20, 44, 62);
            SetTargetFPS(60);

            
            //System.Numerics.Vector2 barOrg = new System.Numerics.Vector2(origin.x+29, origin.y+30);
            Player player = new Player();
            float playrerRot = 0;
            float barrRot = 0;
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                // TODO: Update your variables here
                //player move step                
                if (IsKeyDown(KeyboardKey.KEY_A))
                {
                    //playerBox.Rotate(-5);
                    playrerRot -= 5;
                    barrRot -= 5;
                }
                if (IsKeyDown(KeyboardKey.KEY_D))
                {
                    //playerBox.Rotate(5);
                    playrerRot += 5;
                    barrRot += 5;
                }
                if (IsKeyDown(KeyboardKey.KEY_LEFT))
                    barrRot -= 5;
                if (IsKeyDown(KeyboardKey.KEY_RIGHT))
                    barrRot += 5;
                
                //shooting and colision


                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------
                BeginDrawing();

                ClearBackground(BROWN);
                DrawTexturePro(playerBody, tankSourceRec, tankDestinationRec, bodyOrigin, playrerRot, WHITE);
                DrawTexturePro(playerBarrel, barrSourceRec, barrDestinationRec, barrOrigin, barrRot, WHITE);
                EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            CloseWindow();        // Close window and OpenGL context
            //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}
