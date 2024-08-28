using LogicaAccesoDatos.EF;
using LogicaNegocio.Entidades;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaAccesoDatos.Init
{
    public class InitialCharge
    {
        List<FormattableString> SqlStatemnts = new List<FormattableString>();

        private HotelContext _contex;
        public InitialCharge(HotelContext context)
        {
            _contex = context;
        }

        // se puede escribir sql con ef
        //
        //
        //
        // FromSql
        //FormattableString sql = $"SELECT * FROM Books WHERE Title = 'Hamlet'";
        //var book = context.Books.FromSql(sql).FirstOrDefault();

        // SqlQuery
        //var results = context.Database.SqlQuery<int>($"SELECT COUNT(*) FROM Books");

        // ExecuteSql
        // var affectedRows = context.Database.ExecuteSql($"UPDATE Customers SET Name='Jane' WHERE Name='John'");
        public void Init()
        {

            // USUARIOS
            SqlStatemnts.Add(FormattableStringFactory.Create("SET IDENTITY_INSERT Usuarios ON"));
            SqlStatemnts.Add(FormattableStringFactory.Create("INSERT INTO[dbo].[Usuarios] ([Id],[Email], [Password]) VALUES(1, N'diego@ort.com', N'diego123')"));
            SqlStatemnts.Add(FormattableStringFactory.Create("INSERT INTO[dbo].[Usuarios] ([Id],[Email], [Password]) VALUES(2, N'mateo@ort.com', N'mateo123')\r\n"));





            foreach (FormattableString item in SqlStatemnts)
            {
                _contex.Database.ExecuteSql(item);
            }
        }

    }

}

