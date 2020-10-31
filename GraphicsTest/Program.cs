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
            Texture2D xPlode = LoadTexture(@"topdowntanks\PNG\Smoke\smokeOrange0.png");

            //player body info
            int bodyWidth = playerBody.width;
            int bodyHeight = playerBody.height;
            Rectangle tankSourceRec = new Rectangle(0,0, bodyWidth,bodyHeight);
            Rectangle tankDestinationRec = new Rectangle(screenWidth/2, screenHeight/2, bodyWidth*2, bodyHeight*2);
            System.Numerics.Vector2 bodyOrigin = new System.Numerics.Vector2(bodyWidth, bodyHeight);

            //player barrel info
            int barrWidth = playerBarrel.width;
            int barrHeight = playerBarrel.height;
            Rectangle barrSourceRec = new Rectangle(0, 0, barrWidth, barrHeight);
            Rectangle barrDestinationRec = new Rectangle(screenWidth/2, screenHeight/2, barrWidth * 2, barrHeight*2);
            System.Numerics.Vector2 barrOrigin = new System.Numerics.Vector2((barrWidth/2)+10, 0);

            //player bullet info
            int bullStartX= (screenWidth / 2) - 8;
            int bullStartY= (screenHeight / 2);
            int bullWidth = bullet.width;
            int bullHeight = bullet.height;
            Rectangle bullSource = new Rectangle(0, 0, bullWidth, bullHeight);
            Rectangle bullDest = new Rectangle(bullStartX, bullStartY, bullWidth , bullHeight);
            System.Numerics.Vector2 bullOrigin = new System.Numerics.Vector2(bullWidth-6, bullHeight);
            bool fired = false;
            Rectangle bulluetHitBox = bullDest;

            //target info
            Rectangle barrelHitBox = new Rectangle(100, 100, 44, 62);
            SetTargetFPS(60);

            
            //System.Numerics.Vector2 barOrg = new System.Numerics.Vector2(origin.x+29, origin.y+30);
            Player player = new Player();
            float playrerRot = 0;
            float barrRot = 0;
            float bullRot = 180;
            bool boom = false;

            MathClasses.Vector3 forwardVect = new MathClasses.Vector3(0, 0, 0);
            //figure out how to get the direction to fire the bullet
            //on a graph you can solve a linear equation with just 2 points so  all ineedis to figure a |starting position| and a |position on the direction of travel|
            // starting position is the 4th value in the destination rectangle for the barrel
            //movement postition is the second value on the destination rectangle


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
                    
                    playrerRot -= 5;
                    barrRot -= 5;
                    if(!fired)
                        bullRot -= 5;
                }
                if (IsKeyDown(KeyboardKey.KEY_D))
                {
                    
                    playrerRot += 5;
                    barrRot += 5; 
                    if (!fired)
                        bullRot += 5;
                }
                if (IsKeyDown(KeyboardKey.KEY_LEFT))
                {
                    if (!fired)
                        bullRot -= 3;
                    barrRot -= 3;
                }

                if (IsKeyDown(KeyboardKey.KEY_RIGHT))
                {
                    if (!fired)
                        bullRot += 3;
                    barrRot += 3;
                }

                if (IsKeyPressed(KeyboardKey.KEY_SPACE))
                {
                    fired = true;
                    Matrix3 buletrotation = new Matrix3();
                    buletrotation.RotateZ((Math.PI/180) * barrRot);
                    MathClasses.Vector3 forward = new MathClasses.Vector3(1, 0,0);
                    forwardVect = buletrotation * forward;
                    
                 }
                if (fired)
                {
                    bullDest.x += (forwardVect.y*3);
                    bullDest.y += (forwardVect.x*3);
                    if (bullDest.x < 30 || bullDest.x > 1630)
                    {
                        fired = false;
                        bullDest.x = (screenWidth / 2) - 8;
                        bullDest.y = screenHeight / 2;
                    }
                    if (bullDest.y < 30 || bullDest.y > 930)
                    {
                        fired = false;
                        bullDest.x = (screenWidth / 2) - 8;
                        bullDest.y = screenHeight / 2;
                    }
                    if (CheckCollisionRecs(bullDest, barrelHitBox))
                    {
                        boom = true;
                        fired = false;
                    }
                }

                
                
                //shooting and colision
                //press space
                // move bullet


                //

                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------
                BeginDrawing();

                ClearBackground(BROWN);
                DrawTexturePro(playerBody, tankSourceRec, tankDestinationRec, bodyOrigin, playrerRot, WHITE);
                DrawTexturePro(playerBarrel, barrSourceRec, barrDestinationRec, barrOrigin, barrRot, WHITE);
                if (!boom)
                    DrawTexture(redBarrel, 100, 100, WHITE);
                else
                    DrawTexture(xPlode, 100, 100, ORANGE);
                if (fired)
                    DrawTexturePro(bullet, bullSource, bullDest, bullOrigin, bullRot, WHITE);
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
