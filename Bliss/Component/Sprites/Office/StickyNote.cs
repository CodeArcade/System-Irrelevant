using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using MonoGame.Extended.Tweening;
using Bliss.Models;
using Size = System.Drawing.Size;
using MonoGame.Extended;
using Microsoft.Xna.Framework.Input;
using FontStashSharp;
using MonoGame.Extended.Content;
using Myra.Graphics2D.UI;
using Bliss.Component.Sprites.Ui;

namespace Bliss.Component.Sprites.Office
{
    public class StickyNote : Clickable
    {
        public Vector2 OriginPosition { get; set; }
        public int TweenOffset { get; set; }
        private readonly Tweener Tweener = new Tweener();

        private bool IsExtending { get; set; } = false;
        private bool IsRetracting { get; set; } = false;

        public bool CanHover { get; set; } = true;

        public Dictionary<OrganizerIds, List<Rule>> ActiveRules { get; set; } = new Dictionary<OrganizerIds, List<Rule>>();

        public StickyNote() : base()
        {
            Texture = ContentManager.StickyNoteTexture;
            Size = SizeManager.GetSize(Texture.Width / 2, Texture.Height / 2);
        }

        public void Extend()
        {
            Tweener.TweenTo(target: this, duration: 0.3f, expression: note => note.Position, toValue: new Vector2(OriginPosition.X + TweenOffset, OriginPosition.Y))
                .Easing(EasingFunctions.CircleOut);
            IsExtending = true;
            IsRetracting = false;
        }

        public void Retract()
        {
            Tweener.TweenTo(target: this, duration: 0.3f, expression: organizer => organizer.Position, toValue: OriginPosition)
                .Easing(EasingFunctions.CircleOut);
            IsRetracting = true;
            IsExtending = false;
        }

        public override void Update(GameTime gameTime)
        {
            UpdateHover();
            Tweener.Update(gameTime.GetElapsedSeconds());
            base.Update(gameTime);
        }

        public void UpdateHover()
        {
            if (!CanHover) return;

            if (!IsMouseInsideWindow())
            {
                Retract();
                return;
            }
            if (IsMouseOverStickyNote() && !IsExtending)
            {
                Extend();
            }

            if (!IsMouseOverStickyNote() && !IsRetracting)
            {
                Retract();
            }
        }

        public List<Component> GetDetailViewComponents()
        {
            Size size = SizeManager.GetSize(450, 450);

            Sprite sprite = new Sprite()
            {
                Size = size,
                Position = new Vector2(
                        (int)(SizeManager.ScaleForWidth(SizeManager.JamGame.BaseWidth) - size.Width) / 2,
                        (int)(SizeManager.ScaleForHeight(SizeManager.JamGame.BaseHeight) - size.Height) / 2
                    ),
                Texture = ContentManager.StickyNoteTexture
            };

            FontSystem fontSystem = new FontSystem();
            fontSystem.AddFont(SizeManager.JamGame.Content.OpenStream("Fonts/Arial.ttf"));

            Grid grid = new Grid();
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Width));
            // 20 Lines for rules
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height * 0.05f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height * 0.05f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height * 0.05f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height * 0.05f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height * 0.05f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height * 0.05f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height * 0.05f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height * 0.05f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height * 0.05f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height * 0.05f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height * 0.05f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height * 0.05f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height * 0.05f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height * 0.05f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height * 0.05f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height * 0.05f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height * 0.05f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height * 0.05f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height * 0.05f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height * 0.05f));

            List<Rule> rules = null;
            int lastIndex = 0;
            AddOrganizerLables(rules, grid, ref lastIndex, fontSystem, OrganizerIds.Green);
            AddOrganizerLables(rules, grid, ref lastIndex, fontSystem, OrganizerIds.Red);
            AddOrganizerLables(rules, grid, ref lastIndex, fontSystem, OrganizerIds.Blue);
            AddOrganizerLables(rules, grid, ref lastIndex, fontSystem, OrganizerIds.Bin);

            return new List<Component> { sprite, new UiGridComponent(grid, sprite.Size, sprite.Position) };
        }

        private Label GetLabel(string text, int row, FontSystem fontSystem)
        {
            return new Label()
            {
                GridRow = row,
                GridColumn = 0,
                TextColor = Color.Black,
                Font = fontSystem.GetFont((int)SizeManager.ScaleForWidth(16)),
                Text = text
            };
        }

        private string GetOrganizerName(OrganizerIds organizerId)
        {
            return organizerId switch
            {
                OrganizerIds.Bin => "Trash",
                OrganizerIds.Blue => "Blue Document Holder",
                OrganizerIds.Red => "Blue Document Holder",
                OrganizerIds.Green => "Green Document Holder",
                _ => ""
            };
        }

        private void AddOrganizerLables(List<Rule> rules, Grid grid, ref int lastIndex, FontSystem fontSystem, OrganizerIds organizerId)
        {
            if (ActiveRules.ContainsKey(organizerId) && lastIndex < 19)
            {
                rules = ActiveRules[organizerId];
                grid.Widgets.Add(GetLabel("", lastIndex, fontSystem));
                lastIndex++;
                grid.Widgets.Add(GetLabel(GetOrganizerName(organizerId) + ":", lastIndex, fontSystem));
                lastIndex++;
                for (int i = 0; i < 20; i++)
                {
                    if (i == rules.Count) break;
                    if (lastIndex >= 19) break;
                    grid.Widgets.Add(GetLabel(" - " + rules[i].Description, lastIndex, fontSystem));
                    lastIndex++;
                }
            }
        }

        private bool IsMouseOverStickyNote()
        {
            MouseState mouse = Mouse.GetState();
            Rectangle mouseRectangle = new Rectangle(mouse.Position.X, mouse.Position.Y, 1, 1);
            return mouseRectangle.Intersects(Rectangle);
        }
    }
}
