using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;

namespace Capstone.Tests
{
    [TestClass]
    public class NationalParkSqlDAOTest
    {
        #region Test Prep

        protected static string _connectionString  = "Server=.\\SQLEXPRESS;Database=npcampgroundtest;Trusted_Connection=True;";

        private TransactionScope transaction;

        /// <summary>
        /// Begins the transaction for each test.
        /// </summary>
        [TestInitialize]
        public void BeginTestTranaction()
        {
            transaction = new TransactionScope();
        }

        /// <summary>
        /// Closes out the test transaction and removes the data it uses.
        /// </summary>
        [TestCleanup]
        public void RollbackTestTranaction()
        {
            transaction.Dispose();
        }

        /// <summary>
        /// Runs SQL commands from a provided string to the test database.
        /// </summary>
        /// <param name="sql"></param>
        protected static void RunSQLCommand(string sql)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Runs SQL file from a provided filestring to the test database.
        /// </summary>
        /// <param name="sql"></param>
        protected static void RunSQLFile(string sql)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
            }
        }

        #endregion

        #region Campground Tests

        [TestMethod]
        public void GetCampgroundsTest()
        {
            string sql = "";
            RunSQLCommand(sql);
        }

        #endregion
    }
}
