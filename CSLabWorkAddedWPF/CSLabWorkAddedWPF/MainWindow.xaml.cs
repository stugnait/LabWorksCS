using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using FluentValidation;
using Newtonsoft.Json;

namespace CSLabWorkAddedWPF
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public UserService userService = new UserService();

        private void Submit_OnClick(object sender, RoutedEventArgs e)
        {
            User user = new User(Login.Text, Password.Text, Email.Text, Convert.ToInt32(Age.Text), PhoneNumber.Text);
            userService.RegisterUser(user);

        }

        private void ShowUsers_OnClick(object sender, RoutedEventArgs e)
        {
            var users = userService.LoadUsers();
            foreach (var user in users)
            {
                MessageBox.Show(user.ToString());
            }
        }
    }
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Login).NotEmpty().MaximumLength(6).WithMessage("Максимальна довжина логіну - 6 символів");
            RuleFor(user => user.Password).NotEmpty().MinimumLength(12).WithMessage("Мінімальна довжина пароля - 12 символів");
            RuleFor(user => user.Email).NotEmpty().EmailAddress().WithMessage("Некоректний формат електронної пошти");
            RuleFor(user => user.Age).GreaterThan(0).LessThan(120).WithMessage("Вік повинен бути від 0 до 120");
            RuleFor(user => user.PhoneNumber).NotEmpty().MinimumLength(10).MaximumLength(13).WithMessage("Номер телефону не може бути порожнім");
        }
    }
    public class UserService
    {
        private const string FilePath = @"C:\Users\itesl\LabWorksCS\CSLabWorkAddedWPF\CSLabWorkAddedWPF\NewFile1.json";

        public void RegisterUser(User user)
        {
            var validator = new UserValidator();
            var validationResult = validator.Validate(user);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    Console.WriteLine($"Помилка: {error.ErrorMessage}");
                }

                return;
            }

            var users = LoadUsers();
            users.Add(user);

            SaveUsers(users);

            Console.WriteLine("Користувач успішно зареєстрований!");
        }

        public List<User> LoadUsers()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<List<User>>(json);
            }

            return new List<User>();
        }

        private void SaveUsers(List<User> users)
        {
            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
    }
    public class User
    {
        public string Login;
        public string Password;
        public string Email;
        public int Age;
        public string PhoneNumber;
        
        public User(string login, string password, string email, int age, string phoneNumber)
        {
            Login = login;
            Password = password;
            Email = email;
            Age = age;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{Login} \n {Password} \n {Email} \n {Age} \n {PhoneNumber}";
        }

    }
}