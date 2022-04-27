using ZicGooFriendsWeb.Models;

namespace ZicGooFriendsWeb.APIs
{
    public static class UserApi
    {
        public static void ConfigureUserApi(this WebApplication app) 
        {
            app.MapGet("/users", GetUsers);
            app.MapGet("/users/{id}", GetUserById);
            app.MapPost("/users", InsertUser);
            app.MapPut("/users/{id}", UpdateUser);
            app.MapDelete("/users/{id}", DeleteUserById);
        }

        private static async Task<IResult> GetUsers(IUserDao userDao)
        {
            try 
            {
                return Results.Ok(await userDao.GetAllUsers());
            }
            catch(Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetUserById(int id, IUserDao userDao)
        {
            try
            {
                var results = await userDao.GetUserById(id);
                return results is null ? Results.NotFound("User not found") : Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> InsertUser(UserModel user, IUserDao userDao)
        {
            try
            {
                await userDao.InsertUser(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> UpdateUser(UserModel user, IUserDao userDao)
        {
            try
            {
                await userDao.UpdateUser(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> DeleteUserById(int id, IUserDao userDao)
        {
            try
            {
                var results = await userDao.DeleteUserId(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
