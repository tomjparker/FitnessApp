// Intended to print out a workout suggestion based on a calculated modifier using BMI, age and other factors

using System;

namespace Workout;
{   
    public static class WorkoutPlanner
    {
        public static void WorkoutCalculator(Profile profile)
        {
            // Need logic
        }
        public static void WorkoutPrint(Profile profile)
        {

            Console.WriteLine("Workout Plan:");

            // Day 1: Upper Body Strength Training
            Console.WriteLine("Day 1: Upper Body Strength Training");
            int benchPressReps = 3;
            int overheadPressReps = 3;
            int bentOverRowsReps = 3;
            int bicepCurlsReps = 3;
            int tricepDipsReps = 3;

            decimal benchPressWeight = profile.CurrentWeight * 0.8m;  // Adjust the multiplier as needed
            decimal overheadPressWeight = profile.CurrentWeight * 0.7m;  // Adjust the multiplier as needed
            decimal bentOverRowsWeight = profile.CurrentWeight * 0.9m;  // Adjust the multiplier as needed
            decimal bicepCurlsWeight = profile.CurrentWeight * 0.5m;  // Adjust the multiplier as needed
            decimal tricepDipsWeight = profile.CurrentWeight * 0.5m;  // Adjust the multiplier as needed

            Console.WriteLine($"- Bench Press: {benchPressReps} sets of {benchPressWeight} lbs");
            Console.WriteLine($"- Overhead Press: {overheadPressReps} sets of {overheadPressWeight} lbs");
            Console.WriteLine($"- Bent-Over Rows: {bentOverRowsReps} sets of {bentOverRowsWeight} lbs");
            Console.WriteLine($"- Bicep Curls: {bicepCurlsReps} sets of {bicepCurlsWeight} lbs");
            Console.WriteLine($"- Tricep Dips: {tricepDipsReps} sets of {tricepDipsWeight} lbs");

            // Day 2: Cardiovascular Exercise
            Console.WriteLine("Day 2: Cardiovascular Exercise");
            Console.WriteLine("- 30 minutes of brisk walking or jogging");
            Console.WriteLine("- Jumping jacks: 3 sets of 30 seconds");
            Console.WriteLine("- High knees: 3 sets of 30 seconds");
            Console.WriteLine("- Mountain climbers: 3 sets of 10 reps");

            // Day 3: Lower Body Strength Training
            Console.WriteLine("Day 3: Lower Body Strength Training");
            int squatsReps = 3;
            int lungesReps = 3;
            int deadliftsReps = 3;
            int calfRaisesReps = 3;

            decimal squatsWeight = profile.CurrentWeight * 0.6m;  // Adjust the multiplier as needed
            decimal lungesWeight = profile.CurrentWeight * 0.5m;  // Adjust the multiplier as needed
            decimal deadliftsWeight = profile.CurrentWeight * 0.8m;  // Adjust the multiplier as needed
            decimal calfRaisesWeight = profile.CurrentWeight * 0.4m;  // Adjust the multiplier as needed

            Console.WriteLine($"- Squats: {squatsReps} sets of {squatsWeight} lbs");
            Console.WriteLine($"- Lunges: {lungesReps} sets of {lungesWeight} lbs");
            Console.WriteLine($"- Deadlifts: {deadliftsReps} sets of {deadliftsWeight} lbs");
            Console.WriteLine($"- Calf Raises: {calfRaisesReps} sets of {calfRaisesWeight} lbs");

            // Day 4: Rest and Recovery
            Console.WriteLine("Day 4: Rest and Recovery");

            // Day 5: Full Body Circuit Training
            Console.WriteLine("Day 5: Full Body Circuit Training");
            Console.WriteLine("- Push-ups: 3 sets of 10 reps");
            Console.WriteLine("- Dumbbell Lunges: 3 sets of 12 reps (each leg)");
            Console.WriteLine("- Lat Pulldowns: 3 sets of 10 reps");
            Console.WriteLine("- Plank: Hold for 30 seconds");
            Console.WriteLine("- Russian Twists: 3 sets of 12 reps (each side)");

            // Day 6: Cardiovascular Exercise
            Console.WriteLine("Day 6: Cardiovascular Exercise");
            Console.WriteLine("- 30 minutes of cycling or swimming");
            Console.WriteLine("- Burpees: 3 sets of 10 reps");
            Console.WriteLine("- Bicycle Crunches: 3 sets of 15 reps");
            Console.WriteLine("- Box Jumps: 3 sets of 10 reps");

            // Day 7: Rest and Recovery
            Console.WriteLine("Day 7: Rest and Recovery");
        }
    }
}