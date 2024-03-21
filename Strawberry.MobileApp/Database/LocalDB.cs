using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Strawberry.MobileApp.Helpers
{
    public class LocalDB
    {
        private static LocalDB instance;

        public static LocalDB Instance
        {
            get
            {
                if (instance == null)
                    instance = new LocalDB();

                return instance;
            }
        }

        public SQLiteAsyncConnection Database { get; private set; }
        public bool IsInitialized { get; private set; }

        private LocalDB()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "strawberry.db3");
            this.Database = new SQLiteAsyncConnection(path, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache);
            this.IsInitialized = false;
        }

        public void InitAsync()
        {
            //await this.Database.CreateTableAsync<MessageItem>();
            this.IsInitialized = true;
        }
    }
}
