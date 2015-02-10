﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beeautiful2
{
    class Bee : Sprite
    {
        const string BEE_ASSETNAME = "bee";
        const int START_POSITION_X = 1125;
        const int START_POSITION_Y = 145;
        const int BEE_SPEED = 160;
        const int MOVE_UP = -3;
        const int MOVE_DOWN = 3;
        const int MOVE_LEFT = -3;
        const int MOVE_RIGHT = 3;

        enum State
        {
            Flying,
            Dead
        }

        State mCurrentState = State.Flying;
        Vector2 mDirection = Vector2.Zero;
        Vector2 mSpeed = Vector2.Zero;
        KeyboardState mPreviousKeyboardState;



        public void LoadContent(ContentManager theContentManager)
        {
            Position = new Vector2(START_POSITION_X, START_POSITION_Y);
            base.LoadContent(theContentManager, BEE_ASSETNAME);

        }



        public void Update(GameTime theGameTime)
        {
            KeyboardState aCurrentKeyboardState = Keyboard.GetState();
            UpdateMovement(aCurrentKeyboardState);
            mPreviousKeyboardState = aCurrentKeyboardState;
            base.Update(theGameTime, mSpeed, mDirection);
        }




        private void UpdateMovement(KeyboardState aCurrentKeyboardState)
        {
            if (mCurrentState == State.Flying)
            {
                mSpeed = Vector2.Zero;
                mDirection = Vector2.Zero;
                if (aCurrentKeyboardState.IsKeyDown(Keys.Left) == true)
                {
                    mSpeed.X = BEE_SPEED;
                    mDirection.X = MOVE_LEFT;
                }

                else if (aCurrentKeyboardState.IsKeyDown(Keys.Right) == true)
                {
                    mSpeed.X = BEE_SPEED;
                    mDirection.X = MOVE_RIGHT;
                }



                if (aCurrentKeyboardState.IsKeyDown(Keys.Up) == true)
                {
                    mSpeed.Y = BEE_SPEED;
                    mDirection.Y = MOVE_UP;
                }

                else if (aCurrentKeyboardState.IsKeyDown(Keys.Down) == true)
                {
                    mSpeed.Y = BEE_SPEED;
                    mDirection.Y = MOVE_DOWN;
                }

            }

        }


    }
}