using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Warriors_Shihova.Classes
{
    public class HeavyArmorWarrior : Warrior
    {
        private const double ARMOR_REDUCTION = 0.6;

        public HeavyArmorWarrior(int health, double x, double y)
            : base(health, x, y)
        {
        }

        public override int TakeDamage(int damage)
        {
            int actualDamage = (int)(damage * (1 - ARMOR_REDUCTION));

            if (Health < MaxHealth * 0.2)
            {
                actualDamage = (int)(damage * 0.7);
            }

            Health -= actualDamage;
            return actualDamage;
        }

        public override void Draw(Canvas canvas)
        {
            Ellipse warrior = new Ellipse();
            warrior.Width = 60;
            warrior.Height = 60;
            warrior.Fill = Brushes.LightGreen;
            warrior.Stroke = Brushes.DarkGreen;
            warrior.StrokeThickness = 4;

            Canvas.SetLeft(warrior, X - 30);
            Canvas.SetTop(warrior, Y - 30);
            canvas.Children.Add(warrior);

            Rectangle helmet = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.SteelBlue
            };
            Canvas.SetLeft(helmet, X - 20);
            Canvas.SetTop(helmet, Y - 25);
            canvas.Children.Add(helmet);

            Rectangle breastplate = new Rectangle()
            {
                Width = 50,
                Height = 30,
                Fill = Brushes.SteelBlue,
                Opacity = 0.8
            };
            Canvas.SetLeft(breastplate, X - 25);
            Canvas.SetTop(breastplate, Y - 5);
            canvas.Children.Add(breastplate);

            Ellipse leftEye = new Ellipse() { Width = 6, Height = 6, Fill = Brushes.White };
            Canvas.SetLeft(leftEye, X - 15);
            Canvas.SetTop(leftEye, Y - 17);
            canvas.Children.Add(leftEye);

            Ellipse rightEye = new Ellipse() { Width = 6, Height = 6, Fill = Brushes.White };
            Canvas.SetLeft(rightEye, X + 9);
            Canvas.SetTop(rightEye, Y - 17);
            canvas.Children.Add(rightEye);

            DrawHealthBar(canvas);
        }
    }
}