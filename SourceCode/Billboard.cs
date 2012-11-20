using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public static class Billboard
{
    #region positions
    static Vector3[] positions = new Vector3[]
    {
        new Vector3(    0.5f,   0,  1),
        new Vector3(    -0.5f,  0,  1),
        new Vector3(    0.5f,   0,  0),
        new Vector3(    -0.5f,  0,  0),
    };
    #endregion
    #region texturePoints
    static Vector2[] texturePoints = new Vector2[]
    {
        new Vector2(    0,  0),
        new Vector2(    1,  0),
        new Vector2(    0,  1),
        new Vector2(    1,  1),
    };
    #endregion
    #region vertexes
    static VertexPositionTexture[] vertexes = new VertexPositionTexture[]
    {
        new VertexPositionTexture(positions[0],texturePoints[0]),
        new VertexPositionTexture(positions[1],texturePoints[1]),
        new VertexPositionTexture(positions[2],texturePoints[2]),
        new VertexPositionTexture(positions[3],texturePoints[3]),
    };
    #endregion

    static VertexBuffer vBuffer;

    static VertexBuffer CreateVertexBuffer(GraphicsDevice device)
    {
        VertexBuffer buffer = new VertexBuffer(device, VertexPositionTexture.VertexDeclaration, 4, BufferUsage.WriteOnly);
        buffer.SetData<VertexPositionTexture>(vertexes);
        return buffer;

    }
    public static void draw(GraphicsDevice device)
    {
        if (vBuffer == null)
        {
            vBuffer = CreateVertexBuffer(device);
        }
        device.SetVertexBuffer(vBuffer);
        device.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2);
    }
}