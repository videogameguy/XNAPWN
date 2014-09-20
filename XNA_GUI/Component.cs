using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNA_GUI
{
    public class Component
    {
                
        public Rectangle Rect { get; set; }

        private bool hovering = false;
        private bool clicked = false;
        private bool released = false;

        public delegate void ComponentEvent(Component sender);

        public event ComponentEvent onMouseOver = null;
        public event ComponentEvent onMouseOut = null;
        public event ComponentEvent onMouseDown = null;
        public event ComponentEvent onMouseUp = null;
        public event ComponentEvent onClick = null;

        public Component(Rectangle whereItsAt)
        {
            Rect = whereItsAt;
            UIManager.Add(this);
        }

        public void Unload()
        {
            UIManager.Unload(this);
        }

        public void Update()
        {
            MouseState mouse = Mouse.GetState();

            if (Rect.Contains(mouse.X, mouse.Y))
            {
                if (!hovering)
                    if (onMouseOver != null)
                    onMouseOver(this);

                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    if (onMouseDown != null)
                        onMouseDown(this);

                    clicked = true;
                    released = false;
                }

                else if (mouse.LeftButton == ButtonState.Released)
                {
                    if (!released)                   
                        if (onMouseUp != null)
                            onMouseUp(this);

                    if (clicked)
                        if (onClick != null)
                            onClick(this);
                   
                        clicked = false;
                        released = true;                    
                }

                hovering = true;
            }
            else
            {
                if (hovering)
                    if (onMouseOut != null)
                        onMouseOver(this);

                hovering = false;
            }
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
     

    }
}
