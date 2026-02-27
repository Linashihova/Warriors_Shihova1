using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Warriors_Shihova.Classes
{
    public class LightArmorWarrior : Warrior
    {
        private const double ARMOR_REDUCTION = 0.3;

        public LightArmorWarrior(int health, double x, double y)
            : base(health, x, y)
        {
        }

        public override int TakeDamage(int damage)
        {
            int actualDamage = (int)(damage * (1 - ARMOR_REDUCTION));
            Health -= actualDamage;
            return actualDamage;
        }

        public override void Draw(Canvas canvas)
        {
            Ellipse warrior = new Ellipse();
            warrior.Width = 60;
            warrior.Height = 60;
            warrior.Fill = Brushes.LightBlue;
            warrior.Stroke = Brushes.Blue;
            warrior.StrokeThickness = 3;

            Canvas.SetLeft(warrior, X - 30);
            Canvas.SetTop(warrior, Y - 30);

            canvas.Children.Add(warrior);

            Rectangle chest = new Rectangle()
            {
                Width = 40,
                Height = 30,
                Fill = Brushes.Silver,
                Opacity = 0.7
            };
            Canvas.SetLeft(chest, X - 20);
            Canvas.SetTop(chest, Y - 10);
            canvas.Children.Add(chest);

            Ellipse leftEye = new Ellipse() { Width = 8, Height = 8, Fill = Brushes.Black };
            Canvas.SetLeft(leftEye, X - 15);
            Canvas.SetTop(leftEye, Y - 10);
            canvas.Children.Add(leftEye);

            Ellipse rightEye = new Ellipse() { Width = 8, Height = 8, Fill = Brushes.Black };
            Canvas.SetLeft(rightEye, X + 7);
            Canvas.SetTop(rightEye, Y - 10);
            canvas.Children.Add(rightEye);

            DrawHealthBar(canvas);
        }
    }
}
