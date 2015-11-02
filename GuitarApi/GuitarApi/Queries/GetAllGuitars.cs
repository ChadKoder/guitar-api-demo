using System.Collections.Generic;

namespace GuitarApi.Queries
{
    class GetAllGuitars
    {
        private readonly Database _db;

        public GetAllGuitars(Database db)
        {
            _db = db;
        }

        public IEnumerable<Guitar> Execute()
        {
            return _db.Query<Guitar>("SELECT Company, Model, Description, BodyType, TotalFrets, FinishTop, FinishNeck, FinishBackSides, Price, Url, ImgUrl FROM Products");
        }
    }
}
