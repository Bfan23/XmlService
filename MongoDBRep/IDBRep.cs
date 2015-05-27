using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBRep
{
    interface IMongoDBRep<T> where T: class
    {
        void Save(T o);
        void Delete(string ID);
        T GetByID(string ID);
    }
}
