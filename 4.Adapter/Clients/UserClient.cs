using System.Linq;
using Example_04.Homework.FirstOrmLibrary;
using Example_04.Homework.Models;
using Example_04.Homework.SecondOrmLibrary;

namespace Example_04.Homework.Clients
{
    public class UserClient
    {
        private bool _useFirstOrm = true;
        private IOrmAdapter firstOrmAdapter;
        private IOrmAdapter secondOrmAdapter;

        public UserClient(IFirstOrm<DbUserEntity> _firstOrmBdEntuty, IFirstOrm<DbUserInfoEntity> _firstOrmBdInfoEnity,
            ISecondOrm _secondOrm)
        {
            firstOrmAdapter = new FirstOrmAdapter(_firstOrmBdEntuty, _firstOrmBdInfoEnity);
            secondOrmAdapter = new SecondOrmAdapter(_secondOrm);
        }

        private IOrmAdapter ChooseAdapter (bool _useFirstOrm)
        {
            return _useFirstOrm ? firstOrmAdapter: secondOrmAdapter;
        }

        public void Add(DbUserEntity user, DbUserInfoEntity userInfo)
        {
            IOrmAdapter adapter = ChooseAdapter(_useFirstOrm);
            adapter.Add(user, userInfo);
        }

        public (DbUserEntity, DbUserInfoEntity) Get(int userId)
        {
            IOrmAdapter adapter = ChooseAdapter(_useFirstOrm);
            return adapter.Get(userId);
        }

        public void Remove(int userId)
        {
            IOrmAdapter adapter = ChooseAdapter(_useFirstOrm);
            adapter.Remove(userId);
        }
    }
}
