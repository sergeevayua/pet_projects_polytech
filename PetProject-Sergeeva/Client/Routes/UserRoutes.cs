using Server.Controllers;
using Server.Dtos;

namespace Client.Routes {

    public delegate void UserRouteAction(ref UserDto? user);

    public struct UserRoute
    {
        public string Path { get; }
        public UserRouteAction Action { get; }

        public UserRoute(string path, UserRouteAction action)
        {
            Path = path;
            Action = action;
        }
    }

    public static class UserRoutes
    {
        public static List<UserRoute> GetActualRoutes(UserDto? user)
        {
            if (user == null) return UnauthRoutes();

            var routes = AuthRoutes();
            if (user.Role == "ADMIN") routes.AddRange(AdminRoutes());

            return routes;
        }

        private static List<UserRoute> UnauthRoutes()
        {
            return new List<UserRoute>
        {
            new UserRoute("Логин", AuthController.Login),
            new UserRoute("Регистрация", AuthController.Register),
        };
        }

        private static List<UserRoute> AuthRoutes()
        {
            return new List<UserRoute>
        {
            new UserRoute("Показать всех пользователей", UserController.ShowUsers),
            new UserRoute("Найти пользователя по логину", UserController.ShowUserByLogin),
            new UserRoute("Выход", AuthController.Logout),
        };
        }

        private static List<UserRoute> AdminRoutes()
        {
            return new List<UserRoute>
        {
            new UserRoute("Удалить пользователя", UserController.DeleteUserByLogin),
            new UserRoute("Изменить роль пользователя", UserController.ChangeUserRoleByLogin),
        };
        }
    }
}