﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;
using System.Diagnostics;

namespace AtelierXNA
{
   public class Atelier : Microsoft.Xna.Framework.Game
   {
      const float INTERVALLE_CALCUL_FPS = 1f;
      const float INTERVALLE_MAJ_STANDARD = 1f / 60f;
      GraphicsDeviceManager PériphériqueGraphique { get; set; }

      Caméra CaméraJeu { get; set; }
      InputManager GestionInput { get; set; }

      public Atelier()
      {
         PériphériqueGraphique = new GraphicsDeviceManager(this);
         Content.RootDirectory = "Content";
         PériphériqueGraphique.SynchronizeWithVerticalRetrace = false;
         IsFixedTimeStep = false;
         IsMouseVisible = false;
         //PériphériqueGraphique.PreferredBackBufferWidth = 800;
         //PériphériqueGraphique.PreferredBackBufferHeight = 480;
         //PériphériqueGraphique.IsFullScreen = true;
      }

      protected override void Initialize()
      {
         GestionInput = new InputManager(this);
         Components.Add(GestionInput);
         CaméraJeu = new CaméraFixe(this, new Vector3(0, 0, -3), Vector3.Zero, Vector3.Up);
         Components.Add(CaméraJeu);
         Components.Add(new Afficheur3D(this));
         Components.Add(new SphèreTexturée(this, 1, new Vector3(0, 0, 0), Vector3.Zero, 1, new Vector2(10, 10), "Pokeball", INTERVALLE_MAJ_STANDARD));
         Components.Add(new AfficheurFPS(this, "Arial", Color.Red, INTERVALLE_CALCUL_FPS));

         Services.AddService(typeof(Random), new Random());
         Services.AddService(typeof(RessourcesManager<SpriteFont>), new RessourcesManager<SpriteFont>(this, "Fonts"));
         Services.AddService(typeof(RessourcesManager<Texture2D>), new RessourcesManager<Texture2D>(this, "Textures"));
         Services.AddService(typeof(InputManager), GestionInput);
         Services.AddService(typeof(Caméra), CaméraJeu);
         Services.AddService(typeof(SpriteBatch), new SpriteBatch(GraphicsDevice));
         base.Initialize();
      }
      protected override void Update(GameTime gameTime)
      {
         NettoyerListeComponents();
         GérerClavier();
         base.Update(gameTime);
      }

      void NettoyerListeComponents()
      {
         for (int i = Components.Count - 1; i >= 0; --i)
         {
            if (Components[i] is IDestructible && ((IDestructible)Components[i]).ÀDétruire)
            {
               Components.RemoveAt(i);
            }
         }
      }

      private void GérerClavier()
      {
         if (GestionInput.EstEnfoncée(Keys.Escape))
         {
            Exit();
         }
      }

      protected override void Draw(GameTime gameTime)
      {
         GraphicsDevice.Clear(Color.Black);
         base.Draw(gameTime);
      }
   }
}

