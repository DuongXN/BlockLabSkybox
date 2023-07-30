using UnityEngine;
using UnityEngine.UI;

namespace BlockadeLabs_SDK_Unity.Runtime
{
    public class DrawingManager : MonoBehaviour
    {
        public Texture2D drawingTexture;
        private RawImage drawingImage;
        private bool isDrawing = false;

        void Start()
        {
            drawingImage = GetComponent<RawImage>();
            drawingTexture = new Texture2D(256, 256, TextureFormat.ARGB32, false);
            drawingTexture.filterMode = FilterMode.Point;
            drawingImage.texture = drawingTexture;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDrawing = true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isDrawing = false;
            }

            if (isDrawing)
            {
                Vector2 localCursor;
                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(drawingImage.rectTransform, Input.mousePosition, null, out localCursor))
                {
                    Vector2Int pixelPos = new Vector2Int(
                        Mathf.RoundToInt((localCursor.x + drawingImage.rectTransform.pivot.x * drawingImage.rectTransform.rect.width) / drawingImage.rectTransform.rect.width * drawingTexture.width),
                        Mathf.RoundToInt((localCursor.y + drawingImage.rectTransform.pivot.y * drawingImage.rectTransform.rect.height) / drawingImage.rectTransform.rect.height * drawingTexture.height)
                    );

                    Color color = Color.black; // You can change the drawing color here
                    drawingTexture.SetPixel(pixelPos.x, pixelPos.y, color);
                    drawingTexture.Apply();
                }
            }
        }
    }
}