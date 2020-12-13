using System;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;
using NpgsqlTypes;

namespace problems
{
    class ParseGzFiles
    {
        private static string BASE_PATH = @"../data";
        private static string CONN_STRING = "Host=127.0.0.1;Username=bucha;Password=abcd123;Database=bucha_db;";

        public async Task readFile(string fileName = "")
        {
            // fileName = String.IsNullOrEmpty(fileName) ? "sample-2mb-text-file.txt.gz" : fileName;
            fileName = String.IsNullOrEmpty(fileName) ? "1000000_Sales_Records.csv.gz" : fileName;
            fileName = string.Join('/', BASE_PATH, fileName);
            await using var conn = new Npgsql.NpgsqlConnection(CONN_STRING);
            await conn.OpenAsync();
            int count = 0;

            // var conn = new Npgsql.NpgsqlConnection(CONN_STRING);
            CancellationToken ct = default(CancellationToken);

            using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (GZipStream unzip = new GZipStream(fileStream, CompressionMode.Decompress))
                {
                    using (StreamReader reader = new StreamReader(unzip))
                    {
                        string line = string.Empty;
                        string sqlCmd = "COPY public.pg_sales(" +
                                "region, country, item_type, sales_channel, " +
                                "order_priority, order_date, order_id, ship_date, " +
                                "unit_sold, unit_price, unit_cost, total_revenue, " +
                                "total_cost, total_profit) " +
                                "FROM STDIN(FORMAT BINARY)".Trim();

                        Npgsql.NpgsqlBinaryImporter writer = conn.BeginBinaryImport(sqlCmd);

                        // using (true)
                        // {

                        // skip header        
                        await reader.ReadLineAsync();

                        while (!reader.EndOfStream)
                        {
                            line = await reader.ReadLineAsync();

                            count++;
                            var splitted = line.Trim().Split(',');

                            writer.StartRow();
                            writer.Write(splitted[0]);
                            writer.Write(splitted[1]);
                            writer.Write(splitted[2]);
                            writer.Write(splitted[3]);
                            writer.Write(splitted[4], NpgsqlDbType.Char);
                            writer.Write(DateTime.Parse(splitted[5]), NpgsqlDbType.Date);
                            writer.Write(long.Parse(splitted[6]), NpgsqlDbType.Bigint);
                            writer.Write(DateTime.Parse(splitted[7]), NpgsqlDbType.Date);
                            writer.Write(int.Parse(splitted[8]), NpgsqlDbType.Integer);
                            writer.Write(decimal.Parse(splitted[9]), NpgsqlDbType.Numeric);
                            writer.Write(decimal.Parse(splitted[10]), NpgsqlDbType.Numeric);
                            writer.Write(decimal.Parse(splitted[11]), NpgsqlDbType.Numeric);
                            writer.Write(decimal.Parse(splitted[12]), NpgsqlDbType.Numeric);
                            writer.Write(decimal.Parse(splitted[13]), NpgsqlDbType.Numeric);

                            //TODO: Read x number of lines
                            /// if count == x, bulk push into postgres db
                            if (count == 100000)
                            {
                                try
                                {
                                    ulong result = await writer.CompleteAsync(ct);
                                    System.Console.WriteLine($"records written - {result}");
                                    System.Console.WriteLine(conn.State.ToString());
                                    count = 0;
                                    await writer.DisposeAsync();
                                    // await conn.DisposeAsync();
                                    // await conn.OpenAsync(ct);
                                    writer = conn.BeginBinaryImport(sqlCmd);
                                }
                                catch (System.Exception ex)
                                {
                                    System.Console.WriteLine(ex.Message);
                                    await writer.DisposeAsync();
                                }
                            }
                        }
                    }
                }
            }
        }

        [Serializable]
        internal class Pg_Sales
        {
            public int SalesID { get; set; }
            public string Region { get; set; }
            public string Country { get; set; }
            public string ItemType { get; set; }
            public string SalesChannel { get; set; }
            public char OrderPriority { get; set; }
            public DateTime OrderDate { get; set; }
            public long OrderId { get; set; }
            public DateTime ShipDate { get; set; }
            public int UnitSold { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal UnitCost { get; set; }
            public decimal TotalRevenue { get; set; }
            public decimal TotalCost { get; set; }
            public decimal TotalProfit { get; set; }
        }
    }
}