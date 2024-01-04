using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Pacman_2
{
    public class Snack
    {
        public enum SnackType { Small, Big, Cherry, Apple, Strawberry };
        public SnackType snackType;
        private Vector2 gridPosition;
        private int[] gridTile;
        public int scoreGain;
        private Rectangle smallSnackRect = new Rectangle(33, 33, 6, 6);
        private Rectangle bigSnackRect = new Rectangle(24, 72, 24, 24);
        private int radiusOffSet;
        private int timerBigSnack = 20;
        private Rectangle cherrySnackRect = new Rectangle(1470, 151, 34, 35);
        private Rectangle appleSnackRect = new Rectangle(1609, 146, 38, 38);
        private Rectangle strawSnackRect = new Rectangle(1517, 151, 34, 35);
        public static int cherryAppearanceDelay = 400; // Delay in frames (20 frames per second)
        public static int appleAppearanceDelay = 800;  // Delay for the apple after the cherry (40 seconds)
        public static int strawAppearanceDelay = 1200;  // Delay for the strawberry after the apple (60 seconds)
        public static int timerCherrySnack = 160; // 8 seconds with a 20fps timer
        public static int timerAppleSnack = 160;  // 8 seconds with a 20fps timer
        public static int timerStrawberrySnack = 160;  // 8 seconds with a 20fps timer
        public Vector2 Position
        {
            get { return gridPosition; }
        }
        public Snack()
        {

        }

        public Snack(int cherryAppearanceDelay, int appleAppearanceDelay, int strawAppearanceDelay, int timerCherrySnack, int timerAppleSnack, int timerStrawberrySnack)
        {
            cherryAppearanceDelay = 400;
            appleAppearanceDelay = 800;
            strawAppearanceDelay = 1200;

            timerCherrySnack = 160;
            timerAppleSnack = 160;
            timerStrawberrySnack = 160;
        }

        public Snack(SnackType newSnackType, Vector2 newPosition, int[] newGridTile)
        {
            snackType = newSnackType;
            if (newSnackType == SnackType.Big)
            {
                scoreGain = 50;
                radiusOffSet = 12;
            }
            else if (newSnackType == SnackType.Small)
            {
                scoreGain = 10;
                radiusOffSet = 3;
            }
            else if (newSnackType == SnackType.Cherry)
            {
                scoreGain = 200;
            }
            else if (newSnackType == SnackType.Apple)
            {
                scoreGain = 400;
            }
            else if (newSnackType == SnackType.Strawberry)
            {
                scoreGain = 500;
            }

            gridPosition = newPosition;
            gridTile = newGridTile;
        }


        public static void StartNewRound()
        {
            // Reset timers and delays for a new round
            cherryAppearanceDelay = 400;
            appleAppearanceDelay = 800;
            strawAppearanceDelay = 1200;
            timerCherrySnack = 160;
            timerAppleSnack = 160;
            timerStrawberrySnack = 160;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (snackType == SnackType.Small)
                Game1.spriteSheet1.drawSprite(spriteBatch, smallSnackRect, new Vector2(gridPosition.X + Controller.tileWidth / 2 - radiusOffSet, gridPosition.Y + Controller.tileHeight / 2 - radiusOffSet));
            else if (snackType == SnackType.Big)
            {
                if (timerBigSnack >= 10 || Game1.gamePauseTimer > 0)
                    Game1.spriteSheet1.drawSprite(spriteBatch, bigSnackRect, new Vector2(gridPosition.X + Controller.tileWidth / 2 - radiusOffSet, gridPosition.Y + Controller.tileHeight / 2 - radiusOffSet));
                timerBigSnack -= 1;
                if (timerBigSnack < 0)
                {
                    timerBigSnack = 20;
                }
            }
            else if (snackType == SnackType.Cherry)
            {
                if (cherryAppearanceDelay > 0)
                {
                    cherryAppearanceDelay -= 1;
                }
                else if (timerCherrySnack > 0)
                {
                    Game1.spriteSheet1.drawSprite(spriteBatch, cherrySnackRect, new Vector2(gridPosition.X - radiusOffSet, gridPosition.Y - radiusOffSet));
                    timerCherrySnack -= 1;
                }
                else
                {
                    // Cherry timer has expired, remove the cherry
                    snackType = SnackType.Small; 
                }
            }
            else if (snackType == SnackType.Apple)
            {
                if (appleAppearanceDelay > 0)
                {
                    appleAppearanceDelay -= 1;
                }
                else if (timerAppleSnack > 0)
                {
                    Game1.spriteSheet1.drawSprite(spriteBatch, appleSnackRect, new Vector2(gridPosition.X - radiusOffSet, gridPosition.Y - radiusOffSet));
                    timerAppleSnack -= 1;
                }
                else
                {
                    // Apple timer has expired, remove the apple
                    snackType = SnackType.Small; 
                }
            }
            else if (snackType == SnackType.Strawberry)
            {
                if (strawAppearanceDelay > 0)
                {
                    strawAppearanceDelay -= 1;
                }
                else if (timerStrawberrySnack > 0)
                {
                    Game1.spriteSheet1.drawSprite(spriteBatch, strawSnackRect, new Vector2(gridPosition.X - radiusOffSet, gridPosition.Y - radiusOffSet));
                    timerStrawberrySnack -= 1;
                }
                else
                {
                    // Strawberry timer has expired, remove the strawberry
                    snackType = SnackType.Small;
                }
            }
        }
    }
}