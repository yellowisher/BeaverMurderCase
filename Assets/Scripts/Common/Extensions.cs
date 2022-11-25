using UnityEngine;

namespace Common
{
    public static class Extensions
    {
        private static readonly int OutlineWidth = Shader.PropertyToID("_OutlineWidth");

        public static void SetAlpha(this SpriteRenderer renderer, float alpha)
        {
            var color = renderer.color;
            color.a = alpha;
            renderer.color = color;
        }
        
        public static Color SetAlpha(this Color color, float alpha)
        {
            color.a = alpha;
            return color;
        }

        public static void SetOutlineWidth(this SpriteRenderer renderer, float width)
        {
            var propertyBlock = new MaterialPropertyBlock();
            renderer.GetPropertyBlock(propertyBlock);
            propertyBlock.SetFloat(OutlineWidth, width);
            renderer.SetPropertyBlock(propertyBlock);
        }
    }
}
