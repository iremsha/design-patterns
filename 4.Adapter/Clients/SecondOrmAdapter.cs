using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example_04.Homework.Models;
using Example_04.Homework.SecondOrmLibrary;

namespace Example_04.Homework.Clients
{
    class SecondOrmAdapter : IOrmAdapter
    {
        private ISecondOrm _secondOrm;
        public SecondOrmAdapter(ISecondOrm secondOrm)
        {
            _secondOrm = secondOrm;
        }
        public void Add(DbUserEntity user, DbUserInfoEntity userInfo)
        {
            _secondOrm.Context.Users.Add(user);
            _secondOrm.Context.UserInfos.Add(userInfo);

        }

        public (DbUserEntity, DbUserInfoEntity) Get(int userId)
        {
            var user = _secondOrm.Context.Users.First(i => i.Id == userId);
            var userInfo = _secondOrm.Context.UserInfos.First(i => i.Id == user.InfoId);
            return (user, userInfo);
        }

        public void Remove(int userId)
        {
            _secondOrm.Context.Users.RemoveWhere(i => i.Id == userId);
            _secondOrm.Context.UserInfos.RemoveWhere(i => i.Id == userId);
        }
    }
}
