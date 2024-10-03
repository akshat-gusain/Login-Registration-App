using LoginRegistrationApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace LoginRegistrationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        [HttpPost]
        [Route("registration")]

        public string Register(Registration registration)
        {
            // Trim the input to remove any leading or trailing spaces
            registration.UserName = registration.UserName?.Trim();
            registration.Password = registration.Password?.Trim();
            registration.Email = registration.Email?.Trim();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ToysCon").ToString()))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Registration (UserName, Password, Email, IsActive) VALUES (@UserName, @Password, @Email, @IsActive)", con);

                cmd.Parameters.AddWithValue("@UserName", registration.UserName);
                cmd.Parameters.AddWithValue("@Password", registration.Password);
                cmd.Parameters.AddWithValue("@Email", registration.Email);
                cmd.Parameters.AddWithValue("@IsActive", 1); // or set it based on your logic

                con.Open();
                cmd.ExecuteNonQuery();
            }

            return "User registered successfully.";
        }


        [HttpPost]
        [Route("login")]
        public string login(Registration registration)
        {
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ToysCon").ToString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Registration WHERE Email = @Email AND Password = @Password AND IsActive = 1", con);

                // Use parameters to avoid SQL injection and properly handle data types
                cmd.Parameters.AddWithValue("@Email", registration.Email);
                cmd.Parameters.AddWithValue("@Password", registration.Password);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Return "Valid User" if one valid user is found
                return dt.Rows.Count > 0 ? "Valid User" : "Invalid User";
            }
        }


    }


}


