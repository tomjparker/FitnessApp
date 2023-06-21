// need to install NuGet package for microsoft SQL (entity framework) - axed for influx now
// need to run (Bash) Enable-Migrations
// yet to understand the SQL interactions - need to know how this data gets stored
using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;

namespace Data
{
    public class StorageManager
    {
        public void StoreWeightAndCaloricIntake(int userId, decimal weight, int calories)
        {
            try
            {
            using (var influxClient = InfluxDBClientFactory.Create("http://localhost:8086", "V4T8kAjXf_rLlfqrB2pOZM_ooHwa3_kO8GJz4CVRK9iN_4pXWBlcNqd7_p8VqwqCwVM5eGRTlJY-zXrWuLaASg==".ToCharArray()))
            {
                var writeApi = influxClient.GetWriteApi();

                WriteMeasurement(writeApi, "weight_logs", userId, weight);
                WriteMeasurement(writeApi, "caloric_intake_logs", userId, calories);

                writeApi.Flush();
            }
        }
        catch (Exception ex)
        {
            // Handle the exception or log the error
            Console.WriteLine("An error occurred while storing weight and caloric intake: " + ex.Message);
        }
    }

        private void WriteMeasurement(WriteApi writeApi, string measurementName, int userId, decimal value)
        {
            var point = PointData.Measurement(measurementName)
                .Tag("UserId", userId.ToString())
                .Field("Value", value)
                .Timestamp(DateTime.UtcNow, WritePrecision.Ms);

            writeApi.WritePoint("my-bucket", "my-org", point);
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