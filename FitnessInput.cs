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

        private void calculateButton_Click(object sender, EventArgs e)
        {
            decimal weight = decimal.Parse(weightTextBox.Text);
            int calories = int.Parse(caloriesTextBox.Text);

            // Perform the calculation for the workout plan based on weight and calories
            string workoutPlan = CalculateWorkoutPlan(weight, calories);

            // Display the workout plan to the user (you can use a label or any other control)
            workoutPlanLabel.Text = workoutPlan;
        }

        private string CalculateWorkoutPlan(decimal weight, int calories)
        {
            // Implement your logic to calculate the workout plan based on weight and calories
            // Return the calculated workout plan as a string
            // You can customize this method according to your specific requirements

            // Example implementation:
            string workoutPlan = $"Your workout plan for weight {weight} and calories {calories} goes here.";

            return workoutPlan;
        }
    }


    public class logging
    {
        public void logger()
        {
            Console.Write("Enter your weight: ");
            decimal weight = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter your caloric intake: ");
            int calories = Convert.ToInt32(Console.ReadLine());

            // Create an instance of StorageManager
            StorageManager storageManager = new StorageManager();

            // Call the method from StorageManager to store the weight and caloric intake
            storageManager.StoreWeightAndCaloricIntake(weight, calories);
        }
    }
}
