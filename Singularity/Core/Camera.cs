namespace Singularity.Core
{
    public static class Camera
    {
        public static Transform2D transform = new Transform2D();
        public static float orthographicSize = 10;

        public static float Ratio
        {
            get
            {
                if (GameSettings.screenSize.x > GameSettings.screenSize.y)
                {
                    return (float)GameSettings.screenSize.x / (float)GameSettings.screenSize.y;
                }
                else
                {
                    return (float)GameSettings.screenSize.y / (float)GameSettings.screenSize.x;
                }
            }
        }

        public static Vector2 WindowToWorldPoint(Vector2 pos)
        {
            float x, y;
            if (GameSettings.screenSize.x > GameSettings.screenSize.y)
            {
                x = Mathf.Lerp((-Camera.orthographicSize / 2) * Ratio, (Camera.orthographicSize / 2) * Ratio, pos.x / GameSettings.screenSize.x);
                y = Mathf.Lerp((-Camera.orthographicSize / 2), (Camera.orthographicSize / 2), pos.y / GameSettings.screenSize.y);
            }
            else
            {
                x = Mathf.Lerp((-Camera.orthographicSize / 2), (Camera.orthographicSize / 2), pos.x / GameSettings.screenSize.x);
                y = Mathf.Lerp((-Camera.orthographicSize / 2) * Ratio, (Camera.orthographicSize / 2) * Ratio, pos.y / GameSettings.screenSize.y);
            }
            return new Vector2(x, y);
        }
    }
}