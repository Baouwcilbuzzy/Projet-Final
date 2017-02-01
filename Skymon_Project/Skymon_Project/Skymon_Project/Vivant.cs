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
    public abstract class Vivant : Microsoft.Xna.Framework.GameComponent
    {
        protected string Nom { get; private set; }
        public Vivant(Game game, string nom)
            : base(game)
        {
            Nom = nom;
            // TODO: Construct any child components here
        }
        public abstract bool EstEnVie();
        // ca sa va être dans la classe trainer pour avoir accès a ses pokemons
        //{
        //    foreach (Pokemon in Pokemons/*liste de pokemons que le trainer a !!!!!!*/)
        //        if (!(Pokemon.EstEnVie()))
        //        {
        //            return false;
        //        }
        //    return true;
        //}

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
