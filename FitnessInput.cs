using LinqLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class Dashboard : Form
    {
        private decimal currentWeight;
        private decimal goalWeight;
        private int dailyCalories;
        List<Person> people = ListManager.LoadSampleData();

        public Dashboard()
        {
            InitializeComponent();
            InitializeBindings();
        }

        private void InitializeBindings()
        {
            allPeopleDropdown.DataSource = people;
            allPeopleDropdown.DisplayMember = "FullName";
            weightLabel.DataBindings.Add("Text", people, "CurrentWeight");
            goalWeightLabel.DataBindings.Add("Text", people, "GoalWeight");
            caloriesLabel.DataBindings.Add("Text", people, "DailyCalories");
        }

        private void UpdateBindings()
        {
            weightLabel.Text = currentWeight.ToString();
            goalWeightLabel.Text = goalWeight.ToString();
            caloriesLabel.Text = dailyCalories.ToString();
        }

        private void allPeopleDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            Person selectedPerson = (Person)allPeopleDropdown.SelectedItem;
            currentWeight = selectedPerson.CurrentWeight;
            goalWeight = selectedPerson.GoalWeight;
            dailyCalories = selectedPerson.DailyCalories;
            UpdateBindings();
        }

        private void updatePersonButton_Click(object sender, EventArgs e)
        {
            Person selectedPerson = (Person)allPeopleDropdown.SelectedItem;
            selectedPerson.CurrentWeight = currentWeight;
            selectedPerson.GoalWeight = goalWeight;
            selectedPerson.DailyCalories = dailyCalories;
            UpdateBindings();
        }
    }
}

    public class FitnessApp
    {
            public void StartWorkout()
        {
            WorkoutManager workoutManager = new WorkoutManager();
            workoutManager.Start();

            // Prompt the user for weight and caloric intake
            Console.Write("Enter your weight: ");
            decimal weight = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter your caloric intake: ");
            int calories = Convert.ToInt32(Console.ReadLine());

            // Store the weight and caloric intake
            StoreWeightAndCaloricIntake(weight, calories);
        }
    }
