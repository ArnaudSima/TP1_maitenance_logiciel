using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace SchoolManager 
{ 
    internal static class MembersSalary
    {
        private static readonly MemberSalarySettings _settings;

        static MembersSalary()
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables(prefix: "APP_")
            .Build();

            _settings = new MemberSalarySettings();
            config.GetSection("MembersSalary").Bind(_settings);
        }
        public static int PrincipalSalary => _settings.PrincipalSalary;
        public static int TeacherSalary => _settings.TeacherSalary;
        public static int ReceptionnistSalary => _settings.ReceptionnistSalary;
    }
}
