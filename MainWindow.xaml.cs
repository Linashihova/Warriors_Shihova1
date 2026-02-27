using System;
using System.Windows;
using Warriors_Shihova.Classes;

namespace Warriors_Shihova
{
    public partial class MainWindow : Window
    {
        private Warrior regularWarrior;
        private LightArmorWarrior lightWarrior;
        private HeavyArmorWarrior heavyWarrior;

        public MainWindow()
        {
            InitializeComponent();
            InitializeWarriors();
            DrawAllWarriors();
        }

        private void InitializeWarriors()
        {
            regularWarrior = new Warrior(100, 100, 100);
            lightWarrior = new LightArmorWarrior(100, 100, 100);
            heavyWarrior = new HeavyArmorWarrior(100, 100, 100);
        }

        private void DrawAllWarriors()
        {
            WarriorCanvas.Children.Clear();
            regularWarrior.Draw(WarriorCanvas);

            LightWarriorCanvas.Children.Clear();
            lightWarrior.Draw(LightWarriorCanvas);

            HeavyWarriorCanvas.Children.Clear();
            heavyWarrior.Draw(HeavyWarriorCanvas);

            UpdateHealthText();
        }

        private void UpdateHealthText()
        {
            WarriorHealthText.Text = $"Жизни: {regularWarrior.Health}";
            LightWarriorHealthText.Text = $"Жизни: {lightWarrior.Health}";
            HeavyWarriorHealthText.Text = $"Жизни: {heavyWarrior.Health}";
        }

        private void ApplyDamageToAllBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(DamageInput.Text, out int damage) && damage > 0)
            {
                regularWarrior.TakeDamage(damage);
                lightWarrior.TakeDamage(damage);
                heavyWarrior.TakeDamage(damage);

                DrawAllWarriors();
            }
            else
            {
                MessageBox.Show("Введите положительное число!", "Ошибка");
            }
        }
    }
}