using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace AtelierXNA
{
   public class ArrièrePlanDéroulant : ArrièrePlan
   {
      const float DÉPLACEMENT_HORIZONTAL = 0.2f;
      float IntervalMAJ { get; set; }
      float TempsÉcouléDepuisMAJ { get; set; }
      protected float Échelle { get; private set; }
      protected Vector2 PositionÉcran { get; set; }
      protected Vector2 TailleImage { get; set; }

      public ArrièrePlanDéroulant(Game jeu, string nomImage, float intervalMAJ)
         : base(jeu, nomImage)
      {
         IntervalMAJ = intervalMAJ;
      }

      public override void Initialize()
      {
         TempsÉcouléDepuisMAJ = 0;
         base.Initialize();
      }

      protected override void LoadContent()
      {
         base.LoadContent();
         PositionÉcran = new Vector2(Game.Window.ClientBounds.Width / 2, 0);
         Échelle = MathHelper.Max(Game.Window.ClientBounds.Width / (float)ImageDeFond.Width,
                                  Game.Window.ClientBounds.Height / (float)ImageDeFond.Height);
         TailleImage = new Vector2(ImageDeFond.Width * Échelle, 0);
      }
      public override void Update(GameTime gameTime)
      {
         float TempsÉcoulé = (float)gameTime.ElapsedGameTime.TotalSeconds;
         TempsÉcouléDepuisMAJ += TempsÉcoulé;
         if (TempsÉcouléDepuisMAJ >= IntervalMAJ)
         {
            EffectuerMiseÀJour();
            TempsÉcouléDepuisMAJ = 0;
         }
      }

      protected virtual void EffectuerMiseÀJour()
      {
         PositionÉcran = new Vector2((PositionÉcran.X + DÉPLACEMENT_HORIZONTAL) % TailleImage.X, 0);
      }

      protected override void Afficher(GameTime gameTime)
      {
         GestionSprites.Draw(ImageDeFond, PositionÉcran, null, Color.White, 0, Vector2.Zero, Échelle, SpriteEffects.None, ARRIÈRE_PLAN);
         GestionSprites.Draw(ImageDeFond, PositionÉcran - TailleImage, null, Color.White, 0, Vector2.Zero, Échelle, SpriteEffects.None, ARRIÈRE_PLAN);
      }
   }
}