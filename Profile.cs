
// Intended to be able to run the main instance for a given person from here, 
// then depositing data into sql storage for retrieval of values like monthCalAv - an averaged value on future usage
// data input should be intially collected from the FormUI Namespace
// Think this may be uneccessary for right now

namespace classset;
     public class Account
{
    public int Id { get; set; }
    public string Username { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public double CurrentWeight { get; set; }
    public double GoalWeight { get; set; }
    public double WeekCalAv { get; set; }
    public double MonthCalAv { get; set; }
    public double DailyCalories { get; set; }
}

    public class WeightLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public decimal Weight { get; set; }
    }

    public class CaloricIntakeLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int Calories { get; set; }
    }


namespace Profile
{
    public class UserProfile
    {
        public string Username { get; set; }
        public decimal CurrentWeight { get; set; }
        public decimal GoalWeight { get; set; }
        public int WeekCalAv { get; set; }
        public int MonthCalAv { get; set; }
        public int DailyCalories { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }

        public void SaveProfile()
        {
            try
            {
                using (var context = new FitnessAppContext())
                {
                    var user = new User
                    {
                        Name = Username,
                        Age = Age,
                        CurrentWeight = CurrentWeight,
                        GoalWeight = GoalWeight,
                        WeekCalAv = WeekCalAv,
                        MonthCalAv = MonthCalAv,
                        DailyCalories = DailyCalories
                    };

                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while saving the profile: " + ex.Message);
            }
        }
    }

    public class FitnessAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<WeightLog> WeightLogs { get; set; }
        public DbSet<CaloricIntakeLog> CaloricIntakeLogs { get; set; }

        public FitnessAppContext() : base("YourConnectionString")
        {
            // Replace "YourConnectionString" with your SQL Server connection string
        }
    }

    internal sealed class Configuration : DbMigrationsConfiguration<FitnessAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FitnessAppContext context)
        {
            // Add seed data or initial records here
        }
    }

    private void UpdateProfile(Profile profile)
    {
        try
        {
            using (var context = new FitnessAppContext())
            {
                // Retrieve the user's profile from the database (assuming you have a UserProfile table/entity)
                UserProfile userProfile = context.UserProfiles.SingleOrDefault(u => u.UserId == userId);

                if (userProfile != null)
                {
                    // Update the profile information
                    userProfile.CurrentWeight = profile.CurrentWeight;
                    userProfile.DailyCalories = profile.DailyCalories;
                    userProfile.GoalWeight = profile.GoalWeight;
                    userProfile.WeekCalAv = profile.WeekCalAv;
                    userProfile.MonthCalAv = profile.MonthCalAv;

                    // Create weight log entry
                    var weightLog = new WeightLog
                    {
                        UserId = userId,
                        Date = DateTime.Now,
                        Weight = profile.CurrentWeight
                    };
                    context.WeightLogs.Add(weightLog);

                    // Create caloric intake log entry
                    var caloricIntakeLog = new CaloricIntakeLog
                    {
                        UserId = userId,
                        Date = DateTime.Now,
                        Calories = profile.DailyCalories
                    };
                    context.CaloricIntakeLogs.Add(caloricIntakeLog);

                    // Save changes to the database
                    context.SaveChanges();
                }
            }
        }
        catch (Exception ex)
        {
            // Handle the exception or log the error
            Console.WriteLine("An error occurred while updating the profile and storing weight and caloric intake: " + ex.Message);
        }
    }
}