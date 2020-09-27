using System;
using Dapper;
using Npgsql;

namespace MyDatabaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using var connecton = new NpgsqlConnection("Host=db;Database=postgres;Username=postgres;Password=postgres");
            connecton.Open();

            connecton.Execute("CREATE TABLE IF NOT EXISTS test (id serial, time timestamp with time zone)");

            // 現在の時刻を追加
            connecton.Execute("INSERT INTO test (time) VALUES (now())");

            // DB のデータを取得
            foreach (dynamic record in connecton.Query("SELECT * FROM test"))
            {
                Console.WriteLine("{0}\t{1}", record.id, record.time);
            }
        }
    }
}
