using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Skymon_Project
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Pokemon : Microsoft.Xna.Framework.GameComponent
    {
        const int MAX_POKEDEX_NUMBER = 151;
        const int MIN_POKEDEX_NUMBER = 0;

        int pokedexNumber;
        int ptsVie;

        protected int PtsVie
        {
            get { return ptsVie; }
            set
            {
                if (ConditionVie())
                    ptsVie = value;
            }
        }
        private bool ConditionVie()
        {

        }

        protected int PokedexNumber
        {
            get { return pokedexNumber; }
            set
            {
                if (value <= 151 && value > 0)
                {
                    pokedexNumber = value;
                }
            }
        }
        public Pokemon(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }
    }
}
