using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example_04.Homework.FirstOrmLibrary;
using Example_04.Homework.Models;

namespace Example_04.Homework.Clients
{


    class FirstOrmAdapter : IOrmAdapter
    {

        private IFirstOrm<DbUserEntity> _firstOrmBdEntuty;
        private IFirstOrm<DbUserInfoEntity> _firstOrmBdInfoEnity;

        public FirstOrmAdapter(IFirstOrm<DbUserEntity> firstOrmBdEntuty, IFirstOrm<DbUserInfoEntity> firstOrmBdInfoEnity)
        {
            _firstOrmBdEntuty = firstOrmBdEntuty;
            _firstOrmBdInfoEnity = firstOrmBdInfoEnity;
        }

        public void Add(DbUserEntity user, DbUserInfoEntity userInfo)
        {
            _firstOrmBdEntuty.Add(user);
            _firstOrmBdInfoEnity.Add(userInfo);
        }

        public (DbUserEntity, DbUserInfoEntity) Get(int userId)
        {
            var user = _firstOrmBdEntuty.Read(userId);
            var userInfo = _firstOrmBdInfoEnity.Read(user.InfoId);
            return (user, userInfo);
        }

        public void Remove(int userId)
        {
            var user = _firstOrmBdEntuty.Read(userId);
            var userInfo = _firstOrmBdInfoEnity.Read(user.InfoId);

            _firstOrmBdInfoEnity.Delete(userInfo);
            _firstOrmBdEntuty.Delete(user);
        }
    }
}
