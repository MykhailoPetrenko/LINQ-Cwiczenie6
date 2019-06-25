using Cwiczenia6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cwiczenia6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Emp> Emps { get; set; }
        public List<Dept> Depts { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            Example();
        }

        public void LoadData()
        {
            Emps = new List<Emp>();
            Depts = new List<Dept>();

            Emps.Add(new Emp
            {
                Empno = 7369,
                Ename = "SMITH",
                Job = "CLERK",
                Mgr = 7902,
                HireDate = new DateTime(1980, 12, 17),
                Sal=800,
                Comm=0,
                Deptno=20
            });

            Emps.Add(new Emp
            {
                Empno = 7499,
                Ename = "ALLEN",
                Job = "SALESMAN",
                Mgr = 7698,
                HireDate = new DateTime(1981, 2, 20),
                Sal = 1600,
                Comm = 300,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7521,
                Ename = "WARD",
                Job = "SALESMAN",
                Mgr = 7698,
                HireDate = new DateTime(1981, 2, 22),
                Sal = 1250,
                Comm = 500,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7566,
                Ename = "JONES",
                Job = "MANAGER",
                Mgr = 7839,
                HireDate = new DateTime(1981, 4, 2),
                Sal = 2975,
                Comm = 0,
                Deptno = 20
            });

            Emps.Add(new Emp
            {
                Empno = 7654,
                Ename = "MARTIN",
                Job = "SALESMAN",
                Mgr = 7698,
                HireDate = new DateTime(1981, 9, 28),
                Sal = 1250,
                Comm = 1400,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7698,
                Ename = "BLAKE",
                Job = "MANAGER",
                Mgr = 7839,
                HireDate = new DateTime(1981, 5, 1),
                Sal = 2850,
                Comm = 0,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7782,
                Ename = "CLARK",
                Job = "MANAGER",
                Mgr = 7839,
                HireDate = new DateTime(1981, 6, 9),
                Sal = 2450,
                Comm = 0,
                Deptno = 10
            });

            Emps.Add(new Emp
            {
                Empno = 7788,
                Ename = "SCOTT",
                Job = "ANALYST",
                Mgr = 7566,
                HireDate = new DateTime(1982, 12, 9),
                Sal = 3000,
                Comm = 0,
                Deptno = 20
            });

            Emps.Add(new Emp
            {
                Empno = 7839,
                Ename = "KING",
                Job = "PRESIDENT",
                Mgr = null,
                HireDate = new DateTime(1981, 11, 17),
                Sal = 5000,
                Comm = 0,
                Deptno = 10
            });

            Emps.Add(new Emp
            {
                Empno = 7844,
                Ename = "TURNER",
                Job = "SALESMAN",
                Mgr = 7698,
                HireDate = new DateTime(1981, 9, 8),
                Sal = 1500,
                Comm = 0,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7876,
                Ename = "ADAMS",
                Job = "CLERK",
                Mgr = 7788,
                HireDate = new DateTime(1983, 1, 12),
                Sal = 1100,
                Comm = 0,
                Deptno = 20
            });

            Emps.Add(new Emp
            {
                Empno = 7900,
                Ename = "JAMES",
                Job = "CLERK",
                Mgr = 7698,
                HireDate = new DateTime(1981, 12, 3),
                Sal = 950,
                Comm = 0,
                Deptno = 30
            });

            Emps.Add(new Emp
            {
                Empno = 7902,
                Ename = "FORD",
                Job = "ANALYST",
                Mgr = 7566,
                HireDate= new DateTime(1981, 12, 3),
                Sal = 3000,
                Comm = 0,
                Deptno = 20
            });

            Emps.Add(new Emp
            {
                Empno = 7934,
                Ename = "MILLER",
                Job = "CLERK",
                Mgr = 7782,
                HireDate = new DateTime(1982, 1, 23),
                Sal = 1300,
                Comm = 0,
                Deptno = 10
            });

            Depts.Add(new Dept
            {
                Deptno=10,
                Dname= "ACCOUNTING",
                Loc= "NEW YORK"
            });

            Depts.Add(new Dept
            {
                Deptno = 20,
                Dname = "RESEARCH",
                Loc = "DALLAS"
            });

            Depts.Add(new Dept
            {
                Deptno = 30,
                Dname = "SALES",
                Loc = "CHICAGO"
            });

            Depts.Add(new Dept
            {
                Deptno = 40,
                Dname = "OPERATIONS",
                Loc = "BOSTON"
            });
        }

        private void Example()
        {
            //Query syntax
            var result = from e in Emps
                         where e.Ename.StartsWith("K")
                         select e;

            //Lambda and Extension methods syntax
            var result2 = Emps.Where(e => e.Ename.StartsWith("K"));

               
         
            //6
            var lcz6 = Emps.GroupJoin(Depts, emp => emp.Deptno, dept => dept.Deptno, (emp, dept) => new
            {
                emp.Ename,
                pls= dept.Select(d=>new { d.Deptno })
            });

            //grupowanie
            //1
            var gr1 = Emps.Average(emp=> emp.Sal);
            var list = new List<object>
            {
                new
                {
                    gr1
                }
            };

            //2
            var gr2 = Emps.Where(emp => emp.Job == "CLERK").Min(emp => emp.Sal);
            var list2 = new List<object>
            {
                new
                {
                   gr2
                }
            };

            //3
            var gr3 = Emps.Where(e => e.Deptno == 20).Count();
            var list3 = new List<object>
            {
                new
                {
                   gr3
                }
            };
       


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var res1 = Emps.Select(n => new { salary = n.Sal * 12 });
            DataGrid.ItemsSource = res1;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var res2 = Emps.Select(n => new { emploee = n.Empno + " " + n.Ename });
            DataGrid.ItemsSource = res2;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var res3 = Emps.Select(n => new { zad3 = n.Ename + " pracuje w " + n.Deptno + " dzialie" });

            DataGrid.ItemsSource = res3;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var res5 = Emps.Select(n => new { n.Deptno });

            DataGrid.ItemsSource = res5;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var res6 = Emps.Select(n => new { n.Deptno }).Distinct();

            DataGrid.ItemsSource = res6;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var res7 = Emps.Select(n => new { zad7 = n.Deptno + " " + n.Job }).Distinct();

            DataGrid.ItemsSource = res7;
        }

        private void Button_Click_6(object sender, RoutedEventArgs p)
        {
            var res8 = Emps.OrderBy(e => e.Ename);

            DataGrid.ItemsSource = res8;
        }

        private void Button_Click_7(object sender, RoutedEventArgs p)
        {
            var res9 = Emps.OrderByDescending(e => e.HireDate);

            DataGrid.ItemsSource = res9;

        }

        private void Button_Click_8(object sender, RoutedEventArgs p)
        {
            var res10 = Emps.OrderBy(e => e.Deptno).ThenBy(e => e.Sal);

            DataGrid.ItemsSource = res10;

        }

        private void Button_Click_9(object sender, RoutedEventArgs p)
        {
            var res11 = Emps.Where(e => e.Job.StartsWith("CLERK"));

            DataGrid.ItemsSource = res11;

        }

        private void Button_Click_10(object sender, RoutedEventArgs p)
        {
            var res12 = Emps.Where(e => e.Deptno > 20);

            DataGrid.ItemsSource = res12;

        }

        private void Button_Click_11(object sender, RoutedEventArgs p)
        {
            var res14 = Emps.Where(e => e.Ename.StartsWith("S"));

            DataGrid.ItemsSource = res14;

        }

        private void Button_Click_12(object sender, RoutedEventArgs p)
        {
            var res17 = Emps.Where(e => e.Ename.Length > 4);

            DataGrid.ItemsSource = res17;

        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            var lcz1 = Emps.Join(Depts, emp => emp.Deptno, dept => dept.Deptno, (emp, dept) => new
            {
                Empno = emp.Empno,
                Ename = emp.Ename,
                Sal = emp.Sal,
                Comm = emp.Comm,
                Deptno = emp.Deptno,
                Mgr = emp.Mgr,
                Hiredate = emp.HireDate,
                Job = emp.Job,
                Dname = dept.Dname,
                Loc = dept.Loc
            });
            DataGrid.ItemsSource = lcz1;

        }

        private void Button_Click_14(object sender, RoutedEventArgs p)
        {
            var lcz2 = Emps.OrderBy(e => e.Ename).Join(Depts, emp => emp.Deptno, dept => dept.Deptno, (emp, dept) => new
            {
                Ename = emp.Ename,
                Dname = dept.Dname
            });
            DataGrid.ItemsSource = lcz2;

        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            var lcz3 = Emps.Join(Depts, emp => emp.Deptno, dept => dept.Deptno, (emp, dept) => new
            {
                emp.Ename,
                dept.Dname,
                dept.Deptno
            });
            DataGrid.ItemsSource = lcz3;

        }

        private void Button_Click_16(object sender, RoutedEventArgs p)
        {
            var lcz4 = Emps.Where(e => e.Sal > 1500).Join(Depts, emp => emp.Deptno, dept => dept.Deptno, (emp, dept) => new
            {
                emp.Sal,
                dept.Deptno,
                dept.Dname,
                dept.Loc
            });
            DataGrid.ItemsSource = lcz4;

        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            var lcz5 = Depts.Where(d => d.Loc == "DALLAS").Join(Emps, dept => dept.Deptno, emp => emp.Deptno, (dept, emp) => new
            {
                dept.Loc,
                emp.Ename
            });
            DataGrid.ItemsSource = lcz5;

        }

        private void Button_Click_18(object sender, RoutedEventArgs k)
        {
            var gr4 = Emps.GroupBy(e => new { Dept = e.Deptno }).Select(e => new
            {
                e.Key.Dept,
                Average = e.Average(p => p.Sal)
            });
            DataGrid.ItemsSource = gr4;

        }

        private void Button_Click_19(object sender, RoutedEventArgs p)
        {
            var gr8 = Emps.Where(emp => emp.Ename.Count() > 3).Average(e => e.Sal);
            var list7 = new List<object>
            {
                new
                {
                    gr8
                }
            };
            DataGrid.ItemsSource = list7.ToList();

        }
    }
}
