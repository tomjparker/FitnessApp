// Intended to allow account creation and accessing of your personal data. 

namespace AccountManagement
{
    public interface IAccountRepository
    {
        void Add(Account account);
        void Update(Account account);
        void Delete(int accountId);
        Account GetById(int accountId);
        Account GetByUsername(string username);
        // Add other necessary methods
    }

    public class AccountRepository : IAccountRepository
    {
        private readonly FitnessAppContext _context;

        public AccountRepository(FitnessAppContext context)
        {
            _context = context;
        }

        public void Add(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public void Update(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int accountId)
        {
            var account = GetById(accountId);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                _context.SaveChanges();
            }
        }

        public Account GetById(int accountId)
        {
            return _context.Accounts.FirstOrDefault(a => a.Id == accountId);
        }

        public Account GetByUsername(string username)
        {
            return _context.Accounts.FirstOrDefault(a => a.Username == username);
        }

        // Implement other necessary methods
    }

    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal CurrentWeight { get; set; }
        public decimal GoalWeight { get; set; }
        public int WeekCalAv { get; set; }
        public int MonthCalAv { get; set; }
        public int DailyCalories { get; set; }
    }

    public class User : Account
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class AdminAccount : Account
    {
        // Add any additional properties specific to the admin account
        // For example:
        // public bool CanPostNews { get; set; }
        // public bool CanBanUsers { get; set; }
    }

    public class AdminAccountGenerator
    {
        private readonly IAccountRepository _accountRepository;

        public AdminAccountGenerator(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void GenerateAdminAccount()
        {
            // Prompt the admin for username and password
            Console.Write("Enter admin username: ");
            string username = Console.ReadLine();

            Console.Write("Enter admin password: ");
            string password = Console.ReadLine();

            // Create a new admin account
            AdminAccount admin = new AdminAccount
            {
                Username = username,
                Password = password
            };

            // Save the admin account to the repository
            _accountRepository.Add(admin);

            Console.WriteLine("Admin account created successfully!");
        }
    }
}