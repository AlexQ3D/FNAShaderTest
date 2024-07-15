using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class FNAGame : Game
{
    [STAThread]
    static void Main(string[] args)
    {
        using (FNAGame g = new FNAGame())
        {
            g.Run();
        }
    }

    private SpriteBatch batch;
    private Texture2D texture;
    private Effect testEffect;
    
    private FNAGame()
    {
        new GraphicsDeviceManager(this);

        // All content loaded will be in a "Content" folder
        Content.RootDirectory = "Content";
    }

    protected override void LoadContent()
    {
        // Create the batch...
        batch = new SpriteBatch(GraphicsDevice);

        // ... then load a texture from ./Content/FNATexture.png
        texture = Content.Load<Texture2D>("FNATexture");
        // Effects can be loaded as content!
        testEffect = Content.Load<Effect>("FNAEffect");
    }

    protected override void UnloadContent()
    {
        batch.Dispose();
        texture.Dispose();
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        Vector2 scaleVector = Vector2.One * 8;
        // Base texture with no shader
        batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone);
        batch.Draw(texture, new Vector2(24,24), null, Color.White, 0, Vector2.Zero, scaleVector, SpriteEffects.None, 1);
        batch.End();
        
        // Base texture with shader
        batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, testEffect);
        batch.Draw(texture, new Vector2(124,24), null, Color.White, 0, Vector2.Zero, scaleVector, SpriteEffects.None, 1);

        batch.End();

        base.Draw(gameTime);
    }
}