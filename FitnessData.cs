// need to install NuGet package for microsoft SQL (entity framework)
// need to run (Bash) Enable-Migrations
// yet to understand the SQL interactions - need to know how this data gets stored
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Data;
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal CurrentWeight { get; set; }
        public decimal GoalWeight { get; set; }
        public int WeekCalAv { get; set; }
        public int MonthCalAv { get; set; }
        public int DailyCalories { get; set; }

        public virtual ICollection<WeightLog> WeightLogs { get; set; }
        public virtual ICollection<CaloricIntakeLog> CaloricIntakeLogs { get; set; }
    }

    // needs a rework
    public class WeightLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public decimal Weight { get; set; }

        public User User { get; set; }

    }

        // Example 
        // int userId = 1; Replace with the actual user ID
        // decimal weight = 75.5M; Replace with the user's weight
        // int calories = 2000; Replace with the caloric intake value

        // StoreWeightAndCaloricIntake(userId, weight, calories);

    public class CaloricIntakeLog
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public DateTime Date { get; set; }
            public int Calories { get; set; }

            public User User { get; set; }
        }
    
    public class FitnessAppContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<WeightLog> WeightLogs { get; set; }

        public FitnessAppContext() : base("YourConnectionString")
        {
            // Replace "YourConnectionString" with your SQL Server connection string
        }
    }

    public void StoreWeightAndCaloricIntake(int userId, decimal weight, int calories)
    {
        try
        {
            using (var context = new FitnessAppContext())
            {
                var user = context.Users.Find(userId);

                if (user != null)
                {
                    // Create weight log entry
                    var weightLog = new WeightLog
                    {
                        User = user,
                        Date = DateTime.Now,
                        Weight = weight
                    };
                    context.WeightLogs.Add(weightLog);

                    // Create caloric intake log entry
                    var caloricIntakeLog = new CaloricIntakeLog
                    {
                        User = user,
                        Date = DateTime.Now,
                        Calories = calories
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
            Console.WriteLine("An error occurred while storing weight and caloric intake: " + ex.Message);
        }
    }

    public class FitnessAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<WeightLog> WeightLogs { get; set; }

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


