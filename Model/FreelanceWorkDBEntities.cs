using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW.FreelanceWork.Model
{
    /// <summary>
    /// In-memory database context (replaces EntityFramework for portability).
    /// Test credentials:
    ///   Admin  → login: admin@fw.dkit  / password: admin
    ///   User   → login: user@fw.dkit   / password: user123
    ///   Employer verify company name: "ТехноСтарт"
    ///   Employer login → login: emp@fw.dkit / password: emp123
    /// </summary>
    public class FreelanceWorkDBEntities
    {
        private static int _userIdCounter = 20;
        private static int _orderIdCounter = 20;

        public List<Role> Roles { get; set; }
        public List<User> Users { get; set; }
        public List<Employer> Employers { get; set; }
        public List<OrderBoard> OrderBoards { get; set; }

        public FreelanceWorkDBEntities()
        {
            Seed();
        }

        private void Seed()
        {
            Roles = new List<Role>
            {
                new Role { RoleID = 1, RoleName = "Администратор" },
                new Role { RoleID = 2, RoleName = "Пользователь" }
            };

            Users = new List<User>
            {
                new User { UserID=1,  FIO="Администратор",    UserPhone="admin",         UserMail="admin@fw.dkit",  UserSkills="Администрирование", RoleID=1 },
                new User { UserID=2,  FIO="Лукин Г.М.",       UserPhone="user123",       UserMail="user@fw.dkit",   UserSkills="C#, WPF",           RoleID=2 },
                new User { UserID=3,  FIO="Данилов В.И.",     UserPhone="8(105)192-75",  UserMail="test2@fw.dkit",  UserSkills="C#, WPF",           RoleID=2 },
                new User { UserID=4,  FIO="Лихачёва А.М.",   UserPhone="8(037)894-33",  UserMail="test3@fw.dkit",  UserSkills="C#, WPF",           RoleID=2 },
                new User { UserID=5,  FIO="Андреева В.А.",    UserPhone="8(495)356-12",  UserMail="test4@fw.dkit",  UserSkills="Java",              RoleID=2 },
                new User { UserID=6,  FIO="Алексеев А.С.",   UserPhone="8(495)888-11",  UserMail="test5@fw.dkit",  UserSkills="Python",            RoleID=2 },
                new User { UserID=7,  FIO="Тихонова М.К.",   UserPhone="8(495)777-22",  UserMail="test6@fw.dkit",  UserSkills="C#, WPF",           RoleID=2 },
                new User { UserID=8,  FIO="Ларионова К.И.",  UserPhone="8(495)666-33",  UserMail="test7@fw.dkit",  UserSkills="JavaScript",        RoleID=2 },
            };

            Employers = new List<Employer>
            {
                new Employer { EmployerID=1, FIO="ТехноСтарт",     INN="7114020001", EmployerPhone="emp123",        EmployerMail="emp@fw.dkit"     },
                new Employer { EmployerID=2, FIO="Jumpfrost",       INN="7114020002", EmployerPhone="8(888)778-57",  EmployerMail="jt@fw.dkit"      },
                new Employer { EmployerID=3, FIO="Frostvibe",       INN="7114020003", EmployerPhone="8(666)887-24",  EmployerMail="fb@fw.dkit"      },
                new Employer { EmployerID=4, FIO="Бургер и точка",  INN="7114020004", EmployerPhone="8(293)440-20",  EmployerMail="burger@fw.dkit"  },
                new Employer { EmployerID=5, FIO="Шин нет",         INN="7114020005", EmployerPhone="8(888)999-00",  EmployerMail="shin@fw.dkit"    },
                new Employer { EmployerID=6, FIO="Масседа",         INN="7114020006", EmployerPhone="8(999)187-91",  EmployerMail="me@fw.dkit"      },
                new Employer { EmployerID=7, FIO="Марс-Групп",      INN="7114020007", EmployerPhone="8(777)456-78",  EmployerMail="mars@fw.dkit"    },
                new Employer { EmployerID=8, FIO="Лист-Холл",       INN="7114020008", EmployerPhone="8(555)123-45",  EmployerMail="lh@fw.dkit"      },
            };

            OrderBoards = new List<OrderBoard>
            {
                new OrderBoard { OrderBoardID=1, Order="Доработка приложения",          EmployerID=2, UserID=2  },
                new OrderBoard { OrderBoardID=2, Order="Доработка приложения",          EmployerID=3, UserID=3  },
                new OrderBoard { OrderBoardID=3, Order="Доработка приложения",          EmployerID=4, UserID=4  },
                new OrderBoard { OrderBoardID=4, Order="Разработка АИС",                EmployerID=5, UserID=null },
                new OrderBoard { OrderBoardID=5, Order="Разработка АИС",                EmployerID=6, UserID=null },
                new OrderBoard { OrderBoardID=6, Order="Разработка АИС",                EmployerID=7, UserID=7  },
                new OrderBoard { OrderBoardID=7, Order="Разработка мобильного приложения", EmployerID=8, UserID=8 },
            };

            ResolveNavigation();
        }

        private void ResolveNavigation()
        {
            foreach (var u in Users)
                u.Role = Roles.FirstOrDefault(r => r.RoleID == u.RoleID);
            foreach (var o in OrderBoards)
            {
                o.Employer = Employers.FirstOrDefault(e => e.EmployerID == o.EmployerID);
                o.User     = Users.FirstOrDefault(u => u.UserID == o.UserID);
            }
        }

        public void SaveChanges()
        {
            ResolveNavigation();
        }

        public Task SaveChangesAsync()
        {
            SaveChanges();
            return Task.FromResult(0);
        }

        public int NextUserID()  => ++_userIdCounter;
        public int NextOrderID() => ++_orderIdCounter;
    }
}
