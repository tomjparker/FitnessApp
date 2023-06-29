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
using Advisory;

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

            Profile profile = new Profile
            {
                CurrentWeight = weight,
                DailyCalories = calories
            };

        string workoutPlan = WorkoutPlanner.GenerateWorkoutPlan(profile);

        workoutPlanLabel.Text = workoutPlan; // Display Plan
        }
    }  
}

// user interface instance creation using - incorporate at some point when the buttons are done for the UI
Account account = new Account();

// Assuming you have UI controls like text boxes for user input
account.Id = int.Parse(txtId.Text);
account.Username = txtUsername.Text;
account.Age = int.Parse(txtAge.Text);
account.Name = txtName.Text;
account.Password = txtPassword.Text;
account.CurrentWeight = double.Parse(txtCurrentWeight.Text); //updated 
account.GoalWeight = double.Parse(txtGoalWeight.Text);
account.WeekCalAv = double.Parse(txtWeekCalAv.Text); //updated
account.MonthCalAv = double.Parse(txtMonthCalAv.Text); //updated
account.DailyCalories = double.Parse(txtDailyCalories.Text); //updated