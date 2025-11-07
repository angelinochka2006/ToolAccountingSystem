using System;
using System.Windows.Forms;
using ToolAccountingSystem.Models;

namespace ToolAccountingSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Показываем форму входа
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Если аутентификация успешна, запускаем главную форму
                User currentUser = loginForm.CurrentUser;
                Application.Run(new Form1(currentUser));
            }
        }
    }
}