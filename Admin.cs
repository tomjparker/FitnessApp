// Intended to allow account creation and accessing of your personal data. 
// We want 3 buckets essentially, one with account data and ID for a user, and two for the weightlogs and caloriclogs with time series data respectivelly. 

using InfluxDB.Client;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using classset;

namespace AccountManagement
{
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

    public class AccountRepository : IAccountRepository
    {
        private readonly Context _context;
        private readonly InfluxDBClient _influxClient;

        public AccountRepository(Context context, InfluxDBClient influxClient)
        {
            _context = context;
            _influxClient = influxClient;
        }

        public Account GetById(int accountId)
        {
            return _context.Accounts.FirstOrDefault(a => a.Id == accountId);
        }

        public IEnumerable<Account> GetAll()
        {
            return _context.Accounts.ToList();
        }

        public void Add(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();

            // Deposit data into Influx setup
            WriteApi writeApi = _influxClient.GetWriteApi();
            PointData point = PointData.Measurement("accounts")
                .Tag("id", account.Id.ToString())
                .Field("username", account.Username)
                .Field("age", account.Age)
                .Field("name", account.Name)
                .Field("password", account.Password)
                .Field("current_weight", account.CurrentWeight)
                .Field("goal_weight", account.GoalWeight)
                .Field("week_cal_av", account.WeekCalAv)
                .Field("month_cal_av", account.MonthCalAv)
                .Field("daily_calories", account.DailyCalories);

            writeApi.WritePoint("my-influx-bucket", "my-influx-org", point); // Add in the bucket and destination later
            writeApi.Flush();
            Console.WriteLine("Account created");
        }

        public void Update(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            _context.SaveChanges();

            // Update data in Influx setup
            WriteApi writeApi = _influxClient.GetWriteApi();
            PointData point = PointData.Measurement("accounts")
                .Tag("id", account.Id.ToString())
                .Field("username", account.Username)
                .Field("age", account.Age)
                .Field("name", account.Name)
                .Field("password", account.Password)
                .Field("current_weight", account.CurrentWeight)
                .Field("goal_weight", account.GoalWeight)
                .Field("week_cal_av", account.WeekCalAv)
                .Field("month_cal_av", account.MonthCalAv)
                .Field("daily_calories", account.DailyCalories);

            writeApi.WritePoint("my-influx-bucket", "my-influx-org", point);
            writeApi.Flush();
            Console.WriteLine("Account data updated")
        }

        public void Delete(Account account)
        {
            _context.Accounts.Remove(account);
            _context.SaveChanges();

            // Delete data from Influx setup
            WriteApi writeApi = _influxClient.GetWriteApi();
            writeApi.Delete(DateTime.MinValue, DateTime.MaxValue, "accounts");
            writeApi.Flush();
        }
    }

    public interface IAccountRepository
    {
        Account GetById(int id);
        IEnumerable<Account> GetAll();
        void Add(Account account);
        void Update(Account account);
        void Delete(Account account);
    }
}