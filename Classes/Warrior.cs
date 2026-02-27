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
    public class Warrior
    {
        private int health;
        public int Health
        {
            get { return health; }
            set
            {
                if (value < 0)
                    health = 0;
                else
                    health = value;
            }
        }
        public int MaxHealth { get; set; }

        public double X { get; set; }
        public double Y { get; set; }

        public Warrior(int health, double x, double y)
        {
            MaxHealth = health;
            Health = health;
            X = x;
            Y = y;
        }

        public virtual int TakeDamage(int damage)
        {
            int actualDamage = damage;
            Health -= actualDamage;
            return actualDamage;
        }

        public virtual void Draw(Canvas canvas)
        {
            Ellipse warrior = new Ellipse();
            warrior.Width = 60;
            warrior.Height = 60;
            warrior.Fill = Brushes.Gray;
            warrior.Stroke = Brushes.Black;
            warrior.StrokeThickness = 3;

            Canvas.SetLeft(warrior, X - 30);
            Canvas.SetTop(warrior, Y - 30);

            canvas.Children.Add(warrior);

            Ellipse leftEye = new Ellipse() { Width = 8, Height = 8, Fill = Brushes.Black };
            Canvas.SetLeft(leftEye, X - 15);
            Canvas.SetTop(leftEye, Y - 10);
            canvas.Children.Add(leftEye);

            Ellipse rightEye = new Ellipse() { Width = 8, Height = 8, Fill = Brushes.Black };
            Canvas.SetLeft(rightEye, X + 7);
            Canvas.SetTop(rightEye, Y - 10);
            canvas.Children.Add(rightEye);
        }

        public Brush GetHealthColor()
        {
            double percent = (double)Health / MaxHealth;

            if (percent > 0.6)
                return Brushes.Green;
            else if (percent > 0.3)
                return Brushes.Orange;
            else
                return Brushes.Red;
        }

        public void DrawHealthBar(Canvas canvas)
        {
            Rectangle healthBarBackground = new Rectangle()
            {
                Width = 80,
                Height = 10,
                Fill = Brushes.DarkGray,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Canvas.SetLeft(healthBarBackground, X - 40);
            Canvas.SetTop(healthBarBackground, Y + 40);
            canvas.Children.Add(healthBarBackground);

            double healthPercent = (double)Health / MaxHealth;
            Rectangle healthBar = new Rectangle()
            {
                Width = 80 * healthPercent,
                Height = 10,
                Fill = GetHealthColor()
            };
            Canvas.SetLeft(healthBar, X - 40);
            Canvas.SetTop(healthBar, Y + 40);
            canvas.Children.Add(healthBar);
        }
    }
}
