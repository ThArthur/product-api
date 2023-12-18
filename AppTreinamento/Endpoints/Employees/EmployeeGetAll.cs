using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;

namespace AppTreinamento.Endpoints.Employees
{
    public class EmployeeGetAll
    {
        public static string Template => "/employees";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        // Utilizando Dapper
        public static IResult Action(int page, int rows, IConfiguration configuration)
        {
            var db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            var query =
                @"select Email, ClaimValue as Name 
                from AspNetUsers u inner join AspNetUserClaims c 
                on u.id = c.UserId and ClaimType = 'Name'
                order by name
                OFFSET (@page -1) * @rows ROWS FETCH NEXT @rows ROWS ONLY";

            var employees = db.Query<EmployeeResponse>(
               query,
               new { page, rows }
            );

            return Results.Ok(employees);
        }

        // Utilizando Identity
        //
        //public static IResult Action(int page, int rows, UserManager<IdentityUser> userManager)
        //{
        //    var users = userManager.Users.Skip((page - 1) * rows).Take(rows).ToList();

        //    var employees = new List<EmployeeResponse>();

        //    foreach (var user in users)
        //    {
        //        var claims = userManager.GetClaimsAsync(user).Result;
        //        var claimName = claims.FirstOrDefault(c => c.Type == "Name");
        //        var userName = claimName != null ? claimName.Value : string.Empty;

        //        employees.Add(new EmployeeResponse(user.Email, userName));
        //    }

        //    return Results.Ok(employees);
        //}
    }
}
