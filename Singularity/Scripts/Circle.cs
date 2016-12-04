using Singularity;
using Singularity.Physics;
using Singularity.Input;

namespace Singularity.Core
{
    public class Circle : ScriptBehaviour
    {
        //GameObject firstObj = new GameObject("circle1");
        GameObject secondObj = new GameObject("circle2");

        //CircleCollider2D circle1;
        CircleCollider2D circle2;

        //SpriteRenderer sprite1;
        SpriteRenderer sprite2;

        BodyCircle b;

        public override void Start()
        {
            //sprite1 = firstObj.AddComponent<SpriteRenderer>();
            sprite2 = secondObj.AddComponent<SpriteRenderer>();

            //sprite1.texture = System.Drawing.Image.FromFile(@"C:\Users\Adrien\player.png");
            sprite2.texture = System.Drawing.Image.FromFile(@"C:\Users\Adrien\player.png");

            //circle1 = firstObj.AddComponent<CircleCollider2D>();
            circle2 = secondObj.AddComponent<CircleCollider2D>();

            //b = firstObj.AddComponent<BodyCircle>();

            secondObj.transform.position = new Vector2(3, 0);
        }

        public override void Update()
        {
            //if(Input.Input.GetKey(System.Windows.Forms.Keys.D))
            //{
            //    firstObj.transform.Translate(new Vector2(1f * Time.deltaTime, 0f));
            //}
            //if (Input.Input.GetKey(System.Windows.Forms.Keys.Z))
            //{
            //    firstObj.transform.Translate(new Vector2(0, -1f * Time.deltaTime));
            //}
            //if (Input.Input.GetKey(System.Windows.Forms.Keys.Q))
            //{
            //    firstObj.transform.Translate(new Vector2(-1f * Time.deltaTime, 0f));
            //}
            //if (Input.Input.GetKey(System.Windows.Forms.Keys.S))
            //{
            //    firstObj.transform.Translate(new Vector2(0, 1f * Time.deltaTime));
            //}

            if (Input.Input.GetMouseButtonDown(Input.Input.MouseButton.Left))
            {
                
            }

            Ray r = new Ray(Input.Input.GetMouseWorldPosition(), Vector2.right + Vector2.down);
            r.Show();
            RayHitInfo hit = r.Cast();
            //print(Input.Input.GetMouseWorldPosition());
            if (hit.collider != null)
            {
                print(string.Format("[{0}] {1}", Time.time, hit.distance));
            }
        }
    }
}